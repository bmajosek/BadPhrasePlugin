using JetBrains.Application.Settings;
using JetBrains.Util.Extension;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Util;
using JetBrains.Application;

namespace ReSharperPlugin.BadPhrasePlugin.Providers;

[ShellComponent]
public class PhraseProvider
{
    private readonly FileSystemWatcher _watcher;
    private readonly Dictionary<string, string> _phrases = new();
    private readonly string _directoryPath;

    public Dictionary<string, string> GetPhrases() => _phrases;

    public PhraseProvider(ISettingsStore settingsStore)
    {
        var settings = settingsStore.BindToContextTransient(ContextRange.ApplicationWide);
        _directoryPath = settings.GetValue((BadPhraseSettings s) => s.DirectoryPath);
        if (Directory.Exists(_directoryPath))
        {
            _watcher = new FileSystemWatcher(_directoryPath)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.txt"
            };

            // Event handlers
            _watcher.Changed += OnChanged;
            _watcher.Created += OnChanged;
            _watcher.Deleted += OnChanged;
            _watcher.EnableRaisingEvents = true;

            LoadPhrases();
        }
    }

    private void LoadPhrases()
    {
        if (!Directory.Exists(_directoryPath))
        {
            return;
        }

        _phrases.Clear();
        var files = Directory.GetFiles(_directoryPath, "*.txt");
        foreach (var file in files)
        {
            foreach (var line in File.ReadAllLines(file))
            {
                var parts = line.Split(new[] { "==>" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    _phrases[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }
    }

    public void RefreshPhrases() => LoadPhrases();

    private async void OnChanged(object sender, FileSystemEventArgs e) => await Task.Run(LoadPhrases);

    public void Dispose() => _watcher?.Dispose();
}
using JetBrains.Application.Settings;
using JetBrains.Application.Settings.WellKnownRootKeys;

[SettingsKey(typeof(EnvironmentSettings), "Bad Phrase Plugin Settings")]
public class BadPhraseSettings
{
    [SettingsEntry("", "Directory path")]
    public string DirectoryPath { get; set; }
}
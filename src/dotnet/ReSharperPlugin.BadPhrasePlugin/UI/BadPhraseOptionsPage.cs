using System;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Application.Settings;
using JetBrains.Application.UI.Controls.FileSystem;
using JetBrains.Application.UI.Options;
using JetBrains.Application.UI.Options.OptionPages;
using JetBrains.Application.UI.Options.OptionsDialog;
using JetBrains.Application.UI.Options.OptionsDialog.SimpleOptions.ViewModel;
using JetBrains.DataFlow;
using JetBrains.IDE.UI;
using JetBrains.IDE.UI.Extensions;
using JetBrains.IDE.UI.Options;
using JetBrains.Lifetimes;
using JetBrains.ReSharper.Feature.Services.Daemon.OptionPages;
using JetBrains.ReSharper.UnitTestFramework.Resources;
using JetBrains.Rider.Model.UIAutomation;
using JetBrains.Util;

[OptionsPage(PID, PageTitle, null, ParentId = ToolsPage.PID)]
public class BadPhraseOptionsPage : BeSimpleOptionsPage
{
    private const string PID = nameof(BadPhraseOptionsPage);
    private const string PageTitle = "Bad Phrase Plugin";

    private readonly Lifetime _lifetime;

    public BadPhraseOptionsPage(Lifetime lifetime,
        OptionsPageContext optionsPageContext,
        OptionsSettingsSmartContext optionsSettingsSmartContext,
        IconHostBase iconHost,
        ICommonFileDialogs dialogs)
        : base(lifetime, optionsPageContext, optionsSettingsSmartContext)
    {
        _lifetime = lifetime;
        AddText("This is a sample options page that works likewise in ReSharper and Rider.");
        AddSpacer();
        AddFolderChooserOption(
            (BadPhraseSettings x) => x.DirectoryPath,
            id: nameof(BadPhraseSettings.DirectoryPath),
            initialValue: FileSystemPath.Empty,
            iconHost,
            dialogs);
    }
}
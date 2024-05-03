using JetBrains.Diagnostics;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Refactorings.Properties;
using JetBrains.Util;

namespace ReSharperPlugin.BadPhrasePlugin.Analysis;

[RegisterConfigurableSeverity(
    SeverityId,
    CompoundItemName: null,
    CompoundItemNameResourceType: null,
    CompoundItemNameResourceName: null,
    Group: HighlightingGroupIds.CodeSmell,
    Title: null,
    TitleResourceType: typeof(Resources),
    TitleResourceName: "BadPhrasePlugin",
    Description: null,
    DescriptionResourceType: typeof(Resources),
    DescriptionResourceName: "BadPhrasePlugin",
    DefaultSeverity: Severity.WARNING)]
[ConfigurableSeverityHighlighting(
    SeverityId,
    CSharpLanguage.Name,
    OverlapResolve = OverlapResolveKind.ERROR,
    OverloadResolvePriority = 0,
    ToolTipFormatStringResourceType = typeof(Resources),
    ToolTipFormatStringResourceName = "BadPhrasePlugin")]
public class BadPhraseHighlighting : IHighlighting
{
    public const string SeverityId = "Sample";
    public IComment Comment { get; }
    public string SuggestedReplacement { get; }
    public TextRange ReplacementRange;

    public BadPhraseHighlighting(IComment comment, string suggestedReplacement, TextRange replacementRange)
    {
        Comment = comment;
        SuggestedReplacement = suggestedReplacement;
        ReplacementRange = replacementRange;
    }

    public bool IsValid() => Comment.IsValid();

    public DocumentRange CalculateRange() => Comment.GetDocumentRange();

    public string ToolTip => $"Bad phrase detected: consider using '{SuggestedReplacement}'";

    public string ErrorStripeToolTip => "Click to replace bad phrase";
}
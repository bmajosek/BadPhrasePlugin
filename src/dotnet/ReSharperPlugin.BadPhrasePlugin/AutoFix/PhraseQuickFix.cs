using System;
using JetBrains.Annotations;
using JetBrains.Application.Progress;
using JetBrains.DocumentManagers.Transactions;
using JetBrains.DocumentModel;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Feature.Services.QuickFixes;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.TextControl;
using JetBrains.Util;
using ReSharperPlugin.BadPhrasePlugin.Analysis;

namespace ReSharperPlugin.BadPhrasePlugin.AutoFix;

[QuickFix]
public class PhraseQuickFix : QuickFixBase
{
    private readonly IComment _comment;
    private readonly string _replacement;
    private readonly TextRange _replacementRange;
    private readonly BadPhraseHighlighting _highlighting;
    private int _cumulativeOffsetChange = 0;

    public PhraseQuickFix(BadPhraseHighlighting highlighting)
    {
        _highlighting = highlighting;
        _comment = highlighting.Comment;
        _replacement = highlighting.SuggestedReplacement;
        _replacementRange = highlighting.ReplacementRange;
    }

    public override string Text => $"Replace with {_replacement}.";

    public override bool IsAvailable(IUserDataHolder cache)
    {
        return _comment.IsValid();
    }

    protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
    {
        var document = _comment.GetDocumentRange().Document;

        int originalLength = _replacementRange.Length;
        int replacementLength = _replacement.Length;

        int newStart = CalculateNewStartOffset(_replacementRange.StartOffset);
        int newEnd = newStart + replacementLength;

        document.ReplaceText(new TextRange(newStart, newEnd), _replacement);

        _cumulativeOffsetChange += (replacementLength - originalLength);

        return null;
    }

    private int CalculateNewStartOffset(int originalStart)
    {
        return 2 + originalStart + _cumulativeOffsetChange;
    }
}
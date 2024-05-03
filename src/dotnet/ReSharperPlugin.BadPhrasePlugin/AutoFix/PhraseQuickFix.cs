using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Application.CommandProcessing;
using JetBrains.Application.Progress;
using JetBrains.DocumentManagers;
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

    public PhraseQuickFix(BadPhraseHighlighting highlighting)
    {
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
        return textControl =>
        {
            var document = _comment.GetDocumentRange().Document;
            var range = new TextRange(_replacementRange.StartOffset, _replacementRange.EndOffset);

            document.ReplaceText(range, _replacement);
        };
    }
}
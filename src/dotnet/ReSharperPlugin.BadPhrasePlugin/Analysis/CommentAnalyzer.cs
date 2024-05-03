﻿using System.Linq;
using JetBrains.Annotations;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Util;
using ReSharperPlugin.BadPhrasePlugin.Providers;

namespace ReSharperPlugin.BadPhrasePlugin.Analysis;

[ElementProblemAnalyzer(typeof(IComment), HighlightingTypes =
        [typeof(BadPhraseHighlighting)])]
public class CommentAnalyzer : ElementProblemAnalyzer<IComment>
{
    private readonly PhraseProvider _phraseProvider;

    public CommentAnalyzer(PhraseProvider phraseProvider)
    {
        _phraseProvider = phraseProvider;
    }

    protected override void Run(IComment element, ElementProblemAnalyzerData data, IHighlightingConsumer consumer)
    {
        var comment = element.CommentText;
        var documentRange = element.GetDocumentRange();

        foreach (var phrase in _phraseProvider.GetPhrases().Where(phrase => comment.Contains(phrase.Key)))
        {
            int index = comment.IndexOf(phrase.Key); TextRange textRange = new(documentRange.TextRange.StartOffset + index, documentRange.TextRange.StartOffset + index + phrase.Key.Length);
            consumer.AddHighlighting(new BadPhraseHighlighting(element, phrase.Value, textRange));
        }
    }
}
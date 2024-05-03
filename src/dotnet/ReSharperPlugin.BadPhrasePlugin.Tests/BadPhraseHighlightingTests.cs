using JetBrains.Application.Settings;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.FeaturesTestFramework.Daemon;
using JetBrains.ReSharper.Psi;
using NUnit.Framework;
using ReSharperPlugin.BadPhrasePlugin.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSharperPlugin.BadPhrasePlugin.Tests;

public class BadPhraseHighlightingTests : CSharpHighlightingTestBase
{
    protected override string RelativeTestDataPath => nameof(BadPhraseHighlightingTests);

    protected override bool HighlightingPredicate(
        IHighlighting highlighting,
        IPsiSourceFile sourceFile,
        IContextBoundSettingsStore settingsStore)
    {
        return highlighting is BadPhraseHighlighting;
    }

    [Test] public void Test01() => DoNamedTest();

    [Test] public void Test02() => DoNamedTest();
}
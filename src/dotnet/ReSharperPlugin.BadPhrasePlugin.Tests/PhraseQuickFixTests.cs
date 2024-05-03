using JetBrains.ReSharper.FeaturesTestFramework.Intentions;
using NUnit.Framework;
using ReSharperPlugin.BadPhrasePlugin.AutoFix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSharperPlugin.BadPhrasePlugin.Tests;

public class PhraseQuickFixTests : CSharpQuickFixTestBase<PhraseQuickFix>
{
    protected override string RelativeTestDataPath => nameof(PhraseQuickFixTests);

    [Test]
    public void Test01() => DoNamedTest();
}
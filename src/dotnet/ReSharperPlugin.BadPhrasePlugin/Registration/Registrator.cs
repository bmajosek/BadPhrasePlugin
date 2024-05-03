using JetBrains.ReSharper.Feature.Services.QuickFixes;
using JetBrains.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Lifetimes;
using ReSharperPlugin.BadPhrasePlugin.Analysis;
using ReSharperPlugin.BadPhrasePlugin.AutoFix;

namespace ReSharperPlugin.BadPhrasePlugin.Registration;

public class RegistratorIQuickFixesProvider : IQuickFixesProvider
{
    public void Register(IQuickFixesRegistrar registrar)
    {
        registrar.RegisterQuickFix<BadPhraseHighlighting>(Lifetime.Eternal, h => new PhraseQuickFix(h), typeof(PhraseQuickFix));
    }

    public IEnumerable<Type> Dependencies => EmptyArray<Type>.Instance;
}
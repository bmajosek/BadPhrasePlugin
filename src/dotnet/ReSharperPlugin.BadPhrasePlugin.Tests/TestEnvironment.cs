using System.Threading;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;

[assembly: Apartment(ApartmentState.STA)]

namespace ReSharperPlugin.BadPhrasePlugin.Tests
{
    [ZoneDefinition]
    public class BadPhrasePluginTestEnvironmentZone : ITestsEnvZone, IRequire<PsiFeatureTestZone>, IRequire<IBadPhrasePluginZone> { }

    [ZoneMarker]
    public class ZoneMarker : IRequire<ICodeEditingZone>, IRequire<ILanguageCSharpZone>, IRequire<BadPhrasePluginTestEnvironmentZone> { }

    [SetUpFixture]
    public class BadPhrasePluginTestsAssembly : ExtensionTestEnvironmentAssembly<BadPhrasePluginTestEnvironmentZone> { }
}

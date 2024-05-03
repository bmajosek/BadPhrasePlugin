using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp;

namespace ReSharperPlugin.BadPhrasePlugin
{
    [ZoneDefinition]
    public interface IBadPhrasePluginZone : IZone,
        IRequire<ILanguageCSharpZone>
    {
    }
}
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Psi.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSharperPlugin.BadPhrasePlugin;

[ZoneMarker]
public class ZoneMarker : IRequire<ILanguageCSharpZone>
{ }
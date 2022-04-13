using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Information about amount of glyphs that were rendered with given font.
/// </summary>
public sealed partial class PlatformFontUsage {
/// <summary>
/// Font's family name reported by platform.
/// </summary>
[JsonPropertyName("familyName")]public string FamilyName{get;set;}
/// <summary>
/// Indicates if the font was downloaded or resolved locally.
/// </summary>
[JsonPropertyName("isCustomFont")]public bool IsCustomFont{get;set;}
/// <summary>
/// Amount of glyphs that were rendered with this font.
/// </summary>
[JsonPropertyName("glyphCount")]public double GlyphCount{get;set;}
}

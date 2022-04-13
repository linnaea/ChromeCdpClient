using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Information about font variation axes for variable fonts
/// </summary>
public sealed partial class FontVariationAxis {
/// <summary>
/// The font-variation-setting tag (a.k.a. "axis tag").
/// </summary>
[JsonPropertyName("tag")]public string Tag{get;set;}
/// <summary>
/// Human-readable variation name in the default language (normally, "en").
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// The minimum value (inclusive) the font supports for this tag.
/// </summary>
[JsonPropertyName("minValue")]public double MinValue{get;set;}
/// <summary>
/// The maximum value (inclusive) the font supports for this tag.
/// </summary>
[JsonPropertyName("maxValue")]public double MaxValue{get;set;}
/// <summary>
/// The default value.
/// </summary>
[JsonPropertyName("defaultValue")]public double DefaultValue{get;set;}
}

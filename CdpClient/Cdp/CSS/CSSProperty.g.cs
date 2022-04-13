using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS property declaration data.
/// </summary>
public sealed partial class CSSProperty {
/// <summary>
/// The property name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// The property value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
/// <summary>
/// Whether the property has "!important" annotation (implies `false` if absent).
/// </summary>
[JsonPropertyName("important")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Important{get;set;}
/// <summary>
/// Whether the property is implicit (implies `false` if absent).
/// </summary>
[JsonPropertyName("implicit")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Implicit{get;set;}
/// <summary>
/// The full property text as specified in the style.
/// </summary>
[JsonPropertyName("text")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Text{get;set;}
/// <summary>
/// Whether the property is understood by the browser (implies `true` if absent).
/// </summary>
[JsonPropertyName("parsedOk")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ParsedOk{get;set;}
/// <summary>
/// Whether the property is disabled by the user (present for source-based properties only).
/// </summary>
[JsonPropertyName("disabled")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Disabled{get;set;}
/// <summary>
/// The entire property range in the enclosing style declaration (if available).
/// </summary>
[JsonPropertyName("range")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SourceRange? Range{get;set;}
}

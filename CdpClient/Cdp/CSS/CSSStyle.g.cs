using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS style representation.
/// </summary>
public sealed partial class CSSStyle {
/// <summary>
/// The css style sheet identifier (absent for user agent stylesheet and user-specified
/// stylesheet rules) this rule came from.
/// </summary>
[JsonPropertyName("styleSheetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public StyleSheetId? StyleSheetId{get;set;}
/// <summary>
/// CSS properties in the style.
/// </summary>
[JsonPropertyName("cssProperties")]public CSSProperty[] CssProperties{get;set;}
/// <summary>
/// Computed values for all shorthands found in the style.
/// </summary>
[JsonPropertyName("shorthandEntries")]public ShorthandEntry[] ShorthandEntries{get;set;}
/// <summary>
/// Style declaration text (if available).
/// </summary>
[JsonPropertyName("cssText")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? CssText{get;set;}
/// <summary>
/// Style declaration range in the enclosing stylesheet (if available).
/// </summary>
[JsonPropertyName("range")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SourceRange? Range{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS rule representation.
/// </summary>
public sealed partial class CSSRule {
/// <summary>
/// The css style sheet identifier (absent for user agent stylesheet and user-specified
/// stylesheet rules) this rule came from.
/// </summary>
[JsonPropertyName("styleSheetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public StyleSheetId? StyleSheetId{get;set;}
/// <summary>
/// Rule selector data.
/// </summary>
[JsonPropertyName("selectorList")]public SelectorList SelectorList{get;set;}
/// <summary>
/// Parent stylesheet's origin.
/// </summary>
[JsonPropertyName("origin")]public StyleSheetOrigin Origin{get;set;}
/// <summary>
/// Associated style declaration.
/// </summary>
[JsonPropertyName("style")]public CSSStyle Style{get;set;}
/// <summary>
/// Media list array (for rules involving media queries). The array enumerates media queries
/// starting with the innermost one, going outwards.
/// </summary>
[JsonPropertyName("media")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSSMedia[]? Media{get;set;}
/// <summary>
/// Container query list array (for rules involving container queries).
/// The array enumerates container queries starting with the innermost one, going outwards.
/// </summary>
[Experimental][JsonPropertyName("containerQueries")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSSContainerQuery[]? ContainerQueries{get;set;}
/// <summary>
/// @supports CSS at-rule array.
/// The array enumerates @supports at-rules starting with the innermost one, going outwards.
/// </summary>
[Experimental][JsonPropertyName("supports")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSSSupports[]? Supports{get;set;}
/// <summary>
/// Cascade layer array. Contains the layer hierarchy that this rule belongs to starting
/// with the innermost layer and going outwards.
/// </summary>
[Experimental][JsonPropertyName("layers")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSSLayer[]? Layers{get;set;}
}

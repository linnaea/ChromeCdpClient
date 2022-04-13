using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS keyframe rule representation.
/// </summary>
public sealed partial class CSSKeyframeRule {
/// <summary>
/// The css style sheet identifier (absent for user agent stylesheet and user-specified
/// stylesheet rules) this rule came from.
/// </summary>
[JsonPropertyName("styleSheetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public StyleSheetId? StyleSheetId{get;set;}
/// <summary>
/// Parent stylesheet's origin.
/// </summary>
[JsonPropertyName("origin")]public StyleSheetOrigin Origin{get;set;}
/// <summary>
/// Associated key text.
/// </summary>
[JsonPropertyName("keyText")]public Value KeyText{get;set;}
/// <summary>
/// Associated style declaration.
/// </summary>
[JsonPropertyName("style")]public CSSStyle Style{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Inherited CSS rule collection from ancestor node.
/// </summary>
public sealed partial class InheritedStyleEntry {
/// <summary>
/// The ancestor node's inline style, if any, in the style inheritance chain.
/// </summary>
[JsonPropertyName("inlineStyle")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSSStyle? InlineStyle{get;set;}
/// <summary>
/// Matches of CSS rules matching the ancestor node in the style inheritance chain.
/// </summary>
[JsonPropertyName("matchedCSSRules")]public RuleMatch[] MatchedCSSRules{get;set;}
}

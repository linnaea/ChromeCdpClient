using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Match data for a CSS rule.
/// </summary>
public sealed partial class RuleMatch {
/// <summary>
/// CSS rule in the match.
/// </summary>
[JsonPropertyName("rule")]public CSSRule Rule{get;set;}
/// <summary>
/// Matching selector indices in the rule's selectorList selectors (0-based).
/// </summary>
[JsonPropertyName("matchingSelectors")]public long[] MatchingSelectors{get;set;}
}

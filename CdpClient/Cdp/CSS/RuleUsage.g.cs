using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS coverage information.
/// </summary>
public sealed partial class RuleUsage {
/// <summary>
/// The css style sheet identifier (absent for user agent stylesheet and user-specified
/// stylesheet rules) this rule came from.
/// </summary>
[JsonPropertyName("styleSheetId")]public StyleSheetId StyleSheetId{get;set;}
/// <summary>
/// Offset of the start of the rule (including selector) from the beginning of the stylesheet.
/// </summary>
[JsonPropertyName("startOffset")]public double StartOffset{get;set;}
/// <summary>
/// Offset of the end of the rule body from the beginning of the stylesheet.
/// </summary>
[JsonPropertyName("endOffset")]public double EndOffset{get;set;}
/// <summary>
/// Indicates whether the rule was actually used by some element in the page.
/// </summary>
[JsonPropertyName("used")]public bool Used{get;set;}
}

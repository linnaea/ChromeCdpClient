using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS rule collection for a single pseudo style.
/// </summary>
public sealed partial class PseudoElementMatches {
/// <summary>
/// Pseudo element type.
/// </summary>
[JsonPropertyName("pseudoType")]public DOM.PseudoType PseudoType{get;set;}
/// <summary>
/// Matches of CSS rules applicable to the pseudo style.
/// </summary>
[JsonPropertyName("matches")]public RuleMatch[] Matches{get;set;}
}

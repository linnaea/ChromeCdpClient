using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Inherited pseudo element matches from pseudos of an ancestor node.
/// </summary>
public sealed partial class InheritedPseudoElementMatches {
/// <summary>
/// Matches of pseudo styles from the pseudos of an ancestor node.
/// </summary>
[JsonPropertyName("pseudoElements")]public PseudoElementMatches[] PseudoElements{get;set;}
}

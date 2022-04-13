using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Selector list data.
/// </summary>
public sealed partial class SelectorList {
/// <summary>
/// Selectors in the list.
/// </summary>
[JsonPropertyName("selectors")]public Value[] Selectors{get;set;}
/// <summary>
/// Rule selector text.
/// </summary>
[JsonPropertyName("text")]public string Text{get;set;}
}

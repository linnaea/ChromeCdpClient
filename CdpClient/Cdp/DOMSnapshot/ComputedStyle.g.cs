using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
/// <summary>
/// A subset of the full ComputedStyle as defined by the request whitelist.
/// </summary>
public sealed partial class ComputedStyle {
/// <summary>
/// Name/value pairs of computed style properties.
/// </summary>
[JsonPropertyName("properties")]public NameValue[] Properties{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
public sealed partial class CSSComputedStyleProperty {
/// <summary>
/// Computed style property name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Computed style property value.
/// </summary>
[JsonPropertyName("value")]public string Value{get;set;}
}

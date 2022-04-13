using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Accessibility;
public sealed partial class AXProperty {
/// <summary>
/// The name of this property.
/// </summary>
[JsonPropertyName("name")]public AXPropertyName Name{get;set;}
/// <summary>
/// The value of this property.
/// </summary>
[JsonPropertyName("value")]public AXValue Value{get;set;}
}

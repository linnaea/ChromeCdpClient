using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS Layer data.
/// </summary>
[Experimental]public sealed partial class CSSLayerData {
/// <summary>
/// Layer name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Direct sub-layers
/// </summary>
[JsonPropertyName("subLayers")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CSSLayerData[]? SubLayers{get;set;}
/// <summary>
/// Layer order. The order determines the order of the layer in the cascade order.
/// A higher number has higher priority in the cascade order.
/// </summary>
[JsonPropertyName("order")]public double Order{get;set;}
}

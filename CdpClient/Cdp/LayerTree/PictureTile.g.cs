using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.LayerTree;
/// <summary>
/// Serialized fragment of layer picture along with its offset within the layer.
/// </summary>
public sealed partial class PictureTile {
/// <summary>
/// Offset from owning layer left boundary
/// </summary>
[JsonPropertyName("x")]public double X{get;set;}
/// <summary>
/// Offset from owning layer top boundary
/// </summary>
[JsonPropertyName("y")]public double Y{get;set;}
/// <summary>
/// Base64-encoded snapshot data. (Encoded as a base64 string when passed over JSON)
/// </summary>
[JsonPropertyName("picture")]public string Picture{get;set;}
}

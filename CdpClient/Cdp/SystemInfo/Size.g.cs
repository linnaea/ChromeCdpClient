using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.SystemInfo;
/// <summary>
/// Describes the width and height dimensions of an entity.
/// </summary>
public sealed partial class Size {
/// <summary>
/// Width in pixels.
/// </summary>
[JsonPropertyName("width")]public long Width{get;set;}
/// <summary>
/// Height in pixels.
/// </summary>
[JsonPropertyName("height")]public long Height{get;set;}
}

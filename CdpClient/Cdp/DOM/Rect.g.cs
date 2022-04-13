using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// Rectangle.
/// </summary>
public sealed partial class Rect {
/// <summary>
/// X coordinate
/// </summary>
[JsonPropertyName("x")]public double X{get;set;}
/// <summary>
/// Y coordinate
/// </summary>
[JsonPropertyName("y")]public double Y{get;set;}
/// <summary>
/// Rectangle width
/// </summary>
[JsonPropertyName("width")]public double Width{get;set;}
/// <summary>
/// Rectangle height
/// </summary>
[JsonPropertyName("height")]public double Height{get;set;}
}

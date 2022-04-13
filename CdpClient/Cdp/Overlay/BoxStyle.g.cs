using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
/// <summary>
/// Style information for drawing a box.
/// </summary>
public sealed partial class BoxStyle {
/// <summary>
/// The background color for the box (default: transparent)
/// </summary>
[JsonPropertyName("fillColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? FillColor{get;set;}
/// <summary>
/// The hatching color for the box (default: transparent)
/// </summary>
[JsonPropertyName("hatchColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? HatchColor{get;set;}
}

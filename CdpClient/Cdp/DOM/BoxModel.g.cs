using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// Box model.
/// </summary>
public sealed partial class BoxModel {
/// <summary>
/// Content box
/// </summary>
[JsonPropertyName("content")]public Quad Content{get;set;}
/// <summary>
/// Padding box
/// </summary>
[JsonPropertyName("padding")]public Quad Padding{get;set;}
/// <summary>
/// Border box
/// </summary>
[JsonPropertyName("border")]public Quad Border{get;set;}
/// <summary>
/// Margin box
/// </summary>
[JsonPropertyName("margin")]public Quad Margin{get;set;}
/// <summary>
/// Node width
/// </summary>
[JsonPropertyName("width")]public long Width{get;set;}
/// <summary>
/// Node height
/// </summary>
[JsonPropertyName("height")]public long Height{get;set;}
/// <summary>
/// Shape outside coordinates
/// </summary>
[JsonPropertyName("shapeOutside")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ShapeOutsideInfo? ShapeOutside{get;set;}
}

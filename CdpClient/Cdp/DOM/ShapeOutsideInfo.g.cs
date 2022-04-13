using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// CSS Shape Outside details.
/// </summary>
public sealed partial class ShapeOutsideInfo {
/// <summary>
/// Shape bounds
/// </summary>
[JsonPropertyName("bounds")]public Quad Bounds{get;set;}
/// <summary>
/// Shape coordinate details
/// </summary>
[JsonPropertyName("shape")]public object[] Shape{get;set;}
/// <summary>
/// Margin shape bounds
/// </summary>
[JsonPropertyName("marginShape")]public object[] MarginShape{get;set;}
}

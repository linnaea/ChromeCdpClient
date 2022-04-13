using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
/// <summary>
/// Configuration data for drawing the source order of an elements children.
/// </summary>
public sealed partial class SourceOrderConfig {
/// <summary>
/// the color to outline the givent element in.
/// </summary>
[JsonPropertyName("parentOutlineColor")]public DOM.RGBA ParentOutlineColor{get;set;}
/// <summary>
/// the color to outline the child elements in.
/// </summary>
[JsonPropertyName("childOutlineColor")]public DOM.RGBA ChildOutlineColor{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Viewport for capturing screenshot.
/// </summary>
public sealed partial class Viewport {
/// <summary>
/// X offset in device independent pixels (dip).
/// </summary>
[JsonPropertyName("x")]public double X{get;set;}
/// <summary>
/// Y offset in device independent pixels (dip).
/// </summary>
[JsonPropertyName("y")]public double Y{get;set;}
/// <summary>
/// Rectangle width in device independent pixels (dip).
/// </summary>
[JsonPropertyName("width")]public double Width{get;set;}
/// <summary>
/// Rectangle height in device independent pixels (dip).
/// </summary>
[JsonPropertyName("height")]public double Height{get;set;}
/// <summary>
/// Page scale factor.
/// </summary>
[JsonPropertyName("scale")]public double Scale{get;set;}
}

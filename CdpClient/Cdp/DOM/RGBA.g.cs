using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// A structure holding an RGBA color.
/// </summary>
public sealed partial class RGBA {
/// <summary>
/// The red component, in the [0-255] range.
/// </summary>
[JsonPropertyName("r")]public long R{get;set;}
/// <summary>
/// The green component, in the [0-255] range.
/// </summary>
[JsonPropertyName("g")]public long G{get;set;}
/// <summary>
/// The blue component, in the [0-255] range.
/// </summary>
[JsonPropertyName("b")]public long B{get;set;}
/// <summary>
/// The alpha component, in the [0-1] range (default: 1).
/// </summary>
[JsonPropertyName("a")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? A{get;set;}
}

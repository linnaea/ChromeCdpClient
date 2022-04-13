using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Profiler;
/// <summary>
/// Specifies a number of samples attributed to a certain source position.
/// </summary>
public sealed partial class PositionTickInfo {
/// <summary>
/// Source line number (1-based).
/// </summary>
[JsonPropertyName("line")]public long Line{get;set;}
/// <summary>
/// Number of samples attributed to the source line.
/// </summary>
[JsonPropertyName("ticks")]public long Ticks{get;set;}
}

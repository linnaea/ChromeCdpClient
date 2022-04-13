using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Profiler;
/// <summary>
/// Profile.
/// </summary>
public sealed partial class Profile {
/// <summary>
/// The list of profile nodes. First item is the root node.
/// </summary>
[JsonPropertyName("nodes")]public ProfileNode[] Nodes{get;set;}
/// <summary>
/// Profiling start timestamp in microseconds.
/// </summary>
[JsonPropertyName("startTime")]public double StartTime{get;set;}
/// <summary>
/// Profiling end timestamp in microseconds.
/// </summary>
[JsonPropertyName("endTime")]public double EndTime{get;set;}
/// <summary>
/// Ids of samples top nodes.
/// </summary>
[JsonPropertyName("samples")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long[]? Samples{get;set;}
/// <summary>
/// Time intervals between adjacent samples in microseconds. The first delta is relative to the
/// profile startTime.
/// </summary>
[JsonPropertyName("timeDeltas")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long[]? TimeDeltas{get;set;}
}

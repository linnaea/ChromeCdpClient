using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.HeapProfiler;
/// <summary>
/// A single sample from a sampling profile.
/// </summary>
public sealed partial class SamplingHeapProfileSample {
/// <summary>
/// Allocation size in bytes attributed to the sample.
/// </summary>
[JsonPropertyName("size")]public double Size{get;set;}
/// <summary>
/// Id of the corresponding profile tree node.
/// </summary>
[JsonPropertyName("nodeId")]public long NodeId{get;set;}
/// <summary>
/// Time-ordered sample ordinal number. It is unique across all profiles retrieved
/// between startSampling and stopSampling.
/// </summary>
[JsonPropertyName("ordinal")]public double Ordinal{get;set;}
}

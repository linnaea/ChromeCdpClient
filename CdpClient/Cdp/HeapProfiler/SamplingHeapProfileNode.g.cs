using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.HeapProfiler;
/// <summary>
/// Sampling Heap Profile node. Holds callsite information, allocation statistics and child nodes.
/// </summary>
public sealed partial class SamplingHeapProfileNode {
/// <summary>
/// Function location.
/// </summary>
[JsonPropertyName("callFrame")]public Runtime.CallFrame CallFrame{get;set;}
/// <summary>
/// Allocations size in bytes for the node excluding children.
/// </summary>
[JsonPropertyName("selfSize")]public double SelfSize{get;set;}
/// <summary>
/// Node id. Ids are unique across all profiles collected between startSampling and stopSampling.
/// </summary>
[JsonPropertyName("id")]public long Id{get;set;}
/// <summary>
/// Child nodes.
/// </summary>
[JsonPropertyName("children")]public SamplingHeapProfileNode[] Children{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.HeapProfiler;
/// <summary>
/// Sampling profile.
/// </summary>
public sealed partial class SamplingHeapProfile {
[JsonPropertyName("head")]public SamplingHeapProfileNode Head{get;set;}
[JsonPropertyName("samples")]public SamplingHeapProfileSample[] Samples{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Memory;
/// <summary>
/// Heap profile sample.
/// </summary>
public sealed partial class SamplingProfileNode {
/// <summary>
/// Size of the sampled allocation.
/// </summary>
[JsonPropertyName("size")]public double Size{get;set;}
/// <summary>
/// Total bytes attributed to this sample.
/// </summary>
[JsonPropertyName("total")]public double Total{get;set;}
/// <summary>
/// Execution stack at the point of allocation.
/// </summary>
[JsonPropertyName("stack")]public string[] Stack{get;set;}
}

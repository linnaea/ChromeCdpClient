using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.SystemInfo;
/// <summary>
/// Represents process info.
/// </summary>
public sealed partial class ProcessInfo {
/// <summary>
/// Specifies process type.
/// </summary>
[JsonPropertyName("type")]public string Type{get;set;}
/// <summary>
/// Specifies process id.
/// </summary>
[JsonPropertyName("id")]public long Id{get;set;}
/// <summary>
/// Specifies cumulative CPU usage in seconds across all threads of the
/// process since the process start.
/// </summary>
[JsonPropertyName("cpuTime")]public double CpuTime{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Performance;
/// <summary>
/// Run-time execution metric.
/// </summary>
public sealed partial class Metric {
/// <summary>
/// Metric name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Metric value.
/// </summary>
[JsonPropertyName("value")]public double Value{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Browser;
/// <summary>
/// Chrome histogram.
/// </summary>
[Experimental]public sealed partial class Histogram {
/// <summary>
/// Name.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// Sum of sample values.
/// </summary>
[JsonPropertyName("sum")]public long Sum{get;set;}
/// <summary>
/// Total number of samples.
/// </summary>
[JsonPropertyName("count")]public long Count{get;set;}
/// <summary>
/// Buckets.
/// </summary>
[JsonPropertyName("buckets")]public Bucket[] Buckets{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Browser;
/// <summary>
/// Chrome histogram bucket.
/// </summary>
[Experimental]public sealed partial class Bucket {
/// <summary>
/// Minimum value (inclusive).
/// </summary>
[JsonPropertyName("low")]public long Low{get;set;}
/// <summary>
/// Maximum value (exclusive).
/// </summary>
[JsonPropertyName("high")]public long High{get;set;}
/// <summary>
/// Number of samples.
/// </summary>
[JsonPropertyName("count")]public long Count{get;set;}
}

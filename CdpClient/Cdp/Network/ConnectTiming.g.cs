using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental]public sealed partial class ConnectTiming {
/// <summary>
/// Timing's requestTime is a baseline in seconds, while the other numbers are ticks in
/// milliseconds relatively to this requestTime. Matches ResourceTiming's requestTime for
/// the same request (but not for redirected requests).
/// </summary>
[JsonPropertyName("requestTime")]public double RequestTime{get;set;}
}

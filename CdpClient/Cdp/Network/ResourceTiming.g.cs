using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Timing information for the request.
/// </summary>
public sealed partial class ResourceTiming {
/// <summary>
/// Timing's requestTime is a baseline in seconds, while the other numbers are ticks in
/// milliseconds relatively to this requestTime.
/// </summary>
[JsonPropertyName("requestTime")]public double RequestTime{get;set;}
/// <summary>
/// Started resolving proxy.
/// </summary>
[JsonPropertyName("proxyStart")]public double ProxyStart{get;set;}
/// <summary>
/// Finished resolving proxy.
/// </summary>
[JsonPropertyName("proxyEnd")]public double ProxyEnd{get;set;}
/// <summary>
/// Started DNS address resolve.
/// </summary>
[JsonPropertyName("dnsStart")]public double DnsStart{get;set;}
/// <summary>
/// Finished DNS address resolve.
/// </summary>
[JsonPropertyName("dnsEnd")]public double DnsEnd{get;set;}
/// <summary>
/// Started connecting to the remote host.
/// </summary>
[JsonPropertyName("connectStart")]public double ConnectStart{get;set;}
/// <summary>
/// Connected to the remote host.
/// </summary>
[JsonPropertyName("connectEnd")]public double ConnectEnd{get;set;}
/// <summary>
/// Started SSL handshake.
/// </summary>
[JsonPropertyName("sslStart")]public double SslStart{get;set;}
/// <summary>
/// Finished SSL handshake.
/// </summary>
[JsonPropertyName("sslEnd")]public double SslEnd{get;set;}
/// <summary>
/// Started running ServiceWorker.
/// </summary>
[Experimental][JsonPropertyName("workerStart")]public double WorkerStart{get;set;}
/// <summary>
/// Finished Starting ServiceWorker.
/// </summary>
[Experimental][JsonPropertyName("workerReady")]public double WorkerReady{get;set;}
/// <summary>
/// Started fetch event.
/// </summary>
[Experimental][JsonPropertyName("workerFetchStart")]public double WorkerFetchStart{get;set;}
/// <summary>
/// Settled fetch event respondWith promise.
/// </summary>
[Experimental][JsonPropertyName("workerRespondWithSettled")]public double WorkerRespondWithSettled{get;set;}
/// <summary>
/// Started sending request.
/// </summary>
[JsonPropertyName("sendStart")]public double SendStart{get;set;}
/// <summary>
/// Finished sending request.
/// </summary>
[JsonPropertyName("sendEnd")]public double SendEnd{get;set;}
/// <summary>
/// Time the server started pushing request.
/// </summary>
[Experimental][JsonPropertyName("pushStart")]public double PushStart{get;set;}
/// <summary>
/// Time the server finished pushing request.
/// </summary>
[Experimental][JsonPropertyName("pushEnd")]public double PushEnd{get;set;}
/// <summary>
/// Finished receiving response headers.
/// </summary>
[JsonPropertyName("receiveHeadersEnd")]public double ReceiveHeadersEnd{get;set;}
}

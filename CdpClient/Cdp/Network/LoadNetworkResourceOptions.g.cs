using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// An options object that may be extended later to better support CORS,
/// CORB and streaming.
/// </summary>
[Experimental]public sealed partial class LoadNetworkResourceOptions {
[JsonPropertyName("disableCache")]public bool DisableCache{get;set;}
[JsonPropertyName("includeCredentials")]public bool IncludeCredentials{get;set;}
}

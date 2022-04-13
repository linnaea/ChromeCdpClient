using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Target;
[Experimental]public sealed partial class RemoteLocation {
[JsonPropertyName("host")]public string Host{get;set;}
[JsonPropertyName("port")]public long Port{get;set;}
}

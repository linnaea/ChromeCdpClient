using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental]public sealed partial class SecurityIsolationStatus {
[JsonPropertyName("coop")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CrossOriginOpenerPolicyStatus? Coop{get;set;}
[JsonPropertyName("coep")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CrossOriginEmbedderPolicyStatus? Coep{get;set;}
}

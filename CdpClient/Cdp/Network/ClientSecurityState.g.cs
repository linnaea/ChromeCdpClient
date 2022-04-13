using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental]public sealed partial class ClientSecurityState {
[JsonPropertyName("initiatorIsSecureContext")]public bool InitiatorIsSecureContext{get;set;}
[JsonPropertyName("initiatorIPAddressSpace")]public IPAddressSpace InitiatorIPAddressSpace{get;set;}
[JsonPropertyName("privateNetworkRequestPolicy")]public PrivateNetworkRequestPolicy PrivateNetworkRequestPolicy{get;set;}
}

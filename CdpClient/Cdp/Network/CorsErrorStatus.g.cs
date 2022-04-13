using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
public sealed partial class CorsErrorStatus {
[JsonPropertyName("corsError")]public CorsError CorsError{get;set;}
[JsonPropertyName("failedParameter")]public string FailedParameter{get;set;}
}

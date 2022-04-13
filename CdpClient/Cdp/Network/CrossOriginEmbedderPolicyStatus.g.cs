using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental]public sealed partial class CrossOriginEmbedderPolicyStatus {
[JsonPropertyName("value")]public CrossOriginEmbedderPolicyValue Value{get;set;}
[JsonPropertyName("reportOnlyValue")]public CrossOriginEmbedderPolicyValue ReportOnlyValue{get;set;}
[JsonPropertyName("reportingEndpoint")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ReportingEndpoint{get;set;}
[JsonPropertyName("reportOnlyReportingEndpoint")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? ReportOnlyReportingEndpoint{get;set;}
}

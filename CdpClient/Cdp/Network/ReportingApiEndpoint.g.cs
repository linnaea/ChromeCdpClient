using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental]public sealed partial class ReportingApiEndpoint {
/// <summary>
/// The URL of the endpoint to which reports may be delivered.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Name of the endpoint group.
/// </summary>
[JsonPropertyName("groupName")]public string GroupName{get;set;}
}

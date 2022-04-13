using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Information about a cookie that is affected by an inspector issue.
/// </summary>
public sealed partial class AffectedCookie {
/// <summary>
/// The following three properties uniquely identify a cookie
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
[JsonPropertyName("path")]public string Path{get;set;}
[JsonPropertyName("domain")]public string Domain{get;set;}
}

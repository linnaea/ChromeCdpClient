using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Parsed app manifest properties.
/// </summary>
[Experimental]public sealed partial class AppManifestParsedProperties {
/// <summary>
/// Computed scope value
/// </summary>
[JsonPropertyName("scope")]public string Scope{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Error while paring app manifest.
/// </summary>
public sealed partial class AppManifestError {
/// <summary>
/// Error message.
/// </summary>
[JsonPropertyName("message")]public string Message{get;set;}
/// <summary>
/// If criticial, this is a non-recoverable parse error.
/// </summary>
[JsonPropertyName("critical")]public long Critical{get;set;}
/// <summary>
/// Error line.
/// </summary>
[JsonPropertyName("line")]public long Line{get;set;}
/// <summary>
/// Error column.
/// </summary>
[JsonPropertyName("column")]public long Column{get;set;}
}

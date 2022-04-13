using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Post data entry for HTTP request
/// </summary>
public sealed partial class PostDataEntry {
[JsonPropertyName("bytes")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Bytes{get;set;}
}

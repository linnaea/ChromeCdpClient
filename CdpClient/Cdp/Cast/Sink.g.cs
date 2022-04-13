using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Cast;
public sealed partial class Sink {
[JsonPropertyName("name")]public string Name{get;set;}
[JsonPropertyName("id")]public string Id{get;set;}
/// <summary>
/// Text describing the current session. Present only if there is an active
/// session on the sink.
/// </summary>
[JsonPropertyName("session")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Session{get;set;}
}

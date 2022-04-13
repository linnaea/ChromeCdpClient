using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.BackgroundService;
/// <summary>
/// A key-value pair for additional event information to pass along.
/// </summary>
public sealed partial class EventMetadata {
[JsonPropertyName("key")]public string Key{get;set;}
[JsonPropertyName("value")]public string Value{get;set;}
}

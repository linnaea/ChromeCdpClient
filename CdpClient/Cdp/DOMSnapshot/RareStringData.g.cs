using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
/// <summary>
/// Data that is only present on rare nodes.
/// </summary>
public sealed partial class RareStringData {
[JsonPropertyName("index")]public long[] Index{get;set;}
[JsonPropertyName("value")]public StringIndex[] Value{get;set;}
}

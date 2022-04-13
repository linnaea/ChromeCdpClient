using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
public sealed partial class RareIntegerData {
[JsonPropertyName("index")]public long[] Index{get;set;}
[JsonPropertyName("value")]public long[] Value{get;set;}
}

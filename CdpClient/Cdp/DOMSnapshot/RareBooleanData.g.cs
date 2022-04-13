using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
public sealed partial class RareBooleanData {
[JsonPropertyName("index")]public long[] Index{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Emulation;
public sealed partial class MediaFeature {
[JsonPropertyName("name")]public string Name{get;set;}
[JsonPropertyName("value")]public string Value{get;set;}
}

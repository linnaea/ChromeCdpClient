using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Memory;
/// <summary>
/// Array of heap profile samples.
/// </summary>
public sealed partial class SamplingProfile {
[JsonPropertyName("samples")]public SamplingProfileNode[] Samples{get;set;}
[JsonPropertyName("modules")]public Module[] Modules{get;set;}
}

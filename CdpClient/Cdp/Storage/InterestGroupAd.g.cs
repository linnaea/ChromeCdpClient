using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Storage;
/// <summary>
/// Ad advertising element inside an interest group.
/// </summary>
public sealed partial class InterestGroupAd {
[JsonPropertyName("renderUrl")]public string RenderUrl{get;set;}
[JsonPropertyName("metadata")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Metadata{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
[Experimental]public sealed partial class EntryPreview {
/// <summary>
/// Preview of the key. Specified for map-like collection entries.
/// </summary>
[JsonPropertyName("key")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ObjectPreview? Key{get;set;}
/// <summary>
/// Preview of the value.
/// </summary>
[JsonPropertyName("value")]public ObjectPreview Value{get;set;}
}

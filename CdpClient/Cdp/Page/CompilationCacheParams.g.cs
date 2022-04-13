using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Per-script compilation cache parameters for `Page.produceCompilationCache`
/// </summary>
[Experimental]public sealed partial class CompilationCacheParams {
/// <summary>
/// The URL of the script to produce a compilation cache entry for.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// A hint to the backend whether eager compilation is recommended.
/// (the actual compilation mode used is upon backend discretion).
/// </summary>
[JsonPropertyName("eager")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Eager{get;set;}
}

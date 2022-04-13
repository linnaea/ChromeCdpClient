using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Profiler;
/// <summary>
/// Type profile data collected during runtime for a JavaScript script.
/// </summary>
[Experimental]public sealed partial class ScriptTypeProfile {
/// <summary>
/// JavaScript script id.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
/// <summary>
/// JavaScript script name or url.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Type profile entries for parameters and return values of the functions in the script.
/// </summary>
[JsonPropertyName("entries")]public TypeProfileEntry[] Entries{get;set;}
}

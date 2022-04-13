using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Profiler;
/// <summary>
/// Coverage data for a JavaScript script.
/// </summary>
public sealed partial class ScriptCoverage {
/// <summary>
/// JavaScript script id.
/// </summary>
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
/// <summary>
/// JavaScript script name or url.
/// </summary>
[JsonPropertyName("url")]public string Url{get;set;}
/// <summary>
/// Functions contained in the script that has coverage data.
/// </summary>
[JsonPropertyName("functions")]public FunctionCoverage[] Functions{get;set;}
}

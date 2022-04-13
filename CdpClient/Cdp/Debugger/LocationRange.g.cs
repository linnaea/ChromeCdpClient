using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Debugger;
/// <summary>
/// Location range within one script.
/// </summary>
[Experimental]public sealed partial class LocationRange {
[JsonPropertyName("scriptId")]public Runtime.ScriptId ScriptId{get;set;}
[JsonPropertyName("start")]public ScriptPosition Start{get;set;}
[JsonPropertyName("end")]public ScriptPosition End{get;set;}
}

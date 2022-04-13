using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// If `debuggerId` is set stack trace comes from another debugger and can be resolved there. This
/// allows to track cross-debugger calls. See `Runtime.StackTrace` and `Debugger.paused` for usages.
/// </summary>
[Experimental]public sealed partial class StackTraceId {
[JsonPropertyName("id")]public string Id{get;set;}
[JsonPropertyName("debuggerId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public UniqueDebuggerId? DebuggerId{get;set;}
}

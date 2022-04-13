using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Call frames for assertions or error messages.
/// </summary>
public sealed partial class StackTrace {
/// <summary>
/// String label of this stack trace. For async traces this may be a name of the function that
/// initiated the async call.
/// </summary>
[JsonPropertyName("description")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Description{get;set;}
/// <summary>
/// JavaScript function name.
/// </summary>
[JsonPropertyName("callFrames")]public CallFrame[] CallFrames{get;set;}
/// <summary>
/// Asynchronous JavaScript stack trace that preceded this stack, if available.
/// </summary>
[JsonPropertyName("parent")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public StackTrace? Parent{get;set;}
/// <summary>
/// Asynchronous JavaScript stack trace that preceded this stack, if available.
/// </summary>
[Experimental][JsonPropertyName("parentId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public StackTraceId? ParentId{get;set;}
}

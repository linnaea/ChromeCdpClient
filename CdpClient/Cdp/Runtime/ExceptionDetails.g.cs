using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Detailed information about exception (or error) that was thrown during script compilation or
/// execution.
/// </summary>
public sealed partial class ExceptionDetails {
/// <summary>
/// Exception id.
/// </summary>
[JsonPropertyName("exceptionId")]public long ExceptionId{get;set;}
/// <summary>
/// Exception text, which should be used together with exception object when available.
/// </summary>
[JsonPropertyName("text")]public string Text{get;set;}
/// <summary>
/// Line number of the exception location (0-based).
/// </summary>
[JsonPropertyName("lineNumber")]public long LineNumber{get;set;}
/// <summary>
/// Column number of the exception location (0-based).
/// </summary>
[JsonPropertyName("columnNumber")]public long ColumnNumber{get;set;}
/// <summary>
/// Script ID of the exception location.
/// </summary>
[JsonPropertyName("scriptId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ScriptId? ScriptId{get;set;}
/// <summary>
/// URL of the exception location, to be used when the script was not reported.
/// </summary>
[JsonPropertyName("url")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Url{get;set;}
/// <summary>
/// JavaScript stack trace if available.
/// </summary>
[JsonPropertyName("stackTrace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public StackTrace? StackTrace{get;set;}
/// <summary>
/// Exception object if available.
/// </summary>
[JsonPropertyName("exception")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObject? Exception{get;set;}
/// <summary>
/// Identifier of the context where exception happened.
/// </summary>
[JsonPropertyName("executionContextId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ExecutionContextId? ExecutionContextId{get;set;}
/// <summary>
/// Dictionary with entries of meta data that the client associated
/// with this exception, such as information about associated network
/// requests, etc.
/// </summary>
[Experimental][JsonPropertyName("exceptionMetaData")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object? ExceptionMetaData{get;set;}
}

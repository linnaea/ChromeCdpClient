using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
public sealed partial class SourceCodeLocation {
[JsonPropertyName("scriptId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Runtime.ScriptId? ScriptId{get;set;}
[JsonPropertyName("url")]public string Url{get;set;}
[JsonPropertyName("lineNumber")]public long LineNumber{get;set;}
[JsonPropertyName("columnNumber")]public long ColumnNumber{get;set;}
}

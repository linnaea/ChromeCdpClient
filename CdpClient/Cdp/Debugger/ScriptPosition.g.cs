using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Debugger;
/// <summary>
/// Location in the source code.
/// </summary>
[Experimental]public sealed partial class ScriptPosition {
[JsonPropertyName("lineNumber")]public long LineNumber{get;set;}
[JsonPropertyName("columnNumber")]public long ColumnNumber{get;set;}
}

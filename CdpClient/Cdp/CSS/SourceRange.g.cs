using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Text range within a resource. All numbers are zero-based.
/// </summary>
public sealed partial class SourceRange {
/// <summary>
/// Start line of range.
/// </summary>
[JsonPropertyName("startLine")]public long StartLine{get;set;}
/// <summary>
/// Start column of range (inclusive).
/// </summary>
[JsonPropertyName("startColumn")]public long StartColumn{get;set;}
/// <summary>
/// End line of range
/// </summary>
[JsonPropertyName("endLine")]public long EndLine{get;set;}
/// <summary>
/// End column of range (exclusive).
/// </summary>
[JsonPropertyName("endColumn")]public long EndColumn{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Data for a simple selector (these are delimited by commas in a selector list).
/// </summary>
public sealed partial class Value {
/// <summary>
/// Value text.
/// </summary>
[JsonPropertyName("text")]public string Text{get;set;}
/// <summary>
/// Value range in the underlying resource (if available).
/// </summary>
[JsonPropertyName("range")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SourceRange? Range{get;set;}
}

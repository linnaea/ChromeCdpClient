using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS container query rule descriptor.
/// </summary>
[Experimental]public sealed partial class CSSContainerQuery {
/// <summary>
/// Container query text.
/// </summary>
[JsonPropertyName("text")]public string Text{get;set;}
/// <summary>
/// The associated rule header range in the enclosing stylesheet (if
/// available).
/// </summary>
[JsonPropertyName("range")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public SourceRange? Range{get;set;}
/// <summary>
/// Identifier of the stylesheet containing this object (if exists).
/// </summary>
[JsonPropertyName("styleSheetId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public StyleSheetId? StyleSheetId{get;set;}
/// <summary>
/// Optional name for the container.
/// </summary>
[JsonPropertyName("name")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Name{get;set;}
}

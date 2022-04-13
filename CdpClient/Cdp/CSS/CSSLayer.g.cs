using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS Layer at-rule descriptor.
/// </summary>
[Experimental]public sealed partial class CSSLayer {
/// <summary>
/// Layer name.
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
}

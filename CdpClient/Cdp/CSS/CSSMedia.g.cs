using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// CSS media rule descriptor.
/// </summary>
public sealed partial class CSSMedia {
/// <summary>
/// Media query text.
/// </summary>
[JsonPropertyName("text")]public string Text{get;set;}
/// <summary>
/// Source of the media query: "mediaRule" if specified by a @media rule, "importRule" if
/// specified by an @import rule, "linkedSheet" if specified by a "media" attribute in a linked
/// stylesheet's LINK tag, "inlineSheet" if specified by a "media" attribute in an inline
/// stylesheet's STYLE tag.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum SourceEnum {
[EnumMember(Value = "mediaRule")] MediaRule,
[EnumMember(Value = "importRule")] ImportRule,
[EnumMember(Value = "linkedSheet")] LinkedSheet,
[EnumMember(Value = "inlineSheet")] InlineSheet,
}
[JsonPropertyName("source")]public SourceEnum Source{get;set;}
/// <summary>
/// URL of the document containing the media query description.
/// </summary>
[JsonPropertyName("sourceURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? SourceURL{get;set;}
/// <summary>
/// The associated rule (@media or @import) header range in the enclosing stylesheet (if
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
/// Array of media queries.
/// </summary>
[JsonPropertyName("mediaList")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public MediaQuery[]? MediaList{get;set;}
}

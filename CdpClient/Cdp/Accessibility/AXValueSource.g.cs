using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Accessibility;
/// <summary>
/// A single source for a computed AX property.
/// </summary>
public sealed partial class AXValueSource {
/// <summary>
/// What type of source this is.
/// </summary>
[JsonPropertyName("type")]public AXValueSourceType Type{get;set;}
/// <summary>
/// The value of this property source.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXValue? Value{get;set;}
/// <summary>
/// The name of the relevant attribute, if any.
/// </summary>
[JsonPropertyName("attribute")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Attribute{get;set;}
/// <summary>
/// The value of the relevant attribute, if any.
/// </summary>
[JsonPropertyName("attributeValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXValue? AttributeValue{get;set;}
/// <summary>
/// Whether this source is superseded by a higher priority source.
/// </summary>
[JsonPropertyName("superseded")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Superseded{get;set;}
/// <summary>
/// The native markup source for this value, e.g. a <label> element.
/// </summary>
[JsonPropertyName("nativeSource")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXValueNativeSourceType? NativeSource{get;set;}
/// <summary>
/// The value, such as a node or node list, of the native source.
/// </summary>
[JsonPropertyName("nativeSourceValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXValue? NativeSourceValue{get;set;}
/// <summary>
/// Whether the value for this property is invalid.
/// </summary>
[JsonPropertyName("invalid")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Invalid{get;set;}
/// <summary>
/// Reason for the value being invalid, if it is.
/// </summary>
[JsonPropertyName("invalidReason")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? InvalidReason{get;set;}
}

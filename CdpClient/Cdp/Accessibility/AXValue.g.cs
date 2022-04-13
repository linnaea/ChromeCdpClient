using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Accessibility;
/// <summary>
/// A single computed AX property.
/// </summary>
public sealed partial class AXValue {
/// <summary>
/// The type of this value.
/// </summary>
[JsonPropertyName("type")]public AXValueType Type{get;set;}
/// <summary>
/// The computed value of this property.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object? Value{get;set;}
/// <summary>
/// One or more related nodes, if applicable.
/// </summary>
[JsonPropertyName("relatedNodes")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXRelatedNode[]? RelatedNodes{get;set;}
/// <summary>
/// The sources which contributed to the computation of this property.
/// </summary>
[JsonPropertyName("sources")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXValueSource[]? Sources{get;set;}
}

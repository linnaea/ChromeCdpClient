using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Accessibility;
public sealed partial class AXRelatedNode {
/// <summary>
/// The BackendNodeId of the related DOM node.
/// </summary>
[JsonPropertyName("backendDOMNodeId")]public DOM.BackendNodeId BackendDOMNodeId{get;set;}
/// <summary>
/// The IDRef value provided, if any.
/// </summary>
[JsonPropertyName("idref")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Idref{get;set;}
/// <summary>
/// The text alternative of this node in the current context.
/// </summary>
[JsonPropertyName("text")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Text{get;set;}
}

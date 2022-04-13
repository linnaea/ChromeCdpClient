using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Accessibility;
/// <summary>
/// A node in the accessibility tree.
/// </summary>
public sealed partial class AXNode {
/// <summary>
/// Unique identifier for this node.
/// </summary>
[JsonPropertyName("nodeId")]public AXNodeId NodeId{get;set;}
/// <summary>
/// Whether this node is ignored for accessibility
/// </summary>
[JsonPropertyName("ignored")]public bool Ignored{get;set;}
/// <summary>
/// Collection of reasons why this node is hidden.
/// </summary>
[JsonPropertyName("ignoredReasons")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXProperty[]? IgnoredReasons{get;set;}
/// <summary>
/// This `Node`'s role, whether explicit or implicit.
/// </summary>
[JsonPropertyName("role")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXValue? Role{get;set;}
/// <summary>
/// The accessible name for this `Node`.
/// </summary>
[JsonPropertyName("name")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXValue? Name{get;set;}
/// <summary>
/// The accessible description for this `Node`.
/// </summary>
[JsonPropertyName("description")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXValue? Description{get;set;}
/// <summary>
/// The value for this `Node`.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXValue? Value{get;set;}
/// <summary>
/// All other properties
/// </summary>
[JsonPropertyName("properties")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXProperty[]? Properties{get;set;}
/// <summary>
/// ID for this node's parent.
/// </summary>
[JsonPropertyName("parentId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXNodeId? ParentId{get;set;}
/// <summary>
/// IDs for each of this node's child nodes.
/// </summary>
[JsonPropertyName("childIds")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public AXNodeId[]? ChildIds{get;set;}
/// <summary>
/// The backend ID for the associated DOM node, if any.
/// </summary>
[JsonPropertyName("backendDOMNodeId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.BackendNodeId? BackendDOMNodeId{get;set;}
/// <summary>
/// The frame ID for the frame associated with this nodes document.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
}

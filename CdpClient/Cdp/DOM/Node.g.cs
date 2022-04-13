using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// DOM interaction is implemented in terms of mirror objects that represent the actual DOM nodes.
/// DOMNode is a base node mirror type.
/// </summary>
public sealed partial class Node {
/// <summary>
/// Node identifier that is passed into the rest of the DOM messages as the `nodeId`. Backend
/// will only push node with given `id` once. It is aware of all requested nodes and will only
/// fire DOM events for nodes known to the client.
/// </summary>
[JsonPropertyName("nodeId")]public NodeId NodeId{get;set;}
/// <summary>
/// The id of the parent node if any.
/// </summary>
[JsonPropertyName("parentId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public NodeId? ParentId{get;set;}
/// <summary>
/// The BackendNodeId for this node.
/// </summary>
[JsonPropertyName("backendNodeId")]public BackendNodeId BackendNodeId{get;set;}
/// <summary>
/// `Node`'s nodeType.
/// </summary>
[JsonPropertyName("nodeType")]public long NodeType{get;set;}
/// <summary>
/// `Node`'s nodeName.
/// </summary>
[JsonPropertyName("nodeName")]public string NodeName{get;set;}
/// <summary>
/// `Node`'s localName.
/// </summary>
[JsonPropertyName("localName")]public string LocalName{get;set;}
/// <summary>
/// `Node`'s nodeValue.
/// </summary>
[JsonPropertyName("nodeValue")]public string NodeValue{get;set;}
/// <summary>
/// Child count for `Container` nodes.
/// </summary>
[JsonPropertyName("childNodeCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ChildNodeCount{get;set;}
/// <summary>
/// Child nodes of this node when requested with children.
/// </summary>
[JsonPropertyName("children")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Node[]? Children{get;set;}
/// <summary>
/// Attributes of the `Element` node in the form of flat array `[name1, value1, name2, value2]`.
/// </summary>
[JsonPropertyName("attributes")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? Attributes{get;set;}
/// <summary>
/// Document URL that `Document` or `FrameOwner` node points to.
/// </summary>
[JsonPropertyName("documentURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? DocumentURL{get;set;}
/// <summary>
/// Base URL that `Document` or `FrameOwner` node uses for URL completion.
/// </summary>
[JsonPropertyName("baseURL")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? BaseURL{get;set;}
/// <summary>
/// `DocumentType`'s publicId.
/// </summary>
[JsonPropertyName("publicId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? PublicId{get;set;}
/// <summary>
/// `DocumentType`'s systemId.
/// </summary>
[JsonPropertyName("systemId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? SystemId{get;set;}
/// <summary>
/// `DocumentType`'s internalSubset.
/// </summary>
[JsonPropertyName("internalSubset")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? InternalSubset{get;set;}
/// <summary>
/// `Document`'s XML version in case of XML documents.
/// </summary>
[JsonPropertyName("xmlVersion")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? XmlVersion{get;set;}
/// <summary>
/// `Attr`'s name.
/// </summary>
[JsonPropertyName("name")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Name{get;set;}
/// <summary>
/// `Attr`'s value.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Value{get;set;}
/// <summary>
/// Pseudo element type for this node.
/// </summary>
[JsonPropertyName("pseudoType")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public PseudoType? PseudoType{get;set;}
/// <summary>
/// Shadow root type.
/// </summary>
[JsonPropertyName("shadowRootType")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public ShadowRootType? ShadowRootType{get;set;}
/// <summary>
/// Frame ID for frame owner elements.
/// </summary>
[JsonPropertyName("frameId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Page.FrameId? FrameId{get;set;}
/// <summary>
/// Content document for frame owner elements.
/// </summary>
[JsonPropertyName("contentDocument")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Node? ContentDocument{get;set;}
/// <summary>
/// Shadow root list for given element host.
/// </summary>
[JsonPropertyName("shadowRoots")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Node[]? ShadowRoots{get;set;}
/// <summary>
/// Content document fragment for template elements.
/// </summary>
[JsonPropertyName("templateContent")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Node? TemplateContent{get;set;}
/// <summary>
/// Pseudo elements associated with this node.
/// </summary>
[JsonPropertyName("pseudoElements")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Node[]? PseudoElements{get;set;}
/// <summary>
/// Deprecated, as the HTML Imports API has been removed (crbug.com/937746).
/// This property used to return the imported document for the HTMLImport links.
/// The property is always undefined now.
/// </summary>
[Obsolete][JsonPropertyName("importedDocument")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Node? ImportedDocument{get;set;}
/// <summary>
/// Distributed nodes for given insertion point.
/// </summary>
[JsonPropertyName("distributedNodes")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public BackendNode[]? DistributedNodes{get;set;}
/// <summary>
/// Whether the node is SVG.
/// </summary>
[JsonPropertyName("isSVG")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? IsSVG{get;set;}
[JsonPropertyName("compatibilityMode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public CompatibilityMode? CompatibilityMode{get;set;}
}

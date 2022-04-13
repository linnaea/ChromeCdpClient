using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
/// <summary>
/// Document snapshot.
/// </summary>
public sealed partial class DocumentSnapshot {
/// <summary>
/// Document URL that `Document` or `FrameOwner` node points to.
/// </summary>
[JsonPropertyName("documentURL")]public StringIndex DocumentURL{get;set;}
/// <summary>
/// Document title.
/// </summary>
[JsonPropertyName("title")]public StringIndex Title{get;set;}
/// <summary>
/// Base URL that `Document` or `FrameOwner` node uses for URL completion.
/// </summary>
[JsonPropertyName("baseURL")]public StringIndex BaseURL{get;set;}
/// <summary>
/// Contains the document's content language.
/// </summary>
[JsonPropertyName("contentLanguage")]public StringIndex ContentLanguage{get;set;}
/// <summary>
/// Contains the document's character set encoding.
/// </summary>
[JsonPropertyName("encodingName")]public StringIndex EncodingName{get;set;}
/// <summary>
/// `DocumentType` node's publicId.
/// </summary>
[JsonPropertyName("publicId")]public StringIndex PublicId{get;set;}
/// <summary>
/// `DocumentType` node's systemId.
/// </summary>
[JsonPropertyName("systemId")]public StringIndex SystemId{get;set;}
/// <summary>
/// Frame ID for frame owner elements and also for the document node.
/// </summary>
[JsonPropertyName("frameId")]public StringIndex FrameId{get;set;}
/// <summary>
/// A table with dom nodes.
/// </summary>
[JsonPropertyName("nodes")]public NodeTreeSnapshot Nodes{get;set;}
/// <summary>
/// The nodes in the layout tree.
/// </summary>
[JsonPropertyName("layout")]public LayoutTreeSnapshot Layout{get;set;}
/// <summary>
/// The post-layout inline text nodes.
/// </summary>
[JsonPropertyName("textBoxes")]public TextBoxSnapshot TextBoxes{get;set;}
/// <summary>
/// Horizontal scroll offset.
/// </summary>
[JsonPropertyName("scrollOffsetX")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? ScrollOffsetX{get;set;}
/// <summary>
/// Vertical scroll offset.
/// </summary>
[JsonPropertyName("scrollOffsetY")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? ScrollOffsetY{get;set;}
/// <summary>
/// Document content width.
/// </summary>
[JsonPropertyName("contentWidth")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? ContentWidth{get;set;}
/// <summary>
/// Document content height.
/// </summary>
[JsonPropertyName("contentHeight")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? ContentHeight{get;set;}
}

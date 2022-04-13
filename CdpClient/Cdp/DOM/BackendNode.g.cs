using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// Backend node with a friendly name.
/// </summary>
public sealed partial class BackendNode {
/// <summary>
/// `Node`'s nodeType.
/// </summary>
[JsonPropertyName("nodeType")]public long NodeType{get;set;}
/// <summary>
/// `Node`'s nodeName.
/// </summary>
[JsonPropertyName("nodeName")]public string NodeName{get;set;}
[JsonPropertyName("backendNodeId")]public BackendNodeId BackendNodeId{get;set;}
}

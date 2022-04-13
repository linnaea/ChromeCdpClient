using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Information about the Frame hierarchy.
/// </summary>
public sealed partial class FrameTree {
/// <summary>
/// Frame information for this tree item.
/// </summary>
[JsonPropertyName("frame")]public Frame Frame{get;set;}
/// <summary>
/// Child frames.
/// </summary>
[JsonPropertyName("childFrames")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public FrameTree[]? ChildFrames{get;set;}
}

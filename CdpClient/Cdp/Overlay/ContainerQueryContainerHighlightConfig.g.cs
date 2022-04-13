using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
public sealed partial class ContainerQueryContainerHighlightConfig {
/// <summary>
/// The style of the container border.
/// </summary>
[JsonPropertyName("containerBorder")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? ContainerBorder{get;set;}
/// <summary>
/// The style of the descendants' borders.
/// </summary>
[JsonPropertyName("descendantBorder")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? DescendantBorder{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
/// <summary>
/// Configuration data for the highlighting of Flex item elements.
/// </summary>
public sealed partial class FlexItemHighlightConfig {
/// <summary>
/// Style of the box representing the item's base size
/// </summary>
[JsonPropertyName("baseSizeBox")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public BoxStyle? BaseSizeBox{get;set;}
/// <summary>
/// Style of the border around the box representing the item's base size
/// </summary>
[JsonPropertyName("baseSizeBorder")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? BaseSizeBorder{get;set;}
/// <summary>
/// Style of the arrow representing if the item grew or shrank
/// </summary>
[JsonPropertyName("flexibilityArrow")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? FlexibilityArrow{get;set;}
}

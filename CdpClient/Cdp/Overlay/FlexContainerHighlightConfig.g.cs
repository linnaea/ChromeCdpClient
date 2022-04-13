using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
/// <summary>
/// Configuration data for the highlighting of Flex container elements.
/// </summary>
public sealed partial class FlexContainerHighlightConfig {
/// <summary>
/// The style of the container border
/// </summary>
[JsonPropertyName("containerBorder")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? ContainerBorder{get;set;}
/// <summary>
/// The style of the separator between lines
/// </summary>
[JsonPropertyName("lineSeparator")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? LineSeparator{get;set;}
/// <summary>
/// The style of the separator between items
/// </summary>
[JsonPropertyName("itemSeparator")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? ItemSeparator{get;set;}
/// <summary>
/// Style of content-distribution space on the main axis (justify-content).
/// </summary>
[JsonPropertyName("mainDistributedSpace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public BoxStyle? MainDistributedSpace{get;set;}
/// <summary>
/// Style of content-distribution space on the cross axis (align-content).
/// </summary>
[JsonPropertyName("crossDistributedSpace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public BoxStyle? CrossDistributedSpace{get;set;}
/// <summary>
/// Style of empty space caused by row gaps (gap/row-gap).
/// </summary>
[JsonPropertyName("rowGapSpace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public BoxStyle? RowGapSpace{get;set;}
/// <summary>
/// Style of empty space caused by columns gaps (gap/column-gap).
/// </summary>
[JsonPropertyName("columnGapSpace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public BoxStyle? ColumnGapSpace{get;set;}
/// <summary>
/// Style of the self-alignment line (align-items).
/// </summary>
[JsonPropertyName("crossAlignment")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LineStyle? CrossAlignment{get;set;}
}

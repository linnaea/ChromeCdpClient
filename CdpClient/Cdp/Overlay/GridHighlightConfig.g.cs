using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
/// <summary>
/// Configuration data for the highlighting of Grid elements.
/// </summary>
public sealed partial class GridHighlightConfig {
/// <summary>
/// Whether the extension lines from grid cells to the rulers should be shown (default: false).
/// </summary>
[JsonPropertyName("showGridExtensionLines")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ShowGridExtensionLines{get;set;}
/// <summary>
/// Show Positive line number labels (default: false).
/// </summary>
[JsonPropertyName("showPositiveLineNumbers")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ShowPositiveLineNumbers{get;set;}
/// <summary>
/// Show Negative line number labels (default: false).
/// </summary>
[JsonPropertyName("showNegativeLineNumbers")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ShowNegativeLineNumbers{get;set;}
/// <summary>
/// Show area name labels (default: false).
/// </summary>
[JsonPropertyName("showAreaNames")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ShowAreaNames{get;set;}
/// <summary>
/// Show line name labels (default: false).
/// </summary>
[JsonPropertyName("showLineNames")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ShowLineNames{get;set;}
/// <summary>
/// Show track size labels (default: false).
/// </summary>
[JsonPropertyName("showTrackSizes")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ShowTrackSizes{get;set;}
/// <summary>
/// The grid container border highlight color (default: transparent).
/// </summary>
[JsonPropertyName("gridBorderColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? GridBorderColor{get;set;}
/// <summary>
/// The cell border color (default: transparent). Deprecated, please use rowLineColor and columnLineColor instead.
/// </summary>
[Obsolete][JsonPropertyName("cellBorderColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? CellBorderColor{get;set;}
/// <summary>
/// The row line color (default: transparent).
/// </summary>
[JsonPropertyName("rowLineColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? RowLineColor{get;set;}
/// <summary>
/// The column line color (default: transparent).
/// </summary>
[JsonPropertyName("columnLineColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ColumnLineColor{get;set;}
/// <summary>
/// Whether the grid border is dashed (default: false).
/// </summary>
[JsonPropertyName("gridBorderDash")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? GridBorderDash{get;set;}
/// <summary>
/// Whether the cell border is dashed (default: false). Deprecated, please us rowLineDash and columnLineDash instead.
/// </summary>
[Obsolete][JsonPropertyName("cellBorderDash")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? CellBorderDash{get;set;}
/// <summary>
/// Whether row lines are dashed (default: false).
/// </summary>
[JsonPropertyName("rowLineDash")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? RowLineDash{get;set;}
/// <summary>
/// Whether column lines are dashed (default: false).
/// </summary>
[JsonPropertyName("columnLineDash")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? ColumnLineDash{get;set;}
/// <summary>
/// The row gap highlight fill color (default: transparent).
/// </summary>
[JsonPropertyName("rowGapColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? RowGapColor{get;set;}
/// <summary>
/// The row gap hatching fill color (default: transparent).
/// </summary>
[JsonPropertyName("rowHatchColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? RowHatchColor{get;set;}
/// <summary>
/// The column gap highlight fill color (default: transparent).
/// </summary>
[JsonPropertyName("columnGapColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ColumnGapColor{get;set;}
/// <summary>
/// The column gap hatching fill color (default: transparent).
/// </summary>
[JsonPropertyName("columnHatchColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? ColumnHatchColor{get;set;}
/// <summary>
/// The named grid areas border color (Default: transparent).
/// </summary>
[JsonPropertyName("areaBorderColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? AreaBorderColor{get;set;}
/// <summary>
/// The grid container background color (Default: transparent).
/// </summary>
[JsonPropertyName("gridBackgroundColor")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? GridBackgroundColor{get;set;}
}

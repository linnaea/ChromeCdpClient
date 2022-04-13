using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
/// <summary>
/// Style information for drawing a line.
/// </summary>
public sealed partial class LineStyle {
/// <summary>
/// The color of the line (default: transparent)
/// </summary>
[JsonPropertyName("color")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.RGBA? Color{get;set;}
/// <summary>
/// The line pattern (default: solid)
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum PatternEnum {
[EnumMember(Value = "dashed")] Dashed,
[EnumMember(Value = "dotted")] Dotted,
}
[JsonPropertyName("pattern")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public PatternEnum? Pattern{get;set;}
}

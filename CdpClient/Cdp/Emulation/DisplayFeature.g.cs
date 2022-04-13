using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Emulation;
public sealed partial class DisplayFeature {
/// <summary>
/// Orientation of a display feature in relation to screen
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum OrientationEnum {
[EnumMember(Value = "vertical")] Vertical,
[EnumMember(Value = "horizontal")] Horizontal,
}
[JsonPropertyName("orientation")]public OrientationEnum Orientation{get;set;}
/// <summary>
/// The offset from the screen origin in either the x (for vertical
/// orientation) or y (for horizontal orientation) direction.
/// </summary>
[JsonPropertyName("offset")]public long Offset{get;set;}
/// <summary>
/// A display feature may mask content such that it is not physically
/// displayed - this length along with the offset describes this area.
/// A display feature that only splits content will have a 0 mask_length.
/// </summary>
[JsonPropertyName("maskLength")]public long MaskLength{get;set;}
}

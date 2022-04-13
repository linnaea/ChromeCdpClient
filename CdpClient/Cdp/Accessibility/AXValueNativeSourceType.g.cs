using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Accessibility;
/// <summary>
/// Enum of possible native property sources (as a subtype of a particular AXValueSourceType).
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum AXValueNativeSourceType {
[EnumMember(Value = "description")] Description,
[EnumMember(Value = "figcaption")] Figcaption,
[EnumMember(Value = "label")] Label,
[EnumMember(Value = "labelfor")] Labelfor,
[EnumMember(Value = "labelwrapped")] Labelwrapped,
[EnumMember(Value = "legend")] Legend,
[EnumMember(Value = "rubyannotation")] Rubyannotation,
[EnumMember(Value = "tablecaption")] Tablecaption,
[EnumMember(Value = "title")] Title,
[EnumMember(Value = "other")] Other,
}

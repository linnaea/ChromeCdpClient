using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Accessibility;
/// <summary>
/// Enum of possible property sources.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum AXValueSourceType {
[EnumMember(Value = "attribute")] Attribute,
[EnumMember(Value = "implicit")] Implicit,
[EnumMember(Value = "style")] Style,
[EnumMember(Value = "contents")] Contents,
[EnumMember(Value = "placeholder")] Placeholder,
[EnumMember(Value = "relatedElement")] RelatedElement,
}

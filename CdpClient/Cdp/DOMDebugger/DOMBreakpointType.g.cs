using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMDebugger;
/// <summary>
/// DOM breakpoint type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum DOMBreakpointType {
[EnumMember(Value = "subtree-modified")] SubtreeModified,
[EnumMember(Value = "attribute-modified")] AttributeModified,
[EnumMember(Value = "node-removed")] NodeRemoved,
}

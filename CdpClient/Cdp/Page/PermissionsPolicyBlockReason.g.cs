using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Reason for a permissions policy feature to be disabled.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum PermissionsPolicyBlockReason {
[EnumMember(Value = "Header")] Header,
[EnumMember(Value = "IframeAttribute")] IframeAttribute,
[EnumMember(Value = "InFencedFrameTree")] InFencedFrameTree,
}

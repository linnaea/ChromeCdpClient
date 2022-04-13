using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum CrossOriginOpenerPolicyValue {
[EnumMember(Value = "SameOrigin")] SameOrigin,
[EnumMember(Value = "SameOriginAllowPopups")] SameOriginAllowPopups,
[EnumMember(Value = "UnsafeNone")] UnsafeNone,
[EnumMember(Value = "SameOriginPlusCoep")] SameOriginPlusCoep,
[EnumMember(Value = "SameOriginAllowPopupsPlusCoep")] SameOriginAllowPopupsPlusCoep,
}

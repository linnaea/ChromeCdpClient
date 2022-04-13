using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum IPAddressSpace {
[EnumMember(Value = "Local")] Local,
[EnumMember(Value = "Private")] Private,
[EnumMember(Value = "Public")] Public,
[EnumMember(Value = "Unknown")] Unknown,
}

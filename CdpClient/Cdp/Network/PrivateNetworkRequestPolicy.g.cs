using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum PrivateNetworkRequestPolicy {
[EnumMember(Value = "Allow")] Allow,
[EnumMember(Value = "BlockFromInsecureToMorePrivate")] BlockFromInsecureToMorePrivate,
[EnumMember(Value = "WarnFromInsecureToMorePrivate")] WarnFromInsecureToMorePrivate,
[EnumMember(Value = "PreflightBlock")] PreflightBlock,
[EnumMember(Value = "PreflightWarn")] PreflightWarn,
}

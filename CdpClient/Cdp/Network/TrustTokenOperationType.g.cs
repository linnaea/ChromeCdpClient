using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum TrustTokenOperationType {
[EnumMember(Value = "Issuance")] Issuance,
[EnumMember(Value = "Redemption")] Redemption,
[EnumMember(Value = "Signing")] Signing,
}

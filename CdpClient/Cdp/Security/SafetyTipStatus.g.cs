using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Security;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum SafetyTipStatus {
[EnumMember(Value = "badReputation")] BadReputation,
[EnumMember(Value = "lookalike")] Lookalike,
}

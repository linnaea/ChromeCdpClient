using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum CrossOriginEmbedderPolicyValue {
[EnumMember(Value = "None")] None,
[EnumMember(Value = "Credentialless")] Credentialless,
[EnumMember(Value = "RequireCorp")] RequireCorp,
}

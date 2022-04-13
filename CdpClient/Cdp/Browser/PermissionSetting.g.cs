using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Browser;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum PermissionSetting {
[EnumMember(Value = "granted")] Granted,
[EnumMember(Value = "denied")] Denied,
[EnumMember(Value = "prompt")] Prompt,
}

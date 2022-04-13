using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Javascript dialog type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum DialogType {
[EnumMember(Value = "alert")] Alert,
[EnumMember(Value = "confirm")] Confirm,
[EnumMember(Value = "prompt")] Prompt,
[EnumMember(Value = "beforeunload")] Beforeunload,
}

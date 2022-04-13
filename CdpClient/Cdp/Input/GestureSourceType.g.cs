using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Input;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum GestureSourceType {
[EnumMember(Value = "default")] Default,
[EnumMember(Value = "touch")] Touch,
[EnumMember(Value = "mouse")] Mouse,
}

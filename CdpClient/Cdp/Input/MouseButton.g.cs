using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Input;
[JsonConverter(typeof(StringEnumConverter))] public enum MouseButton {
[EnumMember(Value = "none")] None,
[EnumMember(Value = "left")] Left,
[EnumMember(Value = "middle")] Middle,
[EnumMember(Value = "right")] Right,
[EnumMember(Value = "back")] Back,
[EnumMember(Value = "forward")] Forward,
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Browser;
/// <summary>
/// The state of the browser window.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum WindowState {
[EnumMember(Value = "normal")] Normal,
[EnumMember(Value = "minimized")] Minimized,
[EnumMember(Value = "maximized")] Maximized,
[EnumMember(Value = "fullscreen")] Fullscreen,
}

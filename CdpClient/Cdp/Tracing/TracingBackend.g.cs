using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Tracing;
/// <summary>
/// Backend type to use for tracing. `chrome` uses the Chrome-integrated
/// tracing service and is supported on all platforms. `system` is only
/// supported on Chrome OS and uses the Perfetto system tracing service.
/// `auto` chooses `system` when the perfettoConfig provided to Tracing.start
/// specifies at least one non-Chrome data source; otherwise uses `chrome`.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TracingBackend {
[EnumMember(Value = "auto")] Auto,
[EnumMember(Value = "chrome")] Chrome,
[EnumMember(Value = "system")] System,
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Overlay;
[JsonConverter(typeof(StringEnumConverter))] public enum InspectMode {
[EnumMember(Value = "searchForNode")] SearchForNode,
[EnumMember(Value = "searchForUAShadowDOM")] SearchForUAShadowDOM,
[EnumMember(Value = "captureAreaScreenshot")] CaptureAreaScreenshot,
[EnumMember(Value = "showDistances")] ShowDistances,
[EnumMember(Value = "none")] None,
}

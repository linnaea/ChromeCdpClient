using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
[JsonConverter(typeof(StringEnumConverter))] public enum MixedContentResourceType {
[EnumMember(Value = "AttributionSrc")] AttributionSrc,
[EnumMember(Value = "Audio")] Audio,
[EnumMember(Value = "Beacon")] Beacon,
[EnumMember(Value = "CSPReport")] CSPReport,
[EnumMember(Value = "Download")] Download,
[EnumMember(Value = "EventSource")] EventSource,
[EnumMember(Value = "Favicon")] Favicon,
[EnumMember(Value = "Font")] Font,
[EnumMember(Value = "Form")] Form,
[EnumMember(Value = "Frame")] Frame,
[EnumMember(Value = "Image")] Image,
[EnumMember(Value = "Import")] Import,
[EnumMember(Value = "Manifest")] Manifest,
[EnumMember(Value = "Ping")] Ping,
[EnumMember(Value = "PluginData")] PluginData,
[EnumMember(Value = "PluginResource")] PluginResource,
[EnumMember(Value = "Prefetch")] Prefetch,
[EnumMember(Value = "Resource")] Resource,
[EnumMember(Value = "Script")] Script,
[EnumMember(Value = "ServiceWorker")] ServiceWorker,
[EnumMember(Value = "SharedWorker")] SharedWorker,
[EnumMember(Value = "Stylesheet")] Stylesheet,
[EnumMember(Value = "Track")] Track,
[EnumMember(Value = "Video")] Video,
[EnumMember(Value = "Worker")] Worker,
[EnumMember(Value = "XMLHttpRequest")] XMLHttpRequest,
[EnumMember(Value = "XSLT")] XSLT,
}

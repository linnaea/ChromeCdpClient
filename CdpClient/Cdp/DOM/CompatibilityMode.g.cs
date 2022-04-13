using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// Document compatibility mode.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum CompatibilityMode {
[EnumMember(Value = "QuirksMode")] QuirksMode,
[EnumMember(Value = "LimitedQuirksMode")] LimitedQuirksMode,
[EnumMember(Value = "NoQuirksMode")] NoQuirksMode,
}

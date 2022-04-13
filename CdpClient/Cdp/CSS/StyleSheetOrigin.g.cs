using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CSS;
/// <summary>
/// Stylesheet type: "injected" for stylesheets injected via extension, "user-agent" for user-agent
/// stylesheets, "inspector" for stylesheets created by the inspector (i.e. those holding the "via
/// inspector" rules), "regular" for regular stylesheets.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum StyleSheetOrigin {
[EnumMember(Value = "injected")] Injected,
[EnumMember(Value = "user-agent")] UserAgent,
[EnumMember(Value = "inspector")] Inspector,
[EnumMember(Value = "regular")] Regular,
}

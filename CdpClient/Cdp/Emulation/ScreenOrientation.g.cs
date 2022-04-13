using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Emulation;
/// <summary>
/// Screen orientation.
/// </summary>
public sealed partial class ScreenOrientation {
/// <summary>
/// Orientation type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "portraitPrimary")] PortraitPrimary,
[EnumMember(Value = "portraitSecondary")] PortraitSecondary,
[EnumMember(Value = "landscapePrimary")] LandscapePrimary,
[EnumMember(Value = "landscapeSecondary")] LandscapeSecondary,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// Orientation angle.
/// </summary>
[JsonPropertyName("angle")]public long Angle{get;set;}
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Browser;
/// <summary>
/// Definition of PermissionDescriptor defined in the Permissions API:
/// https://w3c.github.io/permissions/#dictdef-permissiondescriptor.
/// </summary>
[Experimental]public sealed partial class PermissionDescriptor {
/// <summary>
/// Name of permission.
/// See https://cs.chromium.org/chromium/src/third_party/blink/renderer/modules/permissions/permission_descriptor.idl for valid permission names.
/// </summary>
[JsonPropertyName("name")]public string Name{get;set;}
/// <summary>
/// For "midi" permission, may also specify sysex control.
/// </summary>
[JsonPropertyName("sysex")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Sysex{get;set;}
/// <summary>
/// For "push" permission, may specify userVisibleOnly.
/// Note that userVisibleOnly = true is the only currently supported type.
/// </summary>
[JsonPropertyName("userVisibleOnly")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? UserVisibleOnly{get;set;}
/// <summary>
/// For "clipboard" permission, may specify allowWithoutSanitization.
/// </summary>
[JsonPropertyName("allowWithoutSanitization")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? AllowWithoutSanitization{get;set;}
/// <summary>
/// For "camera" permission, may specify panTiltZoom.
/// </summary>
[JsonPropertyName("panTiltZoom")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? PanTiltZoom{get;set;}
}

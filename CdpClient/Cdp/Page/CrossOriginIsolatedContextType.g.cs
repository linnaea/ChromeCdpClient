using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Indicates whether the frame is cross-origin isolated and why it is the case.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum CrossOriginIsolatedContextType {
[EnumMember(Value = "Isolated")] Isolated,
[EnumMember(Value = "NotIsolated")] NotIsolated,
[EnumMember(Value = "NotIsolatedFeatureDisabled")] NotIsolatedFeatureDisabled,
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// Shadow root type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum ShadowRootType {
[EnumMember(Value = "user-agent")] UserAgent,
[EnumMember(Value = "open")] Open,
[EnumMember(Value = "closed")] Closed,
}

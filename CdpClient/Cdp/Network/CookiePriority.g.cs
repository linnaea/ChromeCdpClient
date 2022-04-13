using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Represents the cookie's 'Priority' status:
/// https://tools.ietf.org/html/draft-west-cookie-priority-00
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum CookiePriority {
[EnumMember(Value = "Low")] Low,
[EnumMember(Value = "Medium")] Medium,
[EnumMember(Value = "High")] High,
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// The type of a frameNavigated event.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum NavigationType {
[EnumMember(Value = "Navigation")] Navigation,
[EnumMember(Value = "BackForwardCacheRestore")] BackForwardCacheRestore,
}

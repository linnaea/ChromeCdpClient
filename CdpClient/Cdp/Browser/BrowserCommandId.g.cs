using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Browser;
/// <summary>
/// Browser command ids used by executeBrowserCommand.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum BrowserCommandId {
[EnumMember(Value = "openTabSearch")] OpenTabSearch,
[EnumMember(Value = "closeTabSearch")] CloseTabSearch,
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Types of not restored reasons for back-forward cache.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum BackForwardCacheNotRestoredReasonType {
[EnumMember(Value = "SupportPending")] SupportPending,
[EnumMember(Value = "PageSupportNeeded")] PageSupportNeeded,
[EnumMember(Value = "Circumstantial")] Circumstantial,
}

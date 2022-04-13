using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum ClientNavigationReason {
[EnumMember(Value = "formSubmissionGet")] FormSubmissionGet,
[EnumMember(Value = "formSubmissionPost")] FormSubmissionPost,
[EnumMember(Value = "httpHeaderRefresh")] HttpHeaderRefresh,
[EnumMember(Value = "scriptInitiated")] ScriptInitiated,
[EnumMember(Value = "metaTagRefresh")] MetaTagRefresh,
[EnumMember(Value = "pageBlockInterstitial")] PageBlockInterstitial,
[EnumMember(Value = "reload")] Reload,
[EnumMember(Value = "anchorClick")] AnchorClick,
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum AdFrameExplanation {
[EnumMember(Value = "ParentIsAd")] ParentIsAd,
[EnumMember(Value = "CreatedByAdScript")] CreatedByAdScript,
[EnumMember(Value = "MatchedBlockingRule")] MatchedBlockingRule,
}

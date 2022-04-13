using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
[JsonConverter(typeof(StringEnumConverter))] public enum AttributionReportingIssueType {
[EnumMember(Value = "PermissionPolicyDisabled")] PermissionPolicyDisabled,
[EnumMember(Value = "InvalidAttributionSourceEventId")] InvalidAttributionSourceEventId,
[EnumMember(Value = "InvalidAttributionData")] InvalidAttributionData,
[EnumMember(Value = "AttributionSourceUntrustworthyOrigin")] AttributionSourceUntrustworthyOrigin,
[EnumMember(Value = "AttributionUntrustworthyOrigin")] AttributionUntrustworthyOrigin,
[EnumMember(Value = "AttributionTriggerDataTooLarge")] AttributionTriggerDataTooLarge,
[EnumMember(Value = "AttributionEventSourceTriggerDataTooLarge")] AttributionEventSourceTriggerDataTooLarge,
[EnumMember(Value = "InvalidAttributionSourceExpiry")] InvalidAttributionSourceExpiry,
[EnumMember(Value = "InvalidAttributionSourcePriority")] InvalidAttributionSourcePriority,
[EnumMember(Value = "InvalidEventSourceTriggerData")] InvalidEventSourceTriggerData,
[EnumMember(Value = "InvalidTriggerPriority")] InvalidTriggerPriority,
[EnumMember(Value = "InvalidTriggerDedupKey")] InvalidTriggerDedupKey,
}

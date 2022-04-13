using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Page;
/// <summary>
/// Status for an Origin Trial.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum OriginTrialStatus {
[EnumMember(Value = "Enabled")] Enabled,
[EnumMember(Value = "ValidTokenNotProvided")] ValidTokenNotProvided,
[EnumMember(Value = "OSNotSupported")] OSNotSupported,
[EnumMember(Value = "TrialNotAllowed")] TrialNotAllowed,
}

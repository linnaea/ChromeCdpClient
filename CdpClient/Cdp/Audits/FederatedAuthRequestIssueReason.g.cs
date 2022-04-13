using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
/// <summary>
/// Represents the failure reason when a federated authentication reason fails.
/// Should be updated alongside RequestIdTokenStatus in
/// third_party/blink/public/mojom/devtools/inspector_issue.mojom to include
/// all cases except for success.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum FederatedAuthRequestIssueReason {
[EnumMember(Value = "ApprovalDeclined")] ApprovalDeclined,
[EnumMember(Value = "TooManyRequests")] TooManyRequests,
[EnumMember(Value = "ManifestHttpNotFound")] ManifestHttpNotFound,
[EnumMember(Value = "ManifestNoResponse")] ManifestNoResponse,
[EnumMember(Value = "ManifestInvalidResponse")] ManifestInvalidResponse,
[EnumMember(Value = "ClientMetadataHttpNotFound")] ClientMetadataHttpNotFound,
[EnumMember(Value = "ClientMetadataNoResponse")] ClientMetadataNoResponse,
[EnumMember(Value = "ClientMetadataInvalidResponse")] ClientMetadataInvalidResponse,
[EnumMember(Value = "ClientMetadataMissingPrivacyPolicyUrl")] ClientMetadataMissingPrivacyPolicyUrl,
[EnumMember(Value = "DisabledInSettings")] DisabledInSettings,
[EnumMember(Value = "ErrorFetchingSignin")] ErrorFetchingSignin,
[EnumMember(Value = "InvalidSigninResponse")] InvalidSigninResponse,
[EnumMember(Value = "AccountsHttpNotFound")] AccountsHttpNotFound,
[EnumMember(Value = "AccountsNoResponse")] AccountsNoResponse,
[EnumMember(Value = "AccountsInvalidResponse")] AccountsInvalidResponse,
[EnumMember(Value = "IdTokenHttpNotFound")] IdTokenHttpNotFound,
[EnumMember(Value = "IdTokenNoResponse")] IdTokenNoResponse,
[EnumMember(Value = "IdTokenInvalidResponse")] IdTokenInvalidResponse,
[EnumMember(Value = "IdTokenInvalidRequest")] IdTokenInvalidRequest,
[EnumMember(Value = "ErrorIdToken")] ErrorIdToken,
[EnumMember(Value = "Canceled")] Canceled,
}

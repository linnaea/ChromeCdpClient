using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Field type for a signed exchange related error.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum SignedExchangeErrorField {
[EnumMember(Value = "signatureSig")] SignatureSig,
[EnumMember(Value = "signatureIntegrity")] SignatureIntegrity,
[EnumMember(Value = "signatureCertUrl")] SignatureCertUrl,
[EnumMember(Value = "signatureCertSha256")] SignatureCertSha256,
[EnumMember(Value = "signatureValidityUrl")] SignatureValidityUrl,
[EnumMember(Value = "signatureTimestamps")] SignatureTimestamps,
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Audits;
[JsonConverter(typeof(StringEnumConverter))] public enum SharedArrayBufferIssueType {
[EnumMember(Value = "TransferIssue")] TransferIssue,
[EnumMember(Value = "CreationIssue")] CreationIssue,
}
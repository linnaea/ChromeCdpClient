using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// The status of a Reporting API report.
/// </summary>
[Experimental][JsonConverter(typeof(StringEnumConverter))] public enum ReportStatus {
[EnumMember(Value = "Queued")] Queued,
[EnumMember(Value = "Pending")] Pending,
[EnumMember(Value = "MarkedForRemoval")] MarkedForRemoval,
[EnumMember(Value = "Success")] Success,
}

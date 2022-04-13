using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Security;
/// <summary>
/// An internal certificate ID value.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct CertificateId {
public long Value {get;set;}
public static implicit operator long(CertificateId v) => v.Value;
public static implicit operator CertificateId(long v) => new() {Value=v};
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAuthn;
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct AuthenticatorId {
public string Value {get;set;}
public static implicit operator string(AuthenticatorId v) => v.Value;
public static implicit operator AuthenticatorId(string v) => new() {Value=v};
}

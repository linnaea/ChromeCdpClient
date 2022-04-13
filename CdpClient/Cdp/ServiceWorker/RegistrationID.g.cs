using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.ServiceWorker;
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct RegistrationID {
public string Value {get;set;}
public static implicit operator string(RegistrationID v) => v.Value;
public static implicit operator RegistrationID(string v) => new() {Value=v};
}

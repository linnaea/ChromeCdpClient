using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Unique request identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct RequestId {
public string Value {get;set;}
public static implicit operator string(RequestId v) => v.Value;
public static implicit operator RequestId(string v) => new() {Value=v};
}

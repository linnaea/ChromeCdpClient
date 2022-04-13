using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Unique object identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct RemoteObjectId {
public string Value {get;set;}
public static implicit operator string(RemoteObjectId v) => v.Value;
public static implicit operator RemoteObjectId(string v) => new() {Value=v};
}

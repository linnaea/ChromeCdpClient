using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.CacheStorage;
/// <summary>
/// Unique identifier of the Cache object.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct CacheId {
public string Value {get;set;}
public static implicit operator string(CacheId v) => v.Value;
public static implicit operator CacheId(string v) => new() {Value=v};
}

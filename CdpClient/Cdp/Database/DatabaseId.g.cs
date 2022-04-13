using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Database;
/// <summary>
/// Unique identifier of Database object.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct DatabaseId {
public string Value {get;set;}
public static implicit operator string(DatabaseId v) => v.Value;
public static implicit operator DatabaseId(string v) => new() {Value=v};
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMStorage;
/// <summary>
/// DOM Storage item.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct Item {
public string[] Value {get;set;}
public static implicit operator string[](Item v) => v.Value;
public static implicit operator Item(string[] v) => new() {Value=v};
}

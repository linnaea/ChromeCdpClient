using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
/// <summary>
/// Index of the string in the strings table.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct ArrayOfStrings {
public StringIndex[] Value {get;set;}
public static implicit operator StringIndex[](ArrayOfStrings v) => v.Value;
public static implicit operator ArrayOfStrings(StringIndex[] v) => new() {Value=v};
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Primitive value which cannot be JSON-stringified. Includes values `-0`, `NaN`, `Infinity`,
/// `-Infinity`, and bigint literals.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct UnserializableValue {
public string Value {get;set;}
public static implicit operator string(UnserializableValue v) => v.Value;
public static implicit operator UnserializableValue(string v) => new() {Value=v};
}

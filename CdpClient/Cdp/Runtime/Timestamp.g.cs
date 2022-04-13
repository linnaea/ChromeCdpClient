using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Number of milliseconds since epoch.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct Timestamp {
public double Value {get;set;}
public static implicit operator double(Timestamp v) => v.Value;
public static implicit operator Timestamp(double v) => new() {Value=v};
}

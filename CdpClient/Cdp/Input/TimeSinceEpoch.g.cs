using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Input;
/// <summary>
/// UTC time in seconds, counted from January 1, 1970.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct TimeSinceEpoch {
public double Value {get;set;}
public static implicit operator double(TimeSinceEpoch v) => v.Value;
public static implicit operator TimeSinceEpoch(double v) => new() {Value=v};
}

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Network;
/// <summary>
/// Monotonically increasing time in seconds since an arbitrary point in the past.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct MonotonicTime {
public double Value {get;set;}
public static implicit operator double(MonotonicTime v) => v.Value;
public static implicit operator MonotonicTime(double v) => new() {Value=v};
}

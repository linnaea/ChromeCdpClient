using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.LayerTree;
/// <summary>
/// Array of timings, one per paint step.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct PaintProfile {
public double[] Value {get;set;}
public static implicit operator double[](PaintProfile v) => v.Value;
public static implicit operator PaintProfile(double[] v) => new() {Value=v};
}

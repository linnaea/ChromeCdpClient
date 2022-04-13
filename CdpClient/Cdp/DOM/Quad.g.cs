using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOM;
/// <summary>
/// An array of quad vertices, x immediately followed by y for each point, points clock-wise.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct Quad {
public double[] Value {get;set;}
public static implicit operator double[](Quad v) => v.Value;
public static implicit operator Quad(double[] v) => new() {Value=v};
}

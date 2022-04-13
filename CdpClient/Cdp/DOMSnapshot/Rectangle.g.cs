using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.DOMSnapshot;
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct Rectangle {
public double[] Value {get;set;}
public static implicit operator double[](Rectangle v) => v.Value;
public static implicit operator Rectangle(double[] v) => new() {Value=v};
}

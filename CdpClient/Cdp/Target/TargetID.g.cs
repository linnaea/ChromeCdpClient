using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Target;
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct TargetID {
public string Value {get;set;}
public static implicit operator string(TargetID v) => v.Value;
public static implicit operator TargetID(string v) => new() {Value=v};
}

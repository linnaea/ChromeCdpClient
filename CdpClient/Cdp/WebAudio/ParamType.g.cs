using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Enum of AudioParam types
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct ParamType {
public string Value {get;set;}
public static implicit operator string(ParamType v) => v.Value;
public static implicit operator ParamType(string v) => new() {Value=v};
}

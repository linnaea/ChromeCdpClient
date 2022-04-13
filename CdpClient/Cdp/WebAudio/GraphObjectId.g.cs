using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// An unique ID for a graph object (AudioContext, AudioNode, AudioParam) in Web Audio API
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct GraphObjectId {
public string Value {get;set;}
public static implicit operator string(GraphObjectId v) => v.Value;
public static implicit operator GraphObjectId(string v) => new() {Value=v};
}

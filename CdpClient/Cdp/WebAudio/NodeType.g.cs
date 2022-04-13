using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.WebAudio;
/// <summary>
/// Enum of AudioNode types
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct NodeType {
public string Value {get;set;}
public static implicit operator string(NodeType v) => v.Value;
public static implicit operator NodeType(string v) => new() {Value=v};
}

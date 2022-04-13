using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.IO;
/// <summary>
/// This is either obtained from another method or specified as `blob:&lt;uuid&gt;` where
/// `&lt;uuid&gt` is an UUID of a Blob.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct StreamHandle {
public string Value {get;set;}
public static implicit operator string(StreamHandle v) => v.Value;
public static implicit operator StreamHandle(string v) => new() {Value=v};
}

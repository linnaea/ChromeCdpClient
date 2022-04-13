using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.HeapProfiler;
/// <summary>
/// Heap snapshot object id.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct HeapSnapshotObjectId {
public string Value {get;set;}
public static implicit operator string(HeapSnapshotObjectId v) => v.Value;
public static implicit operator HeapSnapshotObjectId(string v) => new() {Value=v};
}

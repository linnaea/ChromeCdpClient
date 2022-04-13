using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.LayerTree;
/// <summary>
/// Unique snapshot identifier.
/// </summary>
[JsonConverter(typeof(AliasedTypeValueConverter))]
public partial struct SnapshotId {
public string Value {get;set;}
public static implicit operator string(SnapshotId v) => v.Value;
public static implicit operator SnapshotId(string v) => new() {Value=v};
}

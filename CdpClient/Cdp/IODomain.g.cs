using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
/// <summary>
/// Input/Output operations for streams produced by DevTools.
/// </summary>
public sealed partial class IODomain {
private readonly ConnectedTarget _target;
public IODomain(ConnectedTarget target) => _target = target;
public sealed partial class CloseParams {
/// <summary>
/// Handle of the stream to close.
/// </summary>
[JsonPropertyName("handle")]public IO.StreamHandle Handle{get;set;}
}
/// <summary>
/// Close the stream, discard any temporary backing storage.
/// </summary>
/// <param name="handle">Handle of the stream to close.</param>
public async Task Close(
 IO.StreamHandle @handle) {
var resp = await _target.SendRequest("IO.close",
new CloseParams {
Handle=@handle,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ReadParams {
/// <summary>
/// Handle of the stream to read.
/// </summary>
[JsonPropertyName("handle")]public IO.StreamHandle Handle{get;set;}
/// <summary>
/// Seek to the specified offset before reading (if not specificed, proceed with offset
/// following the last read). Some types of streams may only support sequential reads.
/// </summary>
[JsonPropertyName("offset")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Offset{get;set;}
/// <summary>
/// Maximum number of bytes to read (left upon the agent discretion if not specified).
/// </summary>
[JsonPropertyName("size")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Size{get;set;}
}
public sealed partial class ReadReturn {
/// <summary>
/// Set if the data is base64-encoded
/// </summary>
[JsonPropertyName("base64Encoded")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? Base64Encoded{get;set;}
/// <summary>
/// Data that were read.
/// </summary>
[JsonPropertyName("data")]public string Data{get;set;}
/// <summary>
/// Set if the end-of-file condition occurred while reading.
/// </summary>
[JsonPropertyName("eof")]public bool Eof{get;set;}
}
/// <summary>
/// Read a chunk of the stream
/// </summary>
/// <param name="handle">Handle of the stream to read.</param>
/// <param name="offset">Seek to the specified offset before reading (if not specificed, proceed with offset
/// following the last read). Some types of streams may only support sequential reads.</param>
/// <param name="size">Maximum number of bytes to read (left upon the agent discretion if not specified).</param>
public async Task<ReadReturn> Read(
 IO.StreamHandle @handle,long? @offset=default,long? @size=default) {
var resp = await _target.SendRequest("IO.read",
new ReadParams {
Handle=@handle,Offset=@offset,Size=@size,});
return _target.DeserializeResponse<ReadReturn>(resp);
}
public sealed partial class ResolveBlobParams {
/// <summary>
/// Object id of a Blob object wrapper.
/// </summary>
[JsonPropertyName("objectId")]public Runtime.RemoteObjectId ObjectId{get;set;}
}
public sealed partial class ResolveBlobReturn {
/// <summary>
/// UUID of the specified Blob.
/// </summary>
[JsonPropertyName("uuid")]public string Uuid{get;set;}
}
/// <summary>
/// Return UUID of Blob object specified by a remote object id.
/// </summary>
/// <param name="objectId">Object id of a Blob object wrapper.</param>
public async Task<ResolveBlobReturn> ResolveBlob(
 Runtime.RemoteObjectId @objectId) {
var resp = await _target.SendRequest("IO.resolveBlob",
new ResolveBlobParams {
ObjectId=@objectId,});
return _target.DeserializeResponse<ResolveBlobReturn>(resp);
}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
}
}

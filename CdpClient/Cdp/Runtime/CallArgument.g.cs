using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
/// <summary>
/// Represents function call argument. Either remote object id `objectId`, primitive `value`,
/// unserializable primitive value or neither of (for undefined) them should be specified.
/// </summary>
public sealed partial class CallArgument {
/// <summary>
/// Primitive value or serializable javascript object.
/// </summary>
[JsonPropertyName("value")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public object? Value{get;set;}
/// <summary>
/// Primitive value which can not be JSON-stringified.
/// </summary>
[JsonPropertyName("unserializableValue")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public UnserializableValue? UnserializableValue{get;set;}
/// <summary>
/// Remote object handle.
/// </summary>
[JsonPropertyName("objectId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObjectId? ObjectId{get;set;}
}

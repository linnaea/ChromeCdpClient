using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Runtime;
[Experimental]public sealed partial class CustomPreview {
/// <summary>
/// The JSON-stringified result of formatter.header(object, config) call.
/// It contains json ML array that represents RemoteObject.
/// </summary>
[JsonPropertyName("header")]public string Header{get;set;}
/// <summary>
/// If formatter returns true as a result of formatter.hasBody call then bodyGetterId will
/// contain RemoteObjectId for the function that returns result of formatter.body(object, config) call.
/// The result value is json ML array.
/// </summary>
[JsonPropertyName("bodyGetterId")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RemoteObjectId? BodyGetterId{get;set;}
}

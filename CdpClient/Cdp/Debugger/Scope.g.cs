using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Debugger;
/// <summary>
/// Scope description.
/// </summary>
public sealed partial class Scope {
/// <summary>
/// Scope type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TypeEnum {
[EnumMember(Value = "global")] Global,
[EnumMember(Value = "local")] Local,
[EnumMember(Value = "with")] With,
[EnumMember(Value = "closure")] Closure,
[EnumMember(Value = "catch")] Catch,
[EnumMember(Value = "block")] Block,
[EnumMember(Value = "script")] Script,
[EnumMember(Value = "eval")] Eval,
[EnumMember(Value = "module")] Module,
[EnumMember(Value = "wasm-expression-stack")] WasmExpressionStack,
}
[JsonPropertyName("type")]public TypeEnum Type{get;set;}
/// <summary>
/// Object representing the scope. For `global` and `with` scopes it represents the actual
/// object; for the rest of the scopes, it is artificial transient object enumerating scope
/// variables as its properties.
/// </summary>
[JsonPropertyName("object")]public Runtime.RemoteObject Object{get;set;}
[JsonPropertyName("name")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string? Name{get;set;}
/// <summary>
/// Location in the source code where scope starts
/// </summary>
[JsonPropertyName("startLocation")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Location? StartLocation{get;set;}
/// <summary>
/// Location in the source code where scope ends
/// </summary>
[JsonPropertyName("endLocation")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public Location? EndLocation{get;set;}
}

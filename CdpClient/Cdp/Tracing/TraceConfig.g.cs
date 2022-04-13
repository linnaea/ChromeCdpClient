using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Tracing;
public sealed partial class TraceConfig {
/// <summary>
/// Controls how the trace buffer stores data.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum RecordModeEnum {
[EnumMember(Value = "recordUntilFull")] RecordUntilFull,
[EnumMember(Value = "recordContinuously")] RecordContinuously,
[EnumMember(Value = "recordAsMuchAsPossible")] RecordAsMuchAsPossible,
[EnumMember(Value = "echoToConsole")] EchoToConsole,
}
[JsonPropertyName("recordMode")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public RecordModeEnum? RecordMode{get;set;}
/// <summary>
/// Turns on JavaScript stack sampling.
/// </summary>
[JsonPropertyName("enableSampling")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? EnableSampling{get;set;}
/// <summary>
/// Turns on system tracing.
/// </summary>
[JsonPropertyName("enableSystrace")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? EnableSystrace{get;set;}
/// <summary>
/// Turns on argument filter.
/// </summary>
[JsonPropertyName("enableArgumentFilter")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public bool? EnableArgumentFilter{get;set;}
/// <summary>
/// Included category filters.
/// </summary>
[JsonPropertyName("includedCategories")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? IncludedCategories{get;set;}
/// <summary>
/// Excluded category filters.
/// </summary>
[JsonPropertyName("excludedCategories")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? ExcludedCategories{get;set;}
/// <summary>
/// Configuration to synthesize the delays in tracing.
/// </summary>
[JsonPropertyName("syntheticDelays")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public string[]? SyntheticDelays{get;set;}
/// <summary>
/// Configuration for memory dump triggers. Used only when "memory-infra" category is enabled.
/// </summary>
[JsonPropertyName("memoryDumpConfig")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public MemoryDumpConfig? MemoryDumpConfig{get;set;}
}

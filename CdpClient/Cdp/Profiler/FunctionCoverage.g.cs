using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Profiler;
/// <summary>
/// Coverage data for a JavaScript function.
/// </summary>
public sealed partial class FunctionCoverage {
/// <summary>
/// JavaScript function name.
/// </summary>
[JsonPropertyName("functionName")]public string FunctionName{get;set;}
/// <summary>
/// Source ranges inside the function with coverage data.
/// </summary>
[JsonPropertyName("ranges")]public CoverageRange[] Ranges{get;set;}
/// <summary>
/// Whether coverage data for this function has block granularity.
/// </summary>
[JsonPropertyName("isBlockCoverage")]public bool IsBlockCoverage{get;set;}
}

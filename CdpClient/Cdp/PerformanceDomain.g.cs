using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
public sealed partial class PerformanceDomain {
private readonly ConnectedTarget _target;
public PerformanceDomain(ConnectedTarget target) => _target = target;
/// <summary>
/// Disable collecting and reporting metrics.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("Performance.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class EnableParams {
/// <summary>
/// Time domain to use for collecting and reporting duration metrics.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TimeDomainEnum {
[EnumMember(Value = "timeTicks")] TimeTicks,
[EnumMember(Value = "threadTicks")] ThreadTicks,
}
[JsonPropertyName("timeDomain")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public TimeDomainEnum? TimeDomain{get;set;}
}
/// <summary>
/// Enable collecting and reporting metrics.
/// </summary>
/// <param name="timeDomain">Time domain to use for collecting and reporting duration metrics.</param>
public async Task Enable(
 EnableParams.TimeDomainEnum? @timeDomain=default) {
var resp = await _target.SendRequest("Performance.enable",
new EnableParams {
TimeDomain=@timeDomain,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class SetTimeDomainParams {
/// <summary>
/// Time domain
/// </summary>
[JsonConverter(typeof(StringEnumConverter))] public enum TimeDomainEnum {
[EnumMember(Value = "timeTicks")] TimeTicks,
[EnumMember(Value = "threadTicks")] ThreadTicks,
}
[JsonPropertyName("timeDomain")]public TimeDomainEnum TimeDomain{get;set;}
}
/// <summary>
/// Sets time domain to use for collecting and reporting duration metrics.
/// Note that this must be called before enabling metrics collection. Calling
/// this method while metrics collection is enabled returns an error.
/// </summary>
/// <param name="timeDomain">Time domain</param>
[Experimental][Obsolete]public async Task SetTimeDomain(
 SetTimeDomainParams.TimeDomainEnum @timeDomain) {
var resp = await _target.SendRequest("Performance.setTimeDomain",
new SetTimeDomainParams {
TimeDomain=@timeDomain,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class GetMetricsReturn {
/// <summary>
/// Current values for run-time metrics.
/// </summary>
[JsonPropertyName("metrics")]public Performance.Metric[] Metrics{get;set;}
}
/// <summary>
/// Retrieve current values of run-time metrics.
/// </summary>
public async Task<GetMetricsReturn> GetMetrics(
) {
var resp = await _target.SendRequest("Performance.getMetrics",
VoidData.Instance);
return _target.DeserializeResponse<GetMetricsReturn>(resp);
}
public sealed partial class MetricsParams {
/// <summary>
/// Current values of the metrics.
/// </summary>
[JsonPropertyName("metrics")]public Performance.Metric[] Metrics{get;set;}
/// <summary>
/// Timestamp title.
/// </summary>
[JsonPropertyName("title")]public string Title{get;set;}
}
private Action<MetricsParams>? _onMetrics;
/// <summary>
/// Current values of the metrics.
/// </summary>
public event Action<MetricsParams> OnMetrics {
add => _onMetrics += value; remove => _onMetrics -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "Performance.metrics":
_onMetrics?.Invoke(_target.DeserializeEvent<MetricsParams>(data));
break;
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
public void DisconnectEvents() {
_onUnknownEvent = null;
_onMetrics = null;
}
}

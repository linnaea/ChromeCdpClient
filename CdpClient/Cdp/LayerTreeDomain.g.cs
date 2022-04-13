using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp;
[Experimental]public sealed partial class LayerTreeDomain {
private readonly ConnectedTarget _target;
public LayerTreeDomain(ConnectedTarget target) => _target = target;
public sealed partial class CompositingReasonsParams {
/// <summary>
/// The id of the layer for which we want to get the reasons it was composited.
/// </summary>
[JsonPropertyName("layerId")]public LayerTree.LayerId LayerId{get;set;}
}
public sealed partial class CompositingReasonsReturn {
/// <summary>
/// A list of strings specifying reasons for the given layer to become composited.
/// </summary>
[Obsolete][JsonPropertyName("compositingReasons")]public string[] CompositingReasons{get;set;}
/// <summary>
/// A list of strings specifying reason IDs for the given layer to become composited.
/// </summary>
[JsonPropertyName("compositingReasonIds")]public string[] CompositingReasonIds{get;set;}
}
/// <summary>
/// Provides the reasons why the given layer was composited.
/// </summary>
/// <param name="layerId">The id of the layer for which we want to get the reasons it was composited.</param>
public async Task<CompositingReasonsReturn> CompositingReasons(
 LayerTree.LayerId @layerId) {
var resp = await _target.SendRequest("LayerTree.compositingReasons",
new CompositingReasonsParams {
LayerId=@layerId,});
return _target.DeserializeResponse<CompositingReasonsReturn>(resp);
}
/// <summary>
/// Disables compositing tree inspection.
/// </summary>
public async Task Disable(
) {
var resp = await _target.SendRequest("LayerTree.disable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
/// <summary>
/// Enables compositing tree inspection.
/// </summary>
public async Task Enable(
) {
var resp = await _target.SendRequest("LayerTree.enable",
VoidData.Instance);
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class LoadSnapshotParams {
/// <summary>
/// An array of tiles composing the snapshot.
/// </summary>
[JsonPropertyName("tiles")]public LayerTree.PictureTile[] Tiles{get;set;}
}
public sealed partial class LoadSnapshotReturn {
/// <summary>
/// The id of the snapshot.
/// </summary>
[JsonPropertyName("snapshotId")]public LayerTree.SnapshotId SnapshotId{get;set;}
}
/// <summary>
/// Returns the snapshot identifier.
/// </summary>
/// <param name="tiles">An array of tiles composing the snapshot.</param>
public async Task<LoadSnapshotReturn> LoadSnapshot(
 LayerTree.PictureTile[] @tiles) {
var resp = await _target.SendRequest("LayerTree.loadSnapshot",
new LoadSnapshotParams {
Tiles=@tiles,});
return _target.DeserializeResponse<LoadSnapshotReturn>(resp);
}
public sealed partial class MakeSnapshotParams {
/// <summary>
/// The id of the layer.
/// </summary>
[JsonPropertyName("layerId")]public LayerTree.LayerId LayerId{get;set;}
}
public sealed partial class MakeSnapshotReturn {
/// <summary>
/// The id of the layer snapshot.
/// </summary>
[JsonPropertyName("snapshotId")]public LayerTree.SnapshotId SnapshotId{get;set;}
}
/// <summary>
/// Returns the layer snapshot identifier.
/// </summary>
/// <param name="layerId">The id of the layer.</param>
public async Task<MakeSnapshotReturn> MakeSnapshot(
 LayerTree.LayerId @layerId) {
var resp = await _target.SendRequest("LayerTree.makeSnapshot",
new MakeSnapshotParams {
LayerId=@layerId,});
return _target.DeserializeResponse<MakeSnapshotReturn>(resp);
}
public sealed partial class ProfileSnapshotParams {
/// <summary>
/// The id of the layer snapshot.
/// </summary>
[JsonPropertyName("snapshotId")]public LayerTree.SnapshotId SnapshotId{get;set;}
/// <summary>
/// The maximum number of times to replay the snapshot (1, if not specified).
/// </summary>
[JsonPropertyName("minRepeatCount")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? MinRepeatCount{get;set;}
/// <summary>
/// The minimum duration (in seconds) to replay the snapshot.
/// </summary>
[JsonPropertyName("minDuration")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? MinDuration{get;set;}
/// <summary>
/// The clip rectangle to apply when replaying the snapshot.
/// </summary>
[JsonPropertyName("clipRect")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public DOM.Rect? ClipRect{get;set;}
}
public sealed partial class ProfileSnapshotReturn {
/// <summary>
/// The array of paint profiles, one per run.
/// </summary>
[JsonPropertyName("timings")]public LayerTree.PaintProfile[] Timings{get;set;}
}
/// <param name="snapshotId">The id of the layer snapshot.</param>
/// <param name="minRepeatCount">The maximum number of times to replay the snapshot (1, if not specified).</param>
/// <param name="minDuration">The minimum duration (in seconds) to replay the snapshot.</param>
/// <param name="clipRect">The clip rectangle to apply when replaying the snapshot.</param>
public async Task<ProfileSnapshotReturn> ProfileSnapshot(
 LayerTree.SnapshotId @snapshotId,long? @minRepeatCount=default,double? @minDuration=default,DOM.Rect? @clipRect=default) {
var resp = await _target.SendRequest("LayerTree.profileSnapshot",
new ProfileSnapshotParams {
SnapshotId=@snapshotId,MinRepeatCount=@minRepeatCount,MinDuration=@minDuration,ClipRect=@clipRect,});
return _target.DeserializeResponse<ProfileSnapshotReturn>(resp);
}
public sealed partial class ReleaseSnapshotParams {
/// <summary>
/// The id of the layer snapshot.
/// </summary>
[JsonPropertyName("snapshotId")]public LayerTree.SnapshotId SnapshotId{get;set;}
}
/// <summary>
/// Releases layer snapshot captured by the back-end.
/// </summary>
/// <param name="snapshotId">The id of the layer snapshot.</param>
public async Task ReleaseSnapshot(
 LayerTree.SnapshotId @snapshotId) {
var resp = await _target.SendRequest("LayerTree.releaseSnapshot",
new ReleaseSnapshotParams {
SnapshotId=@snapshotId,});
_target.DeserializeResponse<VoidData>(resp);
}
public sealed partial class ReplaySnapshotParams {
/// <summary>
/// The id of the layer snapshot.
/// </summary>
[JsonPropertyName("snapshotId")]public LayerTree.SnapshotId SnapshotId{get;set;}
/// <summary>
/// The first step to replay from (replay from the very start if not specified).
/// </summary>
[JsonPropertyName("fromStep")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? FromStep{get;set;}
/// <summary>
/// The last step to replay to (replay till the end if not specified).
/// </summary>
[JsonPropertyName("toStep")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? ToStep{get;set;}
/// <summary>
/// The scale to apply while replaying (defaults to 1).
/// </summary>
[JsonPropertyName("scale")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Scale{get;set;}
}
public sealed partial class ReplaySnapshotReturn {
/// <summary>
/// A data: URL for resulting image.
/// </summary>
[JsonPropertyName("dataURL")]public string DataURL{get;set;}
}
/// <summary>
/// Replays the layer snapshot and returns the resulting bitmap.
/// </summary>
/// <param name="snapshotId">The id of the layer snapshot.</param>
/// <param name="fromStep">The first step to replay from (replay from the very start if not specified).</param>
/// <param name="toStep">The last step to replay to (replay till the end if not specified).</param>
/// <param name="scale">The scale to apply while replaying (defaults to 1).</param>
public async Task<ReplaySnapshotReturn> ReplaySnapshot(
 LayerTree.SnapshotId @snapshotId,long? @fromStep=default,long? @toStep=default,double? @scale=default) {
var resp = await _target.SendRequest("LayerTree.replaySnapshot",
new ReplaySnapshotParams {
SnapshotId=@snapshotId,FromStep=@fromStep,ToStep=@toStep,Scale=@scale,});
return _target.DeserializeResponse<ReplaySnapshotReturn>(resp);
}
public sealed partial class SnapshotCommandLogParams {
/// <summary>
/// The id of the layer snapshot.
/// </summary>
[JsonPropertyName("snapshotId")]public LayerTree.SnapshotId SnapshotId{get;set;}
}
public sealed partial class SnapshotCommandLogReturn {
/// <summary>
/// The array of canvas function calls.
/// </summary>
[JsonPropertyName("commandLog")]public object[] CommandLog{get;set;}
}
/// <summary>
/// Replays the layer snapshot and returns canvas log.
/// </summary>
/// <param name="snapshotId">The id of the layer snapshot.</param>
public async Task<SnapshotCommandLogReturn> SnapshotCommandLog(
 LayerTree.SnapshotId @snapshotId) {
var resp = await _target.SendRequest("LayerTree.snapshotCommandLog",
new SnapshotCommandLogParams {
SnapshotId=@snapshotId,});
return _target.DeserializeResponse<SnapshotCommandLogReturn>(resp);
}
public sealed partial class LayerPaintedParams {
/// <summary>
/// The id of the painted layer.
/// </summary>
[JsonPropertyName("layerId")]public LayerTree.LayerId LayerId{get;set;}
/// <summary>
/// Clip rectangle.
/// </summary>
[JsonPropertyName("clip")]public DOM.Rect Clip{get;set;}
}
private Action<LayerPaintedParams>? _onLayerPainted;
public event Action<LayerPaintedParams> OnLayerPainted {
add => _onLayerPainted += value; remove => _onLayerPainted -= value;}
public sealed partial class LayerTreeDidChangeParams {
/// <summary>
/// Layer tree, absent if not in the comspositing mode.
/// </summary>
[JsonPropertyName("layers")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public LayerTree.Layer[]? Layers{get;set;}
}
private Action<LayerTreeDidChangeParams>? _onLayerTreeDidChange;
public event Action<LayerTreeDidChangeParams> OnLayerTreeDidChange {
add => _onLayerTreeDidChange += value; remove => _onLayerTreeDidChange -= value;}
public void DispatchEvent(string method, ArraySegment<byte> data) {
switch (method) {
case "LayerTree.layerPainted":
_onLayerPainted?.Invoke(_target.DeserializeEvent<LayerPaintedParams>(data));
break;
case "LayerTree.layerTreeDidChange":
_onLayerTreeDidChange?.Invoke(_target.DeserializeEvent<LayerTreeDidChangeParams>(data));
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
_onLayerPainted = null;
_onLayerTreeDidChange = null;
}
}

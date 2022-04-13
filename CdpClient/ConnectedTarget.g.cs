using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient;
partial class ConnectedTarget {
private Cdp.ConsoleDomain? _domConsole;
public Cdp.ConsoleDomain Console {get{
if(_domConsole != null) return _domConsole;
var a = new Cdp.ConsoleDomain(this);
var b = Interlocked.CompareExchange(ref _domConsole, a, null);
return b ?? a;}}
private Cdp.DebuggerDomain? _domDebugger;
public Cdp.DebuggerDomain Debugger {get{
if(_domDebugger != null) return _domDebugger;
var a = new Cdp.DebuggerDomain(this);
var b = Interlocked.CompareExchange(ref _domDebugger, a, null);
return b ?? a;}}
private Cdp.HeapProfilerDomain? _domHeapProfiler;
public Cdp.HeapProfilerDomain HeapProfiler {get{
if(_domHeapProfiler != null) return _domHeapProfiler;
var a = new Cdp.HeapProfilerDomain(this);
var b = Interlocked.CompareExchange(ref _domHeapProfiler, a, null);
return b ?? a;}}
private Cdp.ProfilerDomain? _domProfiler;
public Cdp.ProfilerDomain Profiler {get{
if(_domProfiler != null) return _domProfiler;
var a = new Cdp.ProfilerDomain(this);
var b = Interlocked.CompareExchange(ref _domProfiler, a, null);
return b ?? a;}}
private Cdp.RuntimeDomain? _domRuntime;
public Cdp.RuntimeDomain Runtime {get{
if(_domRuntime != null) return _domRuntime;
var a = new Cdp.RuntimeDomain(this);
var b = Interlocked.CompareExchange(ref _domRuntime, a, null);
return b ?? a;}}
private Cdp.SchemaDomain? _domSchema;
public Cdp.SchemaDomain Schema {get{
if(_domSchema != null) return _domSchema;
var a = new Cdp.SchemaDomain(this);
var b = Interlocked.CompareExchange(ref _domSchema, a, null);
return b ?? a;}}
private Cdp.AccessibilityDomain? _domAccessibility;
public Cdp.AccessibilityDomain Accessibility {get{
if(_domAccessibility != null) return _domAccessibility;
var a = new Cdp.AccessibilityDomain(this);
var b = Interlocked.CompareExchange(ref _domAccessibility, a, null);
return b ?? a;}}
private Cdp.AnimationDomain? _domAnimation;
public Cdp.AnimationDomain Animation {get{
if(_domAnimation != null) return _domAnimation;
var a = new Cdp.AnimationDomain(this);
var b = Interlocked.CompareExchange(ref _domAnimation, a, null);
return b ?? a;}}
private Cdp.AuditsDomain? _domAudits;
public Cdp.AuditsDomain Audits {get{
if(_domAudits != null) return _domAudits;
var a = new Cdp.AuditsDomain(this);
var b = Interlocked.CompareExchange(ref _domAudits, a, null);
return b ?? a;}}
private Cdp.BackgroundServiceDomain? _domBackgroundService;
public Cdp.BackgroundServiceDomain BackgroundService {get{
if(_domBackgroundService != null) return _domBackgroundService;
var a = new Cdp.BackgroundServiceDomain(this);
var b = Interlocked.CompareExchange(ref _domBackgroundService, a, null);
return b ?? a;}}
private Cdp.BrowserDomain? _domBrowser;
public Cdp.BrowserDomain Browser {get{
if(_domBrowser != null) return _domBrowser;
var a = new Cdp.BrowserDomain(this);
var b = Interlocked.CompareExchange(ref _domBrowser, a, null);
return b ?? a;}}
private Cdp.CSSDomain? _domCSS;
public Cdp.CSSDomain CSS {get{
if(_domCSS != null) return _domCSS;
var a = new Cdp.CSSDomain(this);
var b = Interlocked.CompareExchange(ref _domCSS, a, null);
return b ?? a;}}
private Cdp.CacheStorageDomain? _domCacheStorage;
public Cdp.CacheStorageDomain CacheStorage {get{
if(_domCacheStorage != null) return _domCacheStorage;
var a = new Cdp.CacheStorageDomain(this);
var b = Interlocked.CompareExchange(ref _domCacheStorage, a, null);
return b ?? a;}}
private Cdp.CastDomain? _domCast;
public Cdp.CastDomain Cast {get{
if(_domCast != null) return _domCast;
var a = new Cdp.CastDomain(this);
var b = Interlocked.CompareExchange(ref _domCast, a, null);
return b ?? a;}}
private Cdp.DOMDomain? _domDOM;
public Cdp.DOMDomain DOM {get{
if(_domDOM != null) return _domDOM;
var a = new Cdp.DOMDomain(this);
var b = Interlocked.CompareExchange(ref _domDOM, a, null);
return b ?? a;}}
private Cdp.DOMDebuggerDomain? _domDOMDebugger;
public Cdp.DOMDebuggerDomain DOMDebugger {get{
if(_domDOMDebugger != null) return _domDOMDebugger;
var a = new Cdp.DOMDebuggerDomain(this);
var b = Interlocked.CompareExchange(ref _domDOMDebugger, a, null);
return b ?? a;}}
private Cdp.EventBreakpointsDomain? _domEventBreakpoints;
public Cdp.EventBreakpointsDomain EventBreakpoints {get{
if(_domEventBreakpoints != null) return _domEventBreakpoints;
var a = new Cdp.EventBreakpointsDomain(this);
var b = Interlocked.CompareExchange(ref _domEventBreakpoints, a, null);
return b ?? a;}}
private Cdp.DOMSnapshotDomain? _domDOMSnapshot;
public Cdp.DOMSnapshotDomain DOMSnapshot {get{
if(_domDOMSnapshot != null) return _domDOMSnapshot;
var a = new Cdp.DOMSnapshotDomain(this);
var b = Interlocked.CompareExchange(ref _domDOMSnapshot, a, null);
return b ?? a;}}
private Cdp.DOMStorageDomain? _domDOMStorage;
public Cdp.DOMStorageDomain DOMStorage {get{
if(_domDOMStorage != null) return _domDOMStorage;
var a = new Cdp.DOMStorageDomain(this);
var b = Interlocked.CompareExchange(ref _domDOMStorage, a, null);
return b ?? a;}}
private Cdp.DatabaseDomain? _domDatabase;
public Cdp.DatabaseDomain Database {get{
if(_domDatabase != null) return _domDatabase;
var a = new Cdp.DatabaseDomain(this);
var b = Interlocked.CompareExchange(ref _domDatabase, a, null);
return b ?? a;}}
private Cdp.DeviceOrientationDomain? _domDeviceOrientation;
public Cdp.DeviceOrientationDomain DeviceOrientation {get{
if(_domDeviceOrientation != null) return _domDeviceOrientation;
var a = new Cdp.DeviceOrientationDomain(this);
var b = Interlocked.CompareExchange(ref _domDeviceOrientation, a, null);
return b ?? a;}}
private Cdp.EmulationDomain? _domEmulation;
public Cdp.EmulationDomain Emulation {get{
if(_domEmulation != null) return _domEmulation;
var a = new Cdp.EmulationDomain(this);
var b = Interlocked.CompareExchange(ref _domEmulation, a, null);
return b ?? a;}}
private Cdp.HeadlessExperimentalDomain? _domHeadlessExperimental;
public Cdp.HeadlessExperimentalDomain HeadlessExperimental {get{
if(_domHeadlessExperimental != null) return _domHeadlessExperimental;
var a = new Cdp.HeadlessExperimentalDomain(this);
var b = Interlocked.CompareExchange(ref _domHeadlessExperimental, a, null);
return b ?? a;}}
private Cdp.IODomain? _domIO;
public Cdp.IODomain IO {get{
if(_domIO != null) return _domIO;
var a = new Cdp.IODomain(this);
var b = Interlocked.CompareExchange(ref _domIO, a, null);
return b ?? a;}}
private Cdp.IndexedDBDomain? _domIndexedDB;
public Cdp.IndexedDBDomain IndexedDB {get{
if(_domIndexedDB != null) return _domIndexedDB;
var a = new Cdp.IndexedDBDomain(this);
var b = Interlocked.CompareExchange(ref _domIndexedDB, a, null);
return b ?? a;}}
private Cdp.InputDomain? _domInput;
public Cdp.InputDomain Input {get{
if(_domInput != null) return _domInput;
var a = new Cdp.InputDomain(this);
var b = Interlocked.CompareExchange(ref _domInput, a, null);
return b ?? a;}}
private Cdp.InspectorDomain? _domInspector;
public Cdp.InspectorDomain Inspector {get{
if(_domInspector != null) return _domInspector;
var a = new Cdp.InspectorDomain(this);
var b = Interlocked.CompareExchange(ref _domInspector, a, null);
return b ?? a;}}
private Cdp.LayerTreeDomain? _domLayerTree;
public Cdp.LayerTreeDomain LayerTree {get{
if(_domLayerTree != null) return _domLayerTree;
var a = new Cdp.LayerTreeDomain(this);
var b = Interlocked.CompareExchange(ref _domLayerTree, a, null);
return b ?? a;}}
private Cdp.LogDomain? _domLog;
public Cdp.LogDomain Log {get{
if(_domLog != null) return _domLog;
var a = new Cdp.LogDomain(this);
var b = Interlocked.CompareExchange(ref _domLog, a, null);
return b ?? a;}}
private Cdp.MemoryDomain? _domMemory;
public Cdp.MemoryDomain Memory {get{
if(_domMemory != null) return _domMemory;
var a = new Cdp.MemoryDomain(this);
var b = Interlocked.CompareExchange(ref _domMemory, a, null);
return b ?? a;}}
private Cdp.NetworkDomain? _domNetwork;
public Cdp.NetworkDomain Network {get{
if(_domNetwork != null) return _domNetwork;
var a = new Cdp.NetworkDomain(this);
var b = Interlocked.CompareExchange(ref _domNetwork, a, null);
return b ?? a;}}
private Cdp.OverlayDomain? _domOverlay;
public Cdp.OverlayDomain Overlay {get{
if(_domOverlay != null) return _domOverlay;
var a = new Cdp.OverlayDomain(this);
var b = Interlocked.CompareExchange(ref _domOverlay, a, null);
return b ?? a;}}
private Cdp.PageDomain? _domPage;
public Cdp.PageDomain Page {get{
if(_domPage != null) return _domPage;
var a = new Cdp.PageDomain(this);
var b = Interlocked.CompareExchange(ref _domPage, a, null);
return b ?? a;}}
private Cdp.PerformanceDomain? _domPerformance;
public Cdp.PerformanceDomain Performance {get{
if(_domPerformance != null) return _domPerformance;
var a = new Cdp.PerformanceDomain(this);
var b = Interlocked.CompareExchange(ref _domPerformance, a, null);
return b ?? a;}}
private Cdp.PerformanceTimelineDomain? _domPerformanceTimeline;
public Cdp.PerformanceTimelineDomain PerformanceTimeline {get{
if(_domPerformanceTimeline != null) return _domPerformanceTimeline;
var a = new Cdp.PerformanceTimelineDomain(this);
var b = Interlocked.CompareExchange(ref _domPerformanceTimeline, a, null);
return b ?? a;}}
private Cdp.SecurityDomain? _domSecurity;
public Cdp.SecurityDomain Security {get{
if(_domSecurity != null) return _domSecurity;
var a = new Cdp.SecurityDomain(this);
var b = Interlocked.CompareExchange(ref _domSecurity, a, null);
return b ?? a;}}
private Cdp.ServiceWorkerDomain? _domServiceWorker;
public Cdp.ServiceWorkerDomain ServiceWorker {get{
if(_domServiceWorker != null) return _domServiceWorker;
var a = new Cdp.ServiceWorkerDomain(this);
var b = Interlocked.CompareExchange(ref _domServiceWorker, a, null);
return b ?? a;}}
private Cdp.StorageDomain? _domStorage;
public Cdp.StorageDomain Storage {get{
if(_domStorage != null) return _domStorage;
var a = new Cdp.StorageDomain(this);
var b = Interlocked.CompareExchange(ref _domStorage, a, null);
return b ?? a;}}
private Cdp.SystemInfoDomain? _domSystemInfo;
public Cdp.SystemInfoDomain SystemInfo {get{
if(_domSystemInfo != null) return _domSystemInfo;
var a = new Cdp.SystemInfoDomain(this);
var b = Interlocked.CompareExchange(ref _domSystemInfo, a, null);
return b ?? a;}}
private Cdp.TargetDomain? _domTarget;
public Cdp.TargetDomain Target {get{
if(_domTarget != null) return _domTarget;
var a = new Cdp.TargetDomain(this);
var b = Interlocked.CompareExchange(ref _domTarget, a, null);
return b ?? a;}}
private Cdp.TetheringDomain? _domTethering;
public Cdp.TetheringDomain Tethering {get{
if(_domTethering != null) return _domTethering;
var a = new Cdp.TetheringDomain(this);
var b = Interlocked.CompareExchange(ref _domTethering, a, null);
return b ?? a;}}
private Cdp.TracingDomain? _domTracing;
public Cdp.TracingDomain Tracing {get{
if(_domTracing != null) return _domTracing;
var a = new Cdp.TracingDomain(this);
var b = Interlocked.CompareExchange(ref _domTracing, a, null);
return b ?? a;}}
private Cdp.FetchDomain? _domFetch;
public Cdp.FetchDomain Fetch {get{
if(_domFetch != null) return _domFetch;
var a = new Cdp.FetchDomain(this);
var b = Interlocked.CompareExchange(ref _domFetch, a, null);
return b ?? a;}}
private Cdp.WebAudioDomain? _domWebAudio;
public Cdp.WebAudioDomain WebAudio {get{
if(_domWebAudio != null) return _domWebAudio;
var a = new Cdp.WebAudioDomain(this);
var b = Interlocked.CompareExchange(ref _domWebAudio, a, null);
return b ?? a;}}
private Cdp.WebAuthnDomain? _domWebAuthn;
public Cdp.WebAuthnDomain WebAuthn {get{
if(_domWebAuthn != null) return _domWebAuthn;
var a = new Cdp.WebAuthnDomain(this);
var b = Interlocked.CompareExchange(ref _domWebAuthn, a, null);
return b ?? a;}}
private Cdp.MediaDomain? _domMedia;
public Cdp.MediaDomain Media {get{
if(_domMedia != null) return _domMedia;
var a = new Cdp.MediaDomain(this);
var b = Interlocked.CompareExchange(ref _domMedia, a, null);
return b ?? a;}}

partial void DispatchEvent(string method, ArraySegment<byte> data) {
switch(method.Split('.')[0]) {
case "Console":
_domConsole?.DispatchEvent(method, data);
break;
case "Debugger":
_domDebugger?.DispatchEvent(method, data);
break;
case "HeapProfiler":
_domHeapProfiler?.DispatchEvent(method, data);
break;
case "Profiler":
_domProfiler?.DispatchEvent(method, data);
break;
case "Runtime":
_domRuntime?.DispatchEvent(method, data);
break;
case "Schema":
_domSchema?.DispatchEvent(method, data);
break;
case "Accessibility":
_domAccessibility?.DispatchEvent(method, data);
break;
case "Animation":
_domAnimation?.DispatchEvent(method, data);
break;
case "Audits":
_domAudits?.DispatchEvent(method, data);
break;
case "BackgroundService":
_domBackgroundService?.DispatchEvent(method, data);
break;
case "Browser":
_domBrowser?.DispatchEvent(method, data);
break;
case "CSS":
_domCSS?.DispatchEvent(method, data);
break;
case "CacheStorage":
_domCacheStorage?.DispatchEvent(method, data);
break;
case "Cast":
_domCast?.DispatchEvent(method, data);
break;
case "DOM":
_domDOM?.DispatchEvent(method, data);
break;
case "DOMDebugger":
_domDOMDebugger?.DispatchEvent(method, data);
break;
case "EventBreakpoints":
_domEventBreakpoints?.DispatchEvent(method, data);
break;
case "DOMSnapshot":
_domDOMSnapshot?.DispatchEvent(method, data);
break;
case "DOMStorage":
_domDOMStorage?.DispatchEvent(method, data);
break;
case "Database":
_domDatabase?.DispatchEvent(method, data);
break;
case "DeviceOrientation":
_domDeviceOrientation?.DispatchEvent(method, data);
break;
case "Emulation":
_domEmulation?.DispatchEvent(method, data);
break;
case "HeadlessExperimental":
_domHeadlessExperimental?.DispatchEvent(method, data);
break;
case "IO":
_domIO?.DispatchEvent(method, data);
break;
case "IndexedDB":
_domIndexedDB?.DispatchEvent(method, data);
break;
case "Input":
_domInput?.DispatchEvent(method, data);
break;
case "Inspector":
_domInspector?.DispatchEvent(method, data);
break;
case "LayerTree":
_domLayerTree?.DispatchEvent(method, data);
break;
case "Log":
_domLog?.DispatchEvent(method, data);
break;
case "Memory":
_domMemory?.DispatchEvent(method, data);
break;
case "Network":
_domNetwork?.DispatchEvent(method, data);
break;
case "Overlay":
_domOverlay?.DispatchEvent(method, data);
break;
case "Page":
_domPage?.DispatchEvent(method, data);
break;
case "Performance":
_domPerformance?.DispatchEvent(method, data);
break;
case "PerformanceTimeline":
_domPerformanceTimeline?.DispatchEvent(method, data);
break;
case "Security":
_domSecurity?.DispatchEvent(method, data);
break;
case "ServiceWorker":
_domServiceWorker?.DispatchEvent(method, data);
break;
case "Storage":
_domStorage?.DispatchEvent(method, data);
break;
case "SystemInfo":
_domSystemInfo?.DispatchEvent(method, data);
break;
case "Target":
_domTarget?.DispatchEvent(method, data);
break;
case "Tethering":
_domTethering?.DispatchEvent(method, data);
break;
case "Tracing":
_domTracing?.DispatchEvent(method, data);
break;
case "Fetch":
_domFetch?.DispatchEvent(method, data);
break;
case "WebAudio":
_domWebAudio?.DispatchEvent(method, data);
break;
case "WebAuthn":
_domWebAuthn?.DispatchEvent(method, data);
break;
case "Media":
_domMedia?.DispatchEvent(method, data);
break;
default:
_onUnknownEvent?.Invoke(method, data);
break;
}}
private Action<string, ArraySegment<byte>>? _onUnknownEvent;
public event Action<string, ArraySegment<byte>> OnUnknownEvent {
add => _onUnknownEvent += value; remove => _onUnknownEvent -= value;}
partial void DisconnectEvents() {
_onUnknownEvent = null;
_domConsole?.DisconnectEvents();
_domConsole = null;
_domDebugger?.DisconnectEvents();
_domDebugger = null;
_domHeapProfiler?.DisconnectEvents();
_domHeapProfiler = null;
_domProfiler?.DisconnectEvents();
_domProfiler = null;
_domRuntime?.DisconnectEvents();
_domRuntime = null;
_domSchema?.DisconnectEvents();
_domSchema = null;
_domAccessibility?.DisconnectEvents();
_domAccessibility = null;
_domAnimation?.DisconnectEvents();
_domAnimation = null;
_domAudits?.DisconnectEvents();
_domAudits = null;
_domBackgroundService?.DisconnectEvents();
_domBackgroundService = null;
_domBrowser?.DisconnectEvents();
_domBrowser = null;
_domCSS?.DisconnectEvents();
_domCSS = null;
_domCacheStorage?.DisconnectEvents();
_domCacheStorage = null;
_domCast?.DisconnectEvents();
_domCast = null;
_domDOM?.DisconnectEvents();
_domDOM = null;
_domDOMDebugger?.DisconnectEvents();
_domDOMDebugger = null;
_domEventBreakpoints?.DisconnectEvents();
_domEventBreakpoints = null;
_domDOMSnapshot?.DisconnectEvents();
_domDOMSnapshot = null;
_domDOMStorage?.DisconnectEvents();
_domDOMStorage = null;
_domDatabase?.DisconnectEvents();
_domDatabase = null;
_domDeviceOrientation?.DisconnectEvents();
_domDeviceOrientation = null;
_domEmulation?.DisconnectEvents();
_domEmulation = null;
_domHeadlessExperimental?.DisconnectEvents();
_domHeadlessExperimental = null;
_domIO?.DisconnectEvents();
_domIO = null;
_domIndexedDB?.DisconnectEvents();
_domIndexedDB = null;
_domInput?.DisconnectEvents();
_domInput = null;
_domInspector?.DisconnectEvents();
_domInspector = null;
_domLayerTree?.DisconnectEvents();
_domLayerTree = null;
_domLog?.DisconnectEvents();
_domLog = null;
_domMemory?.DisconnectEvents();
_domMemory = null;
_domNetwork?.DisconnectEvents();
_domNetwork = null;
_domOverlay?.DisconnectEvents();
_domOverlay = null;
_domPage?.DisconnectEvents();
_domPage = null;
_domPerformance?.DisconnectEvents();
_domPerformance = null;
_domPerformanceTimeline?.DisconnectEvents();
_domPerformanceTimeline = null;
_domSecurity?.DisconnectEvents();
_domSecurity = null;
_domServiceWorker?.DisconnectEvents();
_domServiceWorker = null;
_domStorage?.DisconnectEvents();
_domStorage = null;
_domSystemInfo?.DisconnectEvents();
_domSystemInfo = null;
_domTarget?.DisconnectEvents();
_domTarget = null;
_domTethering?.DisconnectEvents();
_domTethering = null;
_domTracing?.DisconnectEvents();
_domTracing = null;
_domFetch?.DisconnectEvents();
_domFetch = null;
_domWebAudio?.DisconnectEvents();
_domWebAudio = null;
_domWebAuthn?.DisconnectEvents();
_domWebAuthn = null;
_domMedia?.DisconnectEvents();
_domMedia = null;
}
}

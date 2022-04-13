using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
#pragma warning disable 8618,0612
#nullable enable
namespace CdpClient.Cdp.Input;
public sealed partial class TouchPoint {
/// <summary>
/// X coordinate of the event relative to the main frame's viewport in CSS pixels.
/// </summary>
[JsonPropertyName("x")]public double X{get;set;}
/// <summary>
/// Y coordinate of the event relative to the main frame's viewport in CSS pixels. 0 refers to
/// the top of the viewport and Y increases as it proceeds towards the bottom of the viewport.
/// </summary>
[JsonPropertyName("y")]public double Y{get;set;}
/// <summary>
/// X radius of the touch area (default: 1.0).
/// </summary>
[JsonPropertyName("radiusX")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? RadiusX{get;set;}
/// <summary>
/// Y radius of the touch area (default: 1.0).
/// </summary>
[JsonPropertyName("radiusY")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? RadiusY{get;set;}
/// <summary>
/// Rotation angle (default: 0.0).
/// </summary>
[JsonPropertyName("rotationAngle")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? RotationAngle{get;set;}
/// <summary>
/// Force (default: 1.0).
/// </summary>
[JsonPropertyName("force")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Force{get;set;}
/// <summary>
/// The normalized tangential pressure, which has a range of [-1,1] (default: 0).
/// </summary>
[Experimental][JsonPropertyName("tangentialPressure")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? TangentialPressure{get;set;}
/// <summary>
/// The plane angle between the Y-Z plane and the plane containing both the stylus axis and the Y axis, in degrees of the range [-90,90], a positive tiltX is to the right (default: 0)
/// </summary>
[Experimental][JsonPropertyName("tiltX")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? TiltX{get;set;}
/// <summary>
/// The plane angle between the X-Z plane and the plane containing both the stylus axis and the X axis, in degrees of the range [-90,90], a positive tiltY is towards the user (default: 0).
/// </summary>
[Experimental][JsonPropertyName("tiltY")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? TiltY{get;set;}
/// <summary>
/// The clockwise rotation of a pen stylus around its own major axis, in degrees in the range [0,359] (default: 0).
/// </summary>
[Experimental][JsonPropertyName("twist")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public long? Twist{get;set;}
/// <summary>
/// Identifier used to track touch sources between events, must be unique within an event.
/// </summary>
[JsonPropertyName("id")][JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public double? Id{get;set;}
}

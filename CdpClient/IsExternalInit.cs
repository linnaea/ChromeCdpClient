using System;

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit
    { }
}

namespace CdpClient.Cdp
{
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public sealed class ExperimentalAttribute : Attribute
    { }
}

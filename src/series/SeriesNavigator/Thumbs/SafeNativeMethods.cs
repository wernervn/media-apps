using System;
using System.Runtime.InteropServices;
using System.Security;

namespace SeriesNavigator.Thumbs
{
    [SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        //https://msdn.microsoft.com/en-us/library/windows/desktop/dd145062(v=vs.85).aspx
        [DllImport("User32.dll")]
        internal static extern IntPtr MonitorFromPoint([In]System.Drawing.Point pt, [In]uint dwFlags);

        //https://msdn.microsoft.com/en-us/library/windows/desktop/dn280510(v=vs.85).aspx
        [DllImport("Shcore.dll")]
        internal static extern IntPtr GetDpiForMonitor([In]IntPtr hmonitor, [In]DpiType dpiType, [Out]out uint dpiX, [Out]out uint dpiY);

        [DllImport("Kernel32.dll", EntryPoint = "CopyMemory")]
        internal extern static void CopyMemory(IntPtr dest, IntPtr src, uint length);

        //https://msdn.microsoft.com/en-us/library/windows/desktop/dn280511(v=vs.85).aspx
        public enum DpiType
        {
            Effective = 0,
            Angular = 1,
            Raw = 2,
        }
    }
}

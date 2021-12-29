namespace SeriesNavigator.Thumbs;

public static class ScreenExtensions
{
    internal static void GetDpi(this System.Windows.Forms.Screen screen, SafeNativeMethods.DpiType dpiType, out uint dpiX, out uint dpiY)
    {
        var pnt = new System.Drawing.Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
        var mon = SafeNativeMethods.MonitorFromPoint(pnt, 2/*MONITOR_DEFAULTTONEAREST*/);
        _ = SafeNativeMethods.GetDpiForMonitor(mon, dpiType, out dpiX, out dpiY);
    }
}

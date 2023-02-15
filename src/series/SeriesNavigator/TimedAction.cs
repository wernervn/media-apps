using System.Diagnostics;

namespace SeriesNavigator;

#pragma warning disable S3881 // "IDisposable" should be implemented correctly
internal class TimedAction : IDisposable
#pragma warning restore S3881 // "IDisposable" should be implemented correctly
{
    private readonly Stopwatch _sw;
    private readonly string _description;

    public TimedAction(string actionName, Action action)
    {
        _description = actionName;
        _sw = Stopwatch.StartNew();
        action();
        _sw.Stop();
    }

    public void Dispose()
        => Debug.WriteLine($"Time to execute {_description}: {_sw.Elapsed.TotalMilliseconds} ms");
}

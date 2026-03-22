namespace MediaApps.Series.Core.Exceptions;

public class SeriesException : Exception
{
    public SeriesException() : base() { }

    public SeriesException(string message) : base(message) { }

    public SeriesException(string message, Exception innerException) : base(message, innerException) { }
}

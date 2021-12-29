using System.Runtime.Serialization;

namespace MediaApps.Series.Core.Exceptions;

[Serializable]
public class SeriesException : Exception
{
    public SeriesException() : base()
    {
    }

    public SeriesException(string message) : base(message)
    {
    }

    public SeriesException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected SeriesException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

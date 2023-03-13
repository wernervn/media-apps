namespace MovieCollection.Common;

public class CCursor : IDisposable
{
    readonly Cursor saved;

    public CCursor(Cursor newCursor)
    {
        saved = Cursor.Current;

        Cursor.Current = newCursor;
    }

    public void Dispose()
    {
        Cursor.Current = saved;
    }
}

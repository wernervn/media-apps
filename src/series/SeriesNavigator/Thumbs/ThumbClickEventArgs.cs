namespace SeriesNavigator.Thumbs;

/// <summary>
/// Event that is raised when a thumb is clicked (selected)
/// </summary>
public class ThumbClickEventArgs : EventArgs
{
    public ThumbClickEventArgs(int index, string itemName, string description)
    {
        Index = index;
        ItemName = itemName;
        Description = description;
    }

    public int Index { get; }
    public string ItemName { get; }
    public string Description { get; }
}

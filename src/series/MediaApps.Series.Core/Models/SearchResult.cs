namespace MediaApps.Series.Core.Models;

public class SearchResultItem
{
    public SearchResultItem()
    {
    }

    public SearchResultItem(string name, int id)
    {
        SeriesName = name;
        SeriesId = id;
    }

    public string SeriesName { get; set; }
    public int SeriesId { get; set; }
    public string IdString => SeriesId.ToString();
}

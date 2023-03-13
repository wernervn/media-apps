using WVN.WinForms;

namespace MovieCollection.Configuration;

/// <summary>
/// Configuration to drive behaviour and screen size and state
/// </summary>
public class AppConfiguration
{
    /// <summary>
    /// Key to use for TheMovieDb Api
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// The last path that contained movies
    /// </summary>
    public string LastPath { get; set; }

    /// <summary>
    /// The splitter distance for the splitter between folder treeview and movie listview
    /// </summary>
    public int SplitterDistance { get; set; }

    /// <summary>
    /// Indicates whether the search should be fired automatically
    /// </summary>
    public bool AutoSelectSearchResult { get; set; }

    /// <summary>
    /// Window state of the main window
    /// </summary>
    public WindowState WindowState { get; set; }

    /// <summary>
    /// Window state of the Search window
    /// </summary>
    public WindowState SearchState { get; set; } = new WindowState { Size = new Size(1051, 950), FormWindowState = FormWindowState.Normal };

    /// <summary>
    /// Width of the search results list
    /// </summary>
    public int SearchResultWidth { get; set; } = 0;

    /// <summary>
    /// Window state of the Details window
    /// </summary>
    public WindowState DetailsState { get; set; } = new WindowState { Size = new Size(804, 804), FormWindowState = FormWindowState.Normal };
}

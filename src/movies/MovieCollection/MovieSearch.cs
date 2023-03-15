using MovieCollection.Common;
using MovieCollection.Common.Interfaces;
using MovieCollection.Common.Models;
using MovieCollection.Configuration;
using Movies.TmDb;
using WVN.WinForms;
using WVN.WinForms.Extensions;

namespace MovieCollection;
public partial class MovieSearch : Form
{
    private IMovieData _wrapper;
    private AppConfiguration _settings;

    public MovieSearch()
    {
        InitializeComponent();
    }

    public void Show(AppConfiguration settings, IMovieData wrapper, string movieFolder, IWin32Window owner = null)
    {
        _settings = settings;
        _wrapper = wrapper;

        txtMovie.Text = Helpers.ScrubMovieName(movieFolder, _settings.SpaceCharacters, _settings.RemovalValues);
        lvwMovies.Columns[0].Width = lvwMovies.ClientSize.Width;
        //DoSearch().GetAwaiter().GetResult();
        btnSearch.Focus();
        ShowDialog(owner);
    }

    internal MovieDetails SelectedMovie { get; private set; }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        await DoSearch();
    }

    private async Task DoSearch()
    {
        ClearStatus();
        List<MovieSearchResult> result = await _wrapper.Search(txtMovie.Text);
        LoadSearchResults(result);
    }

    private void LoadSearchResults(List<MovieSearchResult> result)
    {
        lvwMovies.BeginUpdate();
        lvwMovies.Items.Clear();

        result.ForEach(movie =>
        {
            ListViewItem item = lvwMovies.Items.Add(movie.Title);
            item.SubItems.Add(movie.ReleaseDate);
            item.Tag = movie;
        });

        lvwMovies.ResizeColumnsAll();
        lvwMovies.EndUpdate();

        if (result.Count > 0)
        {
            lvwMovies.Items[0].Selected = true;
        }
    }

    private async void lvwMovies_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearStatus();
        btnAccept.Enabled = false;
        if (lvwMovies.SelectedItems.Count > 0)
        {
            // Initially a MovieSearchResult is stored.
            // The first time the item is selected, the stored MovieSearchResult is replaced with a MovieDetails item.
            if (lvwMovies.SelectedItems[0].Tag is MovieSearchResult result)
            {
                var movieDetails = await _wrapper.GetDetails(result.Id);
                var images = await _wrapper.GetImageUrls(movieDetails);
                movieDetails.Poster = images.Poster;
                movieDetails.Backdrop = images.Backdrop;

                lvwMovies.SelectedItems[0].Tag = movieDetails;
            }

            if (lvwMovies.SelectedItems[0].Tag is MovieDetails movie)
            {
                info.MovieDetails = movie;
                btnAccept.Enabled = true;
            }
        }
    }

    private void MovieData_Load(object sender, EventArgs e)
    {
        int width = _settings.SearchResultWidth;
        this.SetWindowState(_settings.SearchState);

        if (width != 0)
        {
            SPLIT.SplitterDistance = width;
        }
    }

    private void MovieData_FormClosing(object sender, FormClosingEventArgs e)
    {
        _settings.SearchState = this.GetWindowState();
        _settings.SearchResultWidth = SPLIT.SplitterDistance;
    }

    private async void MovieData_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            await DoSearch();
        }
    }

    private void btnAccept_Click(object sender, EventArgs e)
    {
        if (lvwMovies.SelectedItems[0].Tag is MovieDetails movie)
        {
            SelectedMovie = movie;
            DialogResult = DialogResult.OK;
        }
    }

    private void info_ImageResized(object sender, ImageResizedEventArgs e)
    {
        string msg = $"{e.ImageName} has been resized from {Helpers.GetSize(e.OriginalSize)} to {Helpers.GetSize(e.NewSize)}";
        System.Diagnostics.Debug.WriteLine(msg);
        SetStatus(msg);
    }

    private void SetStatus(string text, params object[] parameters)
    {
        lblStatus.Text = string.Format(text, parameters);
    }

    private void ClearStatus()
    {
        SetStatus(string.Empty);
    }
}

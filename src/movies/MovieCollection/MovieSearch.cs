using MovieCollection.Common;
using MovieCollection.Common.Interfaces;
using MovieCollection.Common.Models;
using MovieCollection.Configuration;
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

        txtMovie.Text = Helpers.ScrubMovieName(movieFolder);
        lvwMovies.Columns[0].Width = lvwMovies.ClientSize.Width;
        //DoSearch().GetAwaiter().GetResult();
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
        MovieDetails movie = null;
        if (lvwMovies.SelectedItems.Count > 0)
        {
            var result = lvwMovies.SelectedItems[0].Tag as MovieSearchResult;
            if (result != null)
            {
                movie = await _wrapper.GetDetails(result.Id);
                lvwMovies.SelectedItems[0].Tag = movie;
            }
            movie = lvwMovies.SelectedItems[0].Tag as MovieDetails;

            if (movie is null)
            {
                return;
            }

            var images = await _wrapper.GetImageUrls(movie);
            movie.Poster = images.Poster;
            movie.Backdrop = images.Backdrop;

            info.MovieDetails = movie;
            btnAccept.Enabled = true;
        }
    }

    private void MovieData_Load(object sender, EventArgs e)
    {
        //Size size = _settings.SearchState.Size;
        //Point loc = _settings.SearchState.Location;
        int width = _settings.SearchResultWidth;
        //if (size != new Size(0, 0))
        //{
        //    Size = size;
        //}
        //if (loc != new Point(0, 0))
        //{
        //    Location = loc;
        //}
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
        var details = lvwMovies.SelectedItems[0].Tag as MovieDetails;
        //details.MovieImages = this.MovieImages;
        SelectedMovie = details;
        DialogResult = DialogResult.OK;
    }

    private void info_ImageResized(object sender, ImageResizedEventArgs e)
    {
        const string msg = "Image has been resized from {0} to {1}";
        SetStatus(msg, Helpers.GetSize(e.OriginalSize), Helpers.GetSize(e.NewSize));
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

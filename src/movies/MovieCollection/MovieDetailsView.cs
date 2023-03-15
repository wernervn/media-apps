using MovieCollection.Common.Models;
using MovieCollection.Configuration;
using WVN.WinForms.Extensions;

namespace MovieCollection;

public partial class MovieDetailsView : Form
{
    private AppConfiguration _settings;

    public MovieDetailsView()
    {
        InitializeComponent();
    }

    private MovieDetails _movie;

    public void Show(AppConfiguration settings, MovieDetails movie, IWin32Window owner = null)
    {
        _settings = settings;
        _movie = movie;
        movieInfo.MovieDetails = _movie;
        ShowDialog(owner);
    }

    private void MovieDetailsView_Load(object sender, EventArgs e)
    {
        this.SetWindowState(_settings.DetailsState);
    }

    private void MovieDetailsView_FormClosing(object sender, FormClosingEventArgs e)
    {
        _settings.DetailsState = this.GetWindowState();
    }
}

using MovieCollection.Common.Models;

namespace MovieCollection;

public partial class MovieDetailsView : Form
{
    //private Properties.Settings _settings = Properties.Settings.Default;

    public MovieDetailsView()
    {
        InitializeComponent();
    }

    private MovieDetails _movie;
    public void Show(MovieDetails movie, IWin32Window owner = null)
    {
        _movie = movie;
        movieInfo.MovieDetails = _movie;
        movieInfo.ShowImageInfo(false);
        ShowDialog(owner);
    }

    private void MovieDetailsView_Load(object sender, EventArgs e)
    {
        //Size size = _settings.DetailsSize;
        //if (size.Width > 0 && size.Height > 0)
        //{
        //    Size = size;
        //}
    }

    private void MovieDetailsView_FormClosing(object sender, FormClosingEventArgs e)
    {
        //_settings.DetailsSize = Size;
        //_settings.Save();
    }
}

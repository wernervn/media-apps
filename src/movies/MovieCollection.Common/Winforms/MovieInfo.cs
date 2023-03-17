using System.Diagnostics;
using MovieCollection.Common.Models;

namespace MovieCollection.Common.Winforms;

public partial class MovieInfo : UserControl
{
    public event EventHandler<ImageResizedEventArgs> ImageResized;
    protected void OnImageResized(string imageName, long originalSize, long newSize)
    {
        ImageResized?.Invoke(this, new ImageResizedEventArgs(imageName, originalSize, newSize));
    }

    public MovieInfo()
    {
        InitializeComponent();
    }

    #region Unused for now

    //private MovieImageInfo _imageInfo;

    //public MovieImageInfo ImageInfo
    //{
    //    get { return _imageInfo; }
    //    set
    //    {
    //        _imageInfo = value;
    //        ShowImageInfo();
    //    }
    //}

    //private void ShowImageInfo()
    //{
    //    if (_imageInfo != null)
    //    {
    //        cboBackdrops.DataSource = _imageInfo.BackDropUrls;
    //        cboPosters.DataSource = _imageInfo.PosterUrls;

    //        if (cboPosters.Items.Count > 0)
    //        {
    //            cboPosters.SelectedIndex = cboPosters.Items.Count - 1;
    //        }

    //        if (cboBackdrops.Items.Count > 0)
    //        {
    //            cboBackdrops.SelectedIndex = cboBackdrops.Items.Count - 1;
    //        }
    //    }
    //}

    //private async void btnGetPoster_Click(object sender, EventArgs e)
    //{
    //    await GetPoster();
    //}

    //private async Task GetPoster()
    //{
    //    byte[] poster = await Helpers.DownloadImage(cboPosters.Text);
    //    if (poster != null)
    //    {
    //        MovieDetails.Poster = poster;
    //        Image checkImage = MovieDetails.PosterImage;
    //        //desire max 1000 x 1500
    //        var w = Math.Min(checkImage.Width, 1000);
    //        var h = Math.Min(checkImage.Height, 1500);
    //        byte[] resized = ResizedImage(poster, w, h);
    //        if (poster.LongLength > resized.LongLength)
    //        {
    //            OnImageResized(poster.Length, resized.Length);
    //            MovieDetails.Poster = resized;
    //        }
    //        picPoster.Image = MovieDetails.PosterImage;
    //        ShowImageSize();
    //    }
    //}

    //private async void btnGetBackdrop_Click(object sender, EventArgs e)
    //{
    //    await GetBackdrop();
    //}

    //private async Task GetBackdrop()
    //{
    //    byte[] backdrop = await Helpers.DownloadImage(cboBackdrops.Text);
    //    if (backdrop != null)
    //    {
    //        MovieDetails.Backdrop = backdrop;
    //        Image checkImage = MovieDetails.BackdropImage;
    //        //desire max 1500 x 1000
    //        var w = Math.Min(checkImage.Width, 1500);
    //        var h = Math.Min(checkImage.Height, 1000);
    //        byte[] resized = ResizedImage(backdrop, w, h);
    //        if (backdrop.LongLength > resized.LongLength)
    //        {
    //            OnImageResized(backdrop.Length, resized.Length);
    //            MovieDetails.Backdrop = resized;
    //        }
    //        picBackdrop.Image = MovieDetails.BackdropImage;
    //        ShowImageSize();
    //    }
    //}

    //private async void cboPosters_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    await GetPoster();
    //}

    //private async void cboBackdrops_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    await GetBackdrop();
    //}

    #endregion Unused for now

    private MovieDetails _movieDetails;
    public MovieDetails MovieDetails
    {
        get
        {
            return _movieDetails;
        }
        set
        {
            _movieDetails = value;
            ShowMovieDetails();
        }
    }

    private void ShowMovieDetails()
    {
        ClearAll();

        if (MovieDetails != null)
        {
            txtPopularity.Text = MovieDetails.Popularity;
            chkAdult.Checked = MovieDetails.Adult;
            txtLanguage.Text = MovieDetails.Language;
            txtName.Text = MovieDetails.Title;
            txtGenre.Text = MovieDetails.Genre;
            txtID.Text = MovieDetails.Id.ToString();
            txtIMDBID.Text = MovieDetails.ImdbId;
            txtURL.Text = MovieDetails.Url;
            txtRuntime.Text = MovieDetails.Runtime.ToString();
            txtOverview.Text = MovieDetails.Overview;
            txtReleased.Text = MovieDetails.Released ?? string.Empty;
            txtTagLine.Text = MovieDetails.TagLine;

            SetResizedPoster(MovieDetails.Poster);
            SetResizedBackdrop(MovieDetails.Backdrop);
        }
    }

    private void ClearImages()
    {
        picPoster.Image = null;
        picBackdrop.Image = null;
        lblWidth.Text = string.Empty;
        lblHeight.Text = string.Empty;
        lblSize.Text = string.Empty;
    }

    private void picImage_DoubleClick(object sender, EventArgs e)
    {
        byte[] imgData = MovieDetails.Poster;
        string tmpFile = Helpers.GetTempFileWithExtension(".jpg");
        File.WriteAllBytes(tmpFile, imgData);

        var proc = new Process();
        proc.StartInfo.FileName = tmpFile;
        proc.Start();
    }

    public void ClearAll()
    {
        ClearImages();
        foreach (Control ctrl in Controls)
        {
            switch (ctrl)
            {
                case TextBox txt:
                    txt.Text = string.Empty;
                    break;
                case CheckBox chk:
                    chk.Checked = false;
                    break;
                case PictureBox pic:
                    pic.Image = null;
                    break;
                default:
                    break;
            }
        }
    }

    private void ShowImageSize()
    {
        if (tabImages.SelectedTab == tabPoster)
        {
            Image img = picPoster.Image;
            if (img != null)
            {
                lblWidth.Text = string.Format("Width: {0}", img.Width);
                lblHeight.Text = string.Format("Height: {0}", img.Height);
                lblSize.Text = string.Format("Size: {0}", Helpers.GetSize(MovieDetails.Poster?.LongLength ?? 0));
            }
        }
        else
        {
            Image img = picBackdrop.Image;
            if (img != null)
            {
                lblWidth.Text = string.Format("Width: {0}", img.Width);
                lblHeight.Text = string.Format("Height: {0}", img.Height);
                lblSize.Text = string.Format("Size: {0}", Helpers.GetSize(MovieDetails.Backdrop?.LongLength ?? 0));
            }
        }
    }

    private void tabImages_TabIndexChanged(object sender, EventArgs e)
    {
        lblWidth.Text = string.Empty;
        lblHeight.Text = string.Empty;
        lblSize.Text = string.Empty;

        ShowImageSize();
    }

    private void picPoster_DoubleClick(object sender, EventArgs e)
    {
        if (picPoster.Image != null)
        {
            ShowImage(MovieDetails.Poster);
        }
    }

    private void picBackdrop_DoubleClick(object sender, EventArgs e)
    {
        if (picBackdrop.Image != null)
        {
            ShowImage(MovieDetails.Backdrop);
        }
    }

    private void ShowImage(byte[] data)
    {
        string tempFile = Helpers.GetTempFileWithExtension(".jpg");
        File.WriteAllBytes(tempFile, data);
        Helpers.Launch(tempFile);
    }

    public void HideAllImageControls()
    {
        lblImages.Visible = false;
        tabImages.Visible = false;
        lblWidth.Visible = false;
        lblHeight.Visible = false;
        lblSize.Visible = false;
    }

    private void SetResizedPoster(byte[] poster)
    {
        if (poster != null)
        {
            MovieDetails.Poster = poster;
            Image checkImage = MovieDetails.PosterImage;
            //desire max 1000 x 1500 Ratio = 2:3
            var w = Math.Min(checkImage.Width, 1000);
            var h = Math.Min(checkImage.Height, 1500);
            byte[] resized = ResizedImage(poster, w, h);
            if (poster.LongLength > resized.LongLength)
            {
                OnImageResized(Constants.Poster, poster.Length, resized.Length);
                MovieDetails.Poster = resized;
            }
            picPoster.Image = MovieDetails.PosterImage;
            ShowImageSize();
        }
    }

    private void SetResizedBackdrop(byte[] backdrop)
    {
        if (backdrop != null)
        {
            MovieDetails.Backdrop = backdrop;
            Image checkImage = MovieDetails.BackdropImage;
            //calculate ratio
            var w = Math.Min(checkImage.Width, 1000);
            var r = w / (decimal)checkImage.Width;
            var h = decimal.ToInt32(checkImage.Height * r);

            byte[] resized = ResizedImage(backdrop, w, h);
            if (backdrop.LongLength > resized.LongLength)
            {
                OnImageResized(Constants.Backdrop, backdrop.Length, resized.Length);
                MovieDetails.Backdrop = resized;
            }
            picBackdrop.Image = MovieDetails.BackdropImage;
            ShowImageSize();
        }
    }

    private static byte[] ResizedImage(byte[] data, int width, int height)
    {
        byte[] resized = Helpers.ResizeImage(data, width, height);
        return resized;
    }
}

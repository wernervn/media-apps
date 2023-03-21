namespace MovieCollection.Common.Models;

[Serializable]
public class MovieDetails
{
    public string Title { get; set; }
    public string TagLine { get; set; }
    public string Released { get; set; }
    public string Language { get; set; }
    public string Genre { get; set; }
    public int Runtime { get; set; }
    public bool Adult { get; set; }
    public long Id { get; set; }
    public string ImdbId { get; set; }
    public string Url { get; set; }
    public string Overview { get; set; }
    public string Popularity { get; set; }

    public string PosterPath { get; set; }
    public string BackdropPath { get; set; }

    private byte[] _poster;
    public byte[] Poster
    {
        get
        {
            return _poster;
        }
        set
        {
            _poster = value;
            _posterImage = null;
        }
    }

    private byte[] _backdrop;
    public byte[] Backdrop
    {
        get
        {
            return _backdrop;
        }
        set
        {
            _backdrop = value;
            _backdropImage = null;
        }
    }

    private Image _posterImage;
    public Image PosterImage
    {
        get
        {
            return _posterImage ??= Poster == null ? null : Image.FromStream(new MemoryStream(Poster));
        }
    }

    private Image _backdropImage;
    public Image BackdropImage
    {
        get
        {
            _backdropImage ??= Backdrop == null ? null : Image.FromStream(new MemoryStream(Backdrop));
            return _backdropImage;
        }
    }
}

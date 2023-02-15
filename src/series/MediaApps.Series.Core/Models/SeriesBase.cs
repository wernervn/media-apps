namespace MediaApps.Series.Core.Models;

public class SeriesBase
{
    public int Id { get; set; }
    public string Actors { get; set; }
    public string ContentRating { get; set; }
    public string Genre { get; set; }
    public string IMDB_ID { get; set; }
    public string Overview { get; set; }
    public string RatingString { get; set; }
    public int? Runtime { get; set; }
    public int? SeriesID { get; set; }
    public string SeriesName { get; set; }
    public string Banner { get; set; }
    public string Fanart { get; set; }
    public string Poster { get; set; }
    public string Status { get; set; }
    public DateTime? FirstAired { get; set; }
    public string MPAA { get; set; }
}

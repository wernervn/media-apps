using System.Xml.Serialization;

namespace MediaApps.Series.Core.Mede8er;

[Serializable()]
[XmlType(AnonymousType = true)]
[XmlRoot(ElementName = "details", Namespace = "", IsNullable = false)]
public partial class EpisodeMetadata
{
    [XmlElement("movie")]
    public Movie Movie
    {
        get; set;
    }
}

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class Movie
{
    [XmlElement("title")]
    //[XmlText]
    public string Title { get; set; }

    [XmlElement("season")]
    public int Season { get; set; }

    [XmlElement("episode")]
    public int Episode { get; set; }

    [XmlElement("year")]
    public int Year { get; set; }

    [XmlElement("rating")]
    public double Rating { get; set; }

    [XmlElement("plot")]
    //[XmlText]
    public string Plot { get; set; }

    [XmlElement("episodeplot")]
    //[XmlText]
    public string EpisodePlot { get; set; }

    [XmlElement("mpaa")]
    public string MPAA { get; set; }

    [XmlElement("runtime")]
    public int Runtime { get; set; }

    //[XmlElement("genres")]
    [XmlArrayItem("genre", IsNullable = false)]
    public string[] genres { get; set; }

    [XmlElement("director")]
    public string Director { get; set; }

    [XmlElement("credits")]
    public string Credits { get; set; }

    [XmlArrayItem("actor", IsNullable = false)]
    //[XmlElement("cast")]
    public string[] cast { get; set; }

    [XmlArrayItem("fanart", IsNullable = false)]
    //[XmlElement("image")]
    public string[] image { get; set; }
}

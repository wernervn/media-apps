using System.Xml.Serialization;

namespace MediaApps.Series.Core.Mede8er;

[Serializable()]
[XmlType(AnonymousType = true)]
[XmlRoot(ElementName = "details", Namespace = "", IsNullable = false)]
public partial class SeriesMetadata
{
    [XmlElement("movie")]
    public Series Series { get; set; }
}

[Serializable()]
[XmlType(AnonymousType = true)]
public partial class Series
{
    [XmlElement("title")]
    //[XmlText]
    public string Title { get; set; }

    [XmlArrayItem("genre", IsNullable = false)]
    public string[] genres { get; set; }

    [XmlElement("premiered")]
    public string Premiered { get; set; }

    [XmlElement("year")]
    public int Year { get; set; }

    [XmlElement("rating")]
    public double Rating { get; set; }

    [XmlElement("status")]
    public string Status { get; set; }

    [XmlElement("mpaa")]
    public string MPAA { get; set; }

    /*
     *  <id moviedb="imdb">tt4016454</id>
     *  <id moviedb="zap2it">EP02185451</id>
    */

    [XmlElement("tvdbid")]
    public string TvdbId { get; set; }

    [XmlElement("runtime")]
    public int Runtime { get; set; }

    [XmlElement("plot")]
    public string Plot { get; set; }

    //[XmlElement("tvdbid")]
    //public string TvdbId { get; set; }

    [XmlArrayItem("actor", IsNullable = false)]
    public string[] cast { get; set; }

    //[XmlArrayItem("fanart", IsNullable = false)]
    //public string[] image { get; set; }

    [XmlElement("image")]
    public string Images { get; set; }
    /*
     <image>
        <banner>http://thetvdb.com/banners/graphical/295759-g.jpg</banner>
        <poster>http://thetvdb.com/banners/posters/295759-1.jpg</poster>
        <fanart>http://thetvdb.com/banners/fanart/original/295759-12.jpg</fanart>
    </image>

    <seasons>
        <season number="1">
            <tvdbid>623813</tvdbid>
            <poster>http://thetvdb.com/banners/seasons/295759-1.jpg</poster>
            <poster>http://thetvdb.com/banners/seasons/295759-1-2.jpg</poster>
        </season>
    </seasons>
    */
}

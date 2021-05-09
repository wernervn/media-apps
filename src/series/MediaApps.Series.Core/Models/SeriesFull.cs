using System.Collections.Generic;

namespace MediaApps.Series.Core.Models
{
    public class SeriesFull
    {
        public SeriesBase Series { get; set; }
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}

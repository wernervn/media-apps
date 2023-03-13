using System;
using System.Collections.Generic;

namespace MovieCollection.Common.Models;

[Serializable]
public class MovieImageInfo
{
    public List<string> PosterUrls { get; set; }
    public List<string> BackDropUrls { get; set; }
}

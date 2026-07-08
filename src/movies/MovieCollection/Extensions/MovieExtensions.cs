using System.Globalization;
using MovieCollection.Common.Models;

namespace MovieCollection.Extensions;

public static class MovieExtensions
{
    public static string FolderName(this MovieDetails movie)
        => $"{movie.Title} ({DateTime.ParseExact(movie.Released, "yyyy-MM-dd", CultureInfo.InvariantCulture).Year})";

    public static string ToMovieFileName(this string file, string movieFileName)
    {
        return Path.Combine(Path.GetDirectoryName(file), movieFileName + Path.GetExtension(file));
    }
}

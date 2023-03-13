using MovieCollection.Common.Models;

namespace MovieCollection.Common.Interfaces;

public interface IMovieData
{
    List<MovieSearchResult> Search(string criteria);
    //MovieDetails SearchById(int id);
    MovieDetails GetDetails(int id);
    MovieImageInfo GetImageUrls(int movieId);
}

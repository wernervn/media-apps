using MovieCollection.Common.Models;

namespace MovieCollection.Common.Interfaces;

public interface IMovieData
{
    Task<List<MovieSearchResult>> Search(string criteria);
    Task<MovieDetails> GetDetails(int id);
    Task<MovieImages> GetImageUrls(MovieDetails movieDetails);
}

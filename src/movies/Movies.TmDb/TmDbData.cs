using MovieCollection.Common.Interfaces;
using MovieCollection.Common.Models;

namespace Movies.TmDb;

public class TmDbData: IMovieData
{
    private readonly TmDbWrapperHelper _wrapper;

    public TmDbData(string apiKey)
    {
        _wrapper = new TmDbWrapperHelper(apiKey);
    }

    public async Task<List<MovieSearchResult>> Search(string criteria)
        => await _wrapper.Search(criteria);

    public async Task<MovieDetails> GetDetails(int id)
        => await _wrapper.SearchById(id);

    public async Task<MovieImages> GetImageUrls(MovieDetails movieDetails)
        => await _wrapper.GetImageInfo(movieDetails);
}

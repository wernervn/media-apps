using MovieCollection.Common.Models;
using WVN.TmDb.Api.Models;
using WVN.TmDb.Api.Wrapper;
using Models = MovieCollection.Common.Models;

namespace Movies.TmDb;

internal class TmDbWrapperHelper
{
    private readonly TmDbWrapper _wrapper;

    internal TmDbWrapperHelper(string apiKey)
    {
        _wrapper = new TmDbWrapper(apiKey);
    }

    internal async Task<List<Models.MovieSearchResult>> Search(string criteria)
    {
        var result = await _wrapper.SearchForMovie(criteria, page: 1);

        return result.Results.ConvertAll(
                                movie => new Models.MovieSearchResult
                                {
                                    Id = movie.Id,
                                    Title = movie.Title,
                                    ReleaseDate = movie.ReleaseDate.HasValue ? movie.ReleaseDate.Value.ToString() : string.Empty }
                                );
    }

    internal async Task<MovieDetails> SearchById(int movieId)
    {
        var movie = await _wrapper.GetFullMovie(movieId);

        return new MovieDetails
        {
            Adult = movie.Adult,
            Genre = movie.Genres.Count > 0 ? movie.Genres[0].Name : string.Empty,
            Id = movie.Id,
            ImdbId = movie.ImdbId,
            Language = SpokenLanguageName(movie),// = movie.OriginalLanguage,
            Title = movie.Title,
            TagLine = movie.Tagline,
            Overview = movie.Overview,
            Popularity = movie.VoteAverage.ToString(),
            Released = movie.ReleaseDate.HasValue ? movie.ReleaseDate.Value.ToString() : string.Empty,
            Runtime = movie.Runtime,
            PosterPath = movie.PosterPath,
            BackdropPath = movie.BackdropPath,
            Url = HomePage(movie.Id, movie.HomePage)
        };
    }

    internal async Task<Models.MovieImages> GetImageInfo(MovieDetails movieDetails)
    {
        var movie = new Movie { PosterPath = movieDetails.PosterPath, BackdropPath = movieDetails.BackdropPath };
        var images =  await _wrapper.DownloadImages(movie);
        return new Models.MovieImages() { Backdrop = images.BackdropData, Poster = images.PosterData };
    }

    private static string SpokenLanguageName(Movie movie)
    {
        var found = movie.SpokenLanguages.Find(lang => lang.Iso639_1 == movie.OriginalLanguage);
        return found?.EnglishName ?? movie.OriginalLanguage;
    }

    private static string HomePage(long tmdbId, string url)
        => string.IsNullOrEmpty(url) ? string.Concat("http://www.themoviedb.org/movie/", tmdbId.ToString()) : url;
}

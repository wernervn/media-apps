using System.Globalization;
using System.Reflection;
using System.Text;
using MovieCollection.Common.Models;

namespace MovieCollection.Common.DB;

public static class MovieFile
{
    public static async Task WriteFile(string folderPath, MovieDetails movieInfo)
    {
        string dbPath = Path.Combine(folderPath, Constants.MOVIE_DATA);
        await CreateDatabase(dbPath);
        await PopulateDatabase(dbPath, movieInfo);
        await SqliteData.VacuumDB(dbPath);
    }

    private static async Task CreateDatabase(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        var commands = new List<string> { GetResourceSql("MovieInfo.sql"), GetResourceSql("MovieImages.sql") };
        await SqliteData.ExecuteCommandsAsync(path, commands);
    }

    private static async Task PopulateDatabase(string dbPath, MovieDetails movieInfo)
    {
        // populate MovieInfo table
        await SqliteData.ExecuteCommandAsync(dbPath, InsertInfoSql(movieInfo));

        // populate MovieImages table
        var parameters = new Dictionary<string, object>()
        {
            ["@poster"] = movieInfo.Poster,
            ["@backdrop"] = movieInfo.Backdrop
        };
        await SqliteData.ExecuteCommandAsync(dbPath, InsertImagesSql(movieInfo), parameters);
    }

    public static string InsertInfoSql(MovieDetails movie)
    {
        var isAdult = movie.Adult ? 1 : 0;
        var rating = string.IsNullOrEmpty(movie.Popularity) ? 0 : double.Parse(movie.Popularity, NumberStyles.Float, CultureInfo.CurrentCulture);
        var sql = $"""
    INSERT INTO MovieInfo
    (
        MovieId, Name, Released, Language, Genre, Runtime, Adult, IMDBId, Url, Overview, Rating, TagLine
    )
    VALUES
    (
        {movie.Id}, '{SqliteData.CleanSQL(movie.Title)}', '{movie.Released:yyyy-MM-yy}', '{movie.Language}', '{movie.Genre}', '{movie.Runtime}', {isAdult}, '{movie.ImdbId}', '{movie.Url}', '{SqliteData.CleanSQL(movie.Overview)}', '{rating}', '{SqliteData.CleanSQL(movie.TagLine)}'
    )
""";

        return sql;
    }

    public static string InsertImagesSql(MovieDetails movie)
    {
        var sb = new StringBuilder();
        sb.Append("INSERT INTO MovieImages\n");
        sb.Append("(MovieId, Poster, Backdrop) \nVALUES (");
        sb.AppendFormat("{0}, {1}, {2})", movie.Id, "@poster", "@backdrop");
        return sb.ToString();
    }

    public static async Task<MovieDetails> GetMovieDetailsAsync(string dbPath)
    {
        const string sqlInfo = """
                                select
                                    MovieId AS Id,
                                    Name AS Title,
                                    Released,
                                    Language,
                                    Genre,
                                    Runtime,
                                    Adult,
                                    IMDBId AS ImdbId,
                                    Url,
                                    Overview,
                                    Rating AS Popularity,
                                    TagLine
                                from MovieInfo
                                """;
        var movie = await SqliteData.QuerySingleAsync<MovieDetails>(dbPath, sqlInfo);

        const string sqlImages = "select Poster, Backdrop from MovieImages";
        var images = await SqliteData.QuerySingleAsync<MovieImages>(dbPath, sqlImages);
        movie.Poster = images.Poster;
        movie.Backdrop = images.Backdrop;
        return movie;
    }

    public static string MovieInfoExtension => "*.tmdb";

    private static string GetResourceSql(string name)
    {
        var result = string.Empty;
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = string.Format("MovieCollection.Common.DB.{0}", name);

        using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(resourceName)))
        {
            result = reader.ReadToEnd();
        }
        return result;
    }
}

using MediaApps.Series.Core;
using MediaApps.Series.Core.Mede8er;

namespace EpisodeScraper.TvDbSharper;

//mede8er implementations
public partial class TvDbWrapper
{
    private readonly ResourceHelper _resourceHelper = new ResourceHelper();

    public string GetEpisodeMetadata()
    {
        var metadata = new EpisodeMetadata();
        return metadata.AsXml();
    }

    public async Task WriteSeasonViewXml(string fileName)
    {
        const string resourceName = "MediaApps.Series.Core.Resources.SeasonView.xml";
        await _resourceHelper.WriteResourceToFile(resourceName, fileName).ConfigureAwait(false);
    }

    public async Task WriteSeriesViewXml(string fileName)
    {
        const string resourceName = "MediaApps.Series.Core.Resources.SeriesView.xml";
        await _resourceHelper.WriteResourceToFile(resourceName, fileName).ConfigureAwait(false);
    }
}

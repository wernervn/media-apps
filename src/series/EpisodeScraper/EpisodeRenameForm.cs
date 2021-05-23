using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MediaApps.Common.Helpers;
using MediaApps.Series.Core.Models;

namespace EpisodeScraper
{
    public partial class EpisodeRenameForm : Form
    {
        private const string NAME = "{0}.{1}.{2}";
        private const string KEY = "S{0:D2}E{1:D2}";

        private List<Episode> _episodes;
        private string _folderPath;
        private string _seriesName;
        private IEnumerable<string> _files;

        private bool _getSeasonData;

        public bool GetSeasonData { get => _getSeasonData; private set => _getSeasonData = value; }

        public EpisodeRenameForm()
        {
            InitializeComponent();
        }

        public void ShowDialog(string seriesName, string folder, IEnumerable<Episode> episodes)
        {
            _folderPath = folder;
            _episodes = episodes.ToList();
            _seriesName = seriesName;
            InitialiseData();
            ShowDialog();
        }

        private void InitialiseData()
        {
            _files = EpisodeScraper.TvDbSharper.SeasonHelper.GetEpisodes(_folderPath).Select(f => new FileInfo(f).Name).ToList();
            LoadEpisodes();
        }

        private void LoadEpisodes()
        {
            lvwEpisodes.Items.Clear();
            _episodes.ForEach(LoadEpisode);
        }

        private void LoadEpisode(Episode episode)
        {
            //TODO: use RenameContainer

            var episodeNumber = episode.EpisodeNumber.Value;
            var key = string.Format(KEY, episode.SeasonNumber, episodeNumber);
            var newName = IOHelper.CleanFileName(string.Format(NAME, _seriesName, key, episode.EpisodeName));
            var newItem = lvwEpisodes.Items.Add(key, newName, 0);
            _ = newItem.SubItems.Add($"{episode.FirstAired:yyyy-MM-dd}");
            var found = _files.SingleOrDefault(f => f.Contains(key, StringComparison.OrdinalIgnoreCase));
            if (found != null)
            {
                _ = newItem.SubItems.Add(found);
                var renamed = string.Concat(newName, Path.GetExtension(found));
                _ = newItem.SubItems.Add(renamed);
            }
        }

        private void BtnRename_Click(object sender, EventArgs e)
        {
            RenameSelected();
            MessageBox.Show("Rename completed", "Done", MessageBoxButtons.OK);
            InitialiseData();
        }

        private void RenameSelected()
        {
            var files = EpisodeScraper.TvDbSharper.SeasonHelper.GetEpisodes(_folderPath).Select(f => new FileInfo(f).Name).ToList();
            var subtitles = EpisodeScraper.TvDbSharper.SeasonHelper.GetSubtitles(_folderPath).ToList();

            EpisodeScraper.TvDbSharper.SeasonHelper.RenameEpisodeFiles(_seriesName, _folderPath, _episodes, files);
            EpisodeScraper.TvDbSharper.SeasonHelper.RenameEpisodeFiles(_seriesName, _folderPath, _episodes, subtitles);
        }

        private void chkGetSeasonData_CheckedChanged(object sender, EventArgs e)
            => GetSeasonData = chkGetSeasonData.Checked;
    }
}

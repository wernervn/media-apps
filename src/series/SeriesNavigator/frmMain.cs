using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MediaApps.Common.Helpers;
using MediaApps.Series.Core.Mede8er;
using SeriesNavigator.Configuration;
using SeriesNavigator.Thumbs;
using WVN.Configuration;
using WVN.WinForms.Extensions;

namespace SeriesNavigator
{
    public partial class frmMain : Form
    {
        private readonly AppSettings _settings = AppSettingsManager.GetSettings<AppSettings>();

        private string _currentFolder;
        private string _seriesFolder;
        private SeriesView _currentView;
        private List<ThumbImage> _thumbCache;
        private int _selectedIndex;

        public frmMain(string[] args)
        {
            InitializeComponent();

            InitialiseConfiguration();
            WindowState = FormWindowState.Maximized;

            ResizeThumbs();

            _currentFolder = args.Length > 0 ? args[0] : _settings.AppConfiguration.SeriesFolder;

            if (Directory.Exists(_currentFolder))
            {
                LoadSeries();
            }
            else
            {
                NoSeries();
            }
        }

        private void InitialiseConfiguration()
        {
            _seriesFolder = _settings.AppConfiguration.SeriesFolder;
            Styles.SelectedBackColour = _settings.AppConfiguration.SelectedBackColour;
            Styles.SelectedForeColour = _settings.AppConfiguration.SelectedForeColour;
        }

        private void frmMain_Resize(object sender, EventArgs e)
            => ResizeThumbs();

        #region Series info
        private SeriesMetadata GetSeriesMetadata(string path)
            => MediaApps.Series.Core.SeriesHelper.GetSeriesMetadata(path);

        private string GetSeriesDescription(string path)
        {
            var data = GetSeriesMetadata(path);
            return data?.Series.Plot;
        }

        #endregion

        #region Episode info
        private EpisodeMetadata GetEpisodeMetadata(string path)
        {
            var xmlPath = Path.ChangeExtension(path, "xml");
            if (File.Exists(xmlPath))
            {
                var data = MediaApps.Series.Core.SeriesHelper.GetEpisodeMetadata(xmlPath);
                return data;
            }
            return null;
        }

        private string GetEpisodePlot(string path)
        {
            var data = GetEpisodeMetadata(path);
            return data?.Movie == null ? string.Empty : $"{data.Movie.EpisodePlot} ({data.Movie.Rating})";
        }

        private string GetEpisodeThumb(string episode)
        {
            var imagePath = Path.ChangeExtension(episode, "jpg");
            return File.Exists(imagePath) ? imagePath : string.Empty;
        }

        #endregion

        #region Season info
        private string GetSeriesSeasonThumb(string folder)
        {
            var imagePath = Path.Combine(folder, "folder.jpg");
            return File.Exists(imagePath) ? imagePath : string.Empty;
        }

        #endregion

        #region Shut-down
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
            => SaveAppSettings();

        private void SaveAppSettings()
        {
            _settings.AppConfiguration.SeriesFolder = _seriesFolder;
            _settings.AppConfiguration.SelectedBackColour = Styles.SelectedBackColour;
            _settings.AppConfiguration.SelectedForeColour = Styles.SelectedForeColour;
            AppSettingsManager.SaveSettings(_settings);
        }

        private void PromptClose()
        {
            if (MessageBox.Show("OK to close?", "Confirm close", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Close();
            }
        }
        #endregion

        #region Key commands
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Back:
                    Back();
                    return true;
                case Keys.Escape:
                    PromptClose();
                    return true;
                case Keys.F1:
                    ShowPath();
                    return true;
                case Keys.F5:
                    RefreshSeries();
                    return true;
                case Keys.Control | Keys.S:
                    UpdateSettings();
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Back()
        {
            lblHeader.Text = string.Empty;
            lblDescription.Text = string.Empty;

            switch (_currentView)
            {
                case SeriesView.Seasons:
                    _currentFolder = Directory.GetParent(_currentFolder).FullName;
                    LoadSeries();
                    break;
                case SeriesView.Episodes:
                    var path = Directory.GetParent(_currentFolder).FullName;
                    LoadSeasons(path);
                    break;
                default:
                    break;
            }
        }

        private void RefreshSeries()
        {
            _thumbCache.Clear();
            _thumbCache = null;
            if (_currentView == SeriesView.Series)
            {
                LoadSeries();
            }
        }

        private void ShowPath()
            => MessageBox.Show(_currentFolder, "Path");

        private void UpdateSettings()
        {
            using (var settings = new frmSettings(_settings))
            {
                if (settings.ShowDialog() == DialogResult.OK)
                {
                    var appSettings = settings.AppSettings;
                    _seriesFolder = appSettings.AppConfiguration.SeriesFolder;
                    Styles.SelectedBackColour = appSettings.AppConfiguration.SelectedBackColour;
                    Styles.SelectedForeColour = appSettings.AppConfiguration.SelectedForeColour;

                    if (_currentFolder != _settings.AppConfiguration.SeriesFolder)
                    {
                        _currentFolder = _settings.AppConfiguration.SeriesFolder;
                        LoadSeries();
                    }
                }
            }
        }

        #endregion

        #region Load Series
        private void LoadSeries()
        {
            ShowOnly(thumbsSeries);

            _currentView = SeriesView.Series;
            thumbsSeries.Clear();
            lblHeader.Text = string.Empty;
            lblDescription.Text = string.Empty;
            using var timedAction = new TimedAction("Loading series", LoadSeriesThumbs);
        }

        private void LoadSeriesThumbs()
        {
            thumbsSeries.Visible = false;
            var folders = Directory.GetDirectories(_seriesFolder).ToList();

            var index = 0; //start indexing from 0 (zero)
            if (_thumbCache == null)
            {
                _thumbCache = folders.ConvertAll(folder =>
                  {
                      var imagePath = GetSeriesSeasonThumb(folder);
                      var ratedDescription = RatedDescription(folder);
                      return new ThumbImage(imagePath, folder, index++, ratedDescription, _currentView);
                  });
            }
            thumbsSeries.AddRange(_thumbCache);
        }

        #endregion

        #region Load Seasons
        private void LoadSeasons(string path)
        {
            _currentFolder = path;

            ShowOnly(thumbsSeasons);

            _currentView = SeriesView.Seasons;
            thumbsSeasons.Clear();
            using var timedAction = new TimedAction("Loading episodes", LoadSeasonThumbs);
        }

        private void LoadSeasonThumbs()
        {
            var folders = Directory.GetDirectories(_currentFolder, "Season *");

            var index = 0; //start indexing from 0 (zero)
            var thumbs = folders.Select(folder =>
            {
                var imagePath = GetSeriesSeasonThumb(folder);
                var description = GetSeriesDescription(folder);
                return new ThumbImage(imagePath, folder, index++, description, _currentView);
            });
            thumbsSeasons.AddRange(thumbs);
        }

        #endregion

        #region Load Episodes
        private void LoadEpisodes(string path)
        {
            _currentFolder = path;

            ShowOnly(thumbsEpisodes);

            _currentView = SeriesView.Episodes;
            thumbsEpisodes.Clear();
            using var timedAction = new TimedAction("Loading episodes", LoadEpisodeThumbs);
        }

        private void LoadEpisodeThumbs()
        {
            var episodes = IOHelper.GetFiles(_currentFolder, MediaApps.Series.Core.Constants.VIDEO_EXTENSIONS);

            var index = 0; //start indexing from 0 (zero)
            var thumbs = episodes.Select(episode =>
            {
                var imagePath = GetEpisodeThumb(episode);
                var description = GetEpisodePlot(episode);
                return new ThumbImage(imagePath, episode, index++, description, _currentView);
            });
            thumbsEpisodes.AddRange(thumbs);
        }

        #endregion

        #region Thumb clicks
        private void ThumbSelected(object sender, ThumbClickEventArgs e)
        {
            _selectedIndex = e.Index;
            lblDescription.Text = e.Description;
            lblHeader.Text = e.ItemName;
        }

        private void ThumbsSeries_ThumbEnter(object sender, ThumbEnterEventArgs e)
        {
            _selectedIndex = e.Index; //restore to this thumb on returning to this container
            //navigate from series to seasons
            LoadSeasons(e.Path);
        }

        private void ThumbsSeasons_ThumbEnter(object sender, ThumbEnterEventArgs e)
            => LoadEpisodes(e.Path);

        private void ThumbsEpisodes_ThumbEnter(object sender, ThumbEnterEventArgs e)
        {
            var video = e.Path;
            var startInfo = new ProcessStartInfo(video) { WindowStyle = ProcessWindowStyle.Maximized };
            Process.Start(startInfo);
        }

        #endregion

        #region Helpers
        private void NoSeries()
            => lblHeader.Text = $"No series found at: {_currentFolder}";

        private void ShowOnly(ThumbContainer toShow)
        {
            thumbsSeries.HideIt();
            thumbsSeasons.HideIt();
            thumbsEpisodes.HideIt();
            toShow.ShowIt();
        }

        private void ResizeThumbs()
            => this.SuspendLayoutDuringAction(() => MoveControls(new Control[] { thumbsSeries, thumbsSeasons, thumbsEpisodes }, GetThumbSpace()));

        private Rectangle GetThumbSpace()
        {
            var x = 0;
            var y = lblHeader.Height;
            var w = Width;
            var h = Height - (y + lblDescription.Height);
            return new Rectangle(x, y, w, h);
        }

        private void MoveControls(Control[] controls, Rectangle rect)
            => Array.ForEach(controls, ctrl => ctrl.HideDuringAction(() => ctrl.MoveControl(rect)));

        private string RatedDescription(string path)
        {
            var series = GetSeriesMetadata(path)?.Series;
            return series != null ? $"{series.Plot} ({series.Rating})" : string.Empty;
        }

        #endregion
    }
}

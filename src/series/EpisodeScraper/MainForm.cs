using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpisodeScraper.Configuration;
using EpisodeScraper.TvDbSharper;
using MediaApps.Common.Extensions;
using MediaApps.Common.Helpers;
using MediaApps.Series.Core;
using MediaApps.Series.Core.Mede8er;
using Microsoft.WindowsAPICodePack.Dialogs;
using WVN.Configuration;
using WVN.WinForms.Extensions;

using Core = MediaApps.Series.Core;

namespace EpisodeScraper
{
    public partial class MainForm : Form
    {
        private readonly AppSettings _settings = AppSettingsManager.GetSettings<AppSettings>();

        private readonly TvDbWrapper _tvdb;
        private const string HAS_ID_KEY = "hasId";

        private string _seriesFolder;

        public MainForm()
        {
            InitializeComponent();

            _seriesFolder = _settings.AppConfiguration.SeriesFolder;
            _tvdb = new TvDbWrapper(_settings.AppConfiguration.ApiKey);
        }

        #region Open/Close
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            RestoreFormPosition();
            if (Directory.Exists(_seriesFolder))
            {
                LoadFolders(_seriesFolder);
            }
            lvwFiles.SmallImageList = IMG;
            lvwFiles.LargeImageList = IMG;
            lvwFiles.StateImageList = IMG;
            tvwFolder.ImageList = IMG;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settings.AppConfiguration.SeriesFolder = _seriesFolder;
            _settings.AppConfiguration.WindowState = this.GetWindowState();
            AppSettingsManager.SaveSettings(_settings);
        }

        #endregion Open/Close

        #region Folders and Files
        private void LoadFolders(string path)
        {
            lvwFiles.Items.Clear();
            tvwFolder.ImageList = IMG;
            var count = tvwFolder.LoadFolders(path, Constants.FOLDER_KEY);
            SetStatus("Root folder contains {0} series folder(s)", count);
            if (tvwFolder.Nodes[0].Nodes.Count > 0)
            {
                tvwFolder.SelectedNode = tvwFolder.Nodes[0];
            }

            foreach (TreeNode node in tvwFolder.Nodes[0].Nodes)
            {
                var nodePath = node.Tag.ToString();
                if (Directory.GetFiles(nodePath).Select(Path.GetFileName).Contains(Core.Constants.SERIES_XML))
                {
                    node.ImageKey = HAS_ID_KEY;
                    node.SelectedImageKey = HAS_ID_KEY;
                }
            }
        }

        private void TvwFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            var folder = node.Tag.ToString();
            if (Directory.Exists(folder))
            {
                LoadAllFiles(folder);
                lvwFiles.ResizeColumnsAll();

                var seriesFolder = node.IsSeriesFolder();
                var seasonFolder = node.IsSeasonFolder();
                var hasId = HasId(folder); //must check parent dir of season dir for ID
                var hasParentId = seasonFolder && ParentHasId(folder);
                SetAvailableMethods(seriesFolder, seasonFolder, hasId, hasParentId);

                if (seriesFolder)
                {
                    SetStatus("'{0}' contains {1} season(s)", folder, node.Nodes.Count);
                }
                if (seasonFolder)
                {
                    SetStatus("'{0}' contains {1} episode(s)", folder, IOHelper.GetFiles(folder, Core.Constants.VIDEO_EXTENSIONS).Count());
                }
            }
            else
            {
                MessageBox.Show("The folder no longer exists. It has either been moved or deleted.", "Folder doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TvwFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //if the subfolder is a dummy folder, remove it and add any real folder
            var node = e.Node;
            if (node.Nodes.Count == 1 && node.Nodes[0].Text == "dummy" && e.Node.Nodes[0].Tag == null)
            {
                e.Node.Nodes.Clear();
                tvwFolder.LoadFolders(node, node.Tag.ToString(), Constants.FOLDER_KEY);
            }
        }

        private void LoadAllFiles(string path)
        {
            var files = new List<string>(Directory.GetFiles(path));

            lvwFiles.BeginUpdate();
            lvwFiles.Items.Clear();

            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                var imgKey = fi.Extension;
                AddIcon(fi.FullName, imgKey);
                var item = lvwFiles.Items.Add(fi.Name, imgKey);
                _ = item.SubItems.Add(Helpers.GetSize(fi.Length));
                _ = item.SubItems.Add(fi.LastWriteTime.ToString(Core.Constants.DATE_FMT));
            }

            lvwFiles.ResizeColumnsAll();
            lvwFiles.EndUpdate();
        }

        #endregion

        #region Menus
        private void SetAvailableMethods(bool seriesFolder, bool seasonFolder, bool hasId, bool hasParentId)
        {
            mniTvdbGetMetadata.Enabled = false;
            mniTvdbSearch.Enabled = false;
            mniTvdbGetSeriesMetadata.Enabled = false;
            mniTvdbGetAllMetadata.Enabled = false;
            mniMede8erSetWatched.Enabled = false;
            mniTvdbRenameEpisodes.Enabled = false;
            mniTvdbRenameEpisodesUI.Enabled = false;
            mniTvdbClearMetadata.Enabled = false;
            mniMede8erSetFolderWatched.Enabled = seasonFolder;

            if (seriesFolder)
            {
                mniTvdbSearch.Enabled = true;
                if (hasId)
                {
                    mniTvdbGetSeriesMetadata.Enabled = true;
                    mniTvdbGetAllMetadata.Enabled = true;
                }
            }
            if (seasonFolder && hasParentId)
            {
                mniTvdbGetMetadata.Enabled = true;
                mniTvdbRenameEpisodes.Enabled = true;
                mniTvdbRenameEpisodesUI.Enabled = true;
                mniTvdbClearMetadata.Enabled = true;
            }
        }

        private async void MniTvdbSearch_Click(object sender, EventArgs e)
        {
            var folder = tvwFolder.SelectedNode.Tag.ToString();
            var seriesName = new DirectoryInfo(folder).Name;
            using (var search = new SearchForm(_tvdb, seriesName))
            {
                if (search.ShowDialog() == DialogResult.OK)
                {
                    //create files
                    await EpisodeScraper.TvDbSharper.SeriesHelper.GetSeriesInfo(_tvdb, folder, search.TvdbId, false);
                    //override selected poster
                    var posterFile = Path.Combine(folder, "folder.jpg");
                    var image = ImageHelper.ReduceImageSize(search.Poster);
                    File.WriteAllBytes(posterFile, image);
                    LoadAllFiles(folder);

                    tvwFolder.SelectedNode.ImageKey = HAS_ID_KEY;
                    tvwFolder.SelectedNode.SelectedImageKey = HAS_ID_KEY;
                }
            }
        }

        private async void MniTvdbGetMetadata_Click(object sender, EventArgs e)
            => await GetSeasonData().ConfigureAwait(false);

        private async void MniTvdbGetSeriesMetadata_Click(object sender, EventArgs e)
            => await GetSeriesData(false).ConfigureAwait(false);

        private async void MniTvdbGetAllMetadata_Click(object sender, EventArgs e)
            => await GetSeriesData(false).ConfigureAwait(false);

        private async Task GetSeasonData()
        {
            var folder = tvwFolder.SelectedNode.Tag.ToString();
            await SeasonHelper.GetEpisodeMetadata(_tvdb, folder).ConfigureAwait(false);
            this.InvokeUI(() => LoadAllFiles(folder));
            SetStatus($"Loaded season metadata for '{folder}'");
        }

        private async Task GetSeriesData(bool includeSeasons)
        {
            var folder = tvwFolder.SelectedNode.Tag.ToString();
            await EpisodeScraper.TvDbSharper.SeriesHelper.GetSeriesInfo(_tvdb, folder, includeSeasons).ConfigureAwait(false);
            this.InvokeUI(() => LoadAllFiles(folder));
            SetStatus($"Loaded series metadata for '{folder}'");
        }

        private void MniViewRefresh_Click(object sender, EventArgs e)
            => LoadFolders(_seriesFolder);

        private void MniMede8erSetWatched_Click(object sender, EventArgs e)
        {
            if (SelectedEpisode())
            {
                //create  .t file
                var folder = tvwFolder.SelectedNode.Tag.ToString();
                var file = lvwFiles.SelectedItems[0].Text;
                Mede8erHelper.SetItemWatched(Path.Combine(folder, file));
                LoadAllFiles(folder);
            }
        }

        private void MniMede8erSetFolderWatched_Click(object sender, EventArgs e)
        {
            var folder = tvwFolder.SelectedNode.Tag.ToString();
            Mede8erHelper.SetFolderWatched(folder);
            LoadAllFiles(folder);
        }

        private void CtxExplore_Click(object sender, EventArgs e)
        {
            var tag = tvwFolder.SelectedNode.Tag;
            if (tag is not null && Directory.Exists(tag.ToString()))
            {
                Core.SeriesIOHelper.Launch("explorer.exe", tag.ToString().DoubleQuote());
            }
        }

        private async void MniTvdbRenameEpisodes_Click(object sender, EventArgs e)
        {
            await RenameEpisodes().ConfigureAwait(true);
            await GetSeasonData().ConfigureAwait(true);
        }

        private async void MniTvdbRenameEpisodesUI_Click(object sender, EventArgs e)
        {
            var getSeasonData = await RenameEpisodesUI().ConfigureAwait(false);
            if (getSeasonData)
            {
                this.InvokeUI(async () => await GetSeasonData().ConfigureAwait(false));
            }
        }

        private void MniTvdbClearMetadata_Click(object sender, EventArgs e)
            => ClearSeasonMetadata();

        #endregion Menus

        #region Helpers
        private void RestoreFormPosition()
        {
            if (_settings.AppConfiguration.WindowState is null)
            {
                _settings.AppConfiguration.WindowState = new();
            }
            this.SetWindowState(_settings.AppConfiguration.WindowState);
        }

        private void AddIcon(string fileName, string extension)
        {
            if (!IMG.Images.ContainsKey(extension) && !string.IsNullOrEmpty(extension))
            {
                try
                {
                    var icon = System.Drawing.Icon.ExtractAssociatedIcon(fileName);
                    IMG.Images.Add(extension, icon);
                }
                catch
                {
                }
            }
        }

        private bool HasId(string path) =>
            //contains tvdb.id file
            Directory.EnumerateFiles(path, Core.Constants.SERIES_XML).Any();

        private bool ParentHasId(string path)
        {
            //contains tvdb.id file
            var parentPath = new DirectoryInfo(path).Parent.FullName;
            return Directory.EnumerateFiles(parentPath, Core.Constants.SERIES_XML).Any();
        }

        private bool SelectedEpisode()
        {
            var videoExtensions = new List<string> { ".avi", ".mkv", ".mp4" };
            if (lvwFiles.SelectedItems.Count == 1)
            {
                var fileName = lvwFiles.SelectedItems[0].Text;
                return videoExtensions.Contains(Path.GetExtension(fileName));
            }
            return false;
        }

        private void SetStatus(string status, params object[] args)
        {
            Console.WriteLine(status, args);

            this.InvokeUI(() => lblStatus.Text = string.Format(status, args));
        }

        private void ClearSeasonMetadata()
        {
            var folder = tvwFolder.SelectedNode.Tag.ToString();
            ClearSeasonMetadata(folder);
            LoadAllFiles(folder);
            SetStatus($"Cleared season metadata for '{folder}'");
        }

        private void ClearSeasonMetadata(string folder)
        {
            var searchPatterns = new string[] { "*.jpg", "*.xml" };
            var toDelete = IOHelper.GetFiles(folder, searchPatterns);
            foreach (var file in toDelete)
            {
                File.Delete(file);
            }
        }

        #endregion

        #region Events
        private void lvwFiles_SelectedIndexChanged(object sender, EventArgs e)
            => mniMede8erSetWatched.Enabled = SelectedEpisode();

        private void MniFileExit_Click(object sender, EventArgs e)
            => Close();

        private void SelectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new CommonOpenFileDialog
            {
                InitialDirectory = _seriesFolder,
                IsFolderPicker = true
            })
            {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    _seriesFolder = dialog.FileName;
                    UpdateSeriesFolder(_seriesFolder);
                    LoadFolders(_seriesFolder);
                }
            }
        }

        private void UpdateSeriesFolder(string seriesFolder)
            => _seriesFolder = seriesFolder;

        #endregion

        #region Rename
        private async Task RenameEpisodes()
        {
            var folder = tvwFolder.SelectedNode.Tag.ToString();
            var seriesFolder = new DirectoryInfo(folder).Parent.FullName;
            var seriesName = Core.SeriesIOHelper.GetSeriesMetadata(seriesFolder).Series.Title;

            await SeasonHelper.RenameFiles(api: _tvdb, seriesName: seriesName, seasonPath: folder);
            LoadAllFiles(folder);
        }

        private async Task<bool> RenameEpisodesUI()
        {
            using (var renamer = new EpisodeRenameForm())
            {
                var folder = tvwFolder.SelectedNode.Tag.ToString();
                var episodes = await SeasonHelper.GetEpisodes(_tvdb, folder);
                var seriesFolder = new DirectoryInfo(folder).Parent.FullName;
                var seriesName = Core.SeriesIOHelper.GetSeriesMetadata(seriesFolder).Series.Title;
                renamer.ShowDialog(seriesName, folder, episodes);
                LoadAllFiles(folder);
                return renamer.GetSeasonData;
            }
        }

        #endregion
    }
}

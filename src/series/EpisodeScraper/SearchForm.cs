using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EpisodeScraper.TvDbSharper;
using MediaApps.Series.Core;
using WVN.WinForms.Extensions;

namespace EpisodeScraper
{
    public partial class SearchForm : Form
    {
        private readonly TvDbWrapper _api;
        private List<string> _posters = new List<string>();
        private List<byte[]> _posterData = new List<byte[]>();
        private int _posterIndex = 0;
        private List<string> _fanart = new List<string>();
        private List<byte[]> _fanartData = new List<byte[]>();
        private int _fanartIndex = 0;

        public SearchForm(TvDbWrapper api, string series)
        {
            InitializeComponent();
            _api = api;
            txtName.Text = series;
            //DoSearch().GetAwaiter().GetResult();
            //DoSearch();
        }

        public string TvdbId { get; private set; }
        public string SeriesId { get; private set; }
        public byte[] Poster { get; private set; }
        public byte[] FanArt { get; private set; }

        private async void Search(object sender, EventArgs e)
            => await DoSearch();

        private async Task DoSearch()
        {
            lvwResult.Items.Clear();
            var search = txtName.Text;
            var result = await _api.SearchSeries(search);
            foreach (var item in result)
            {
                var i = lvwResult.Items.Add(item.SeriesName);
                _ = i.SubItems.Add(item.IdString);
            }
            lvwResult.ResizeColumnsAll();
            if (lvwResult.Items.Count > 0)
            {
                lvwResult.Items[0].Selected = true;
            }
        }

        private async void lvwResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAccept.Enabled = lvwResult.SelectedItems.Count == 1;
            if (lvwResult.SelectedItems.Count > 0)
            {
                //get series cover if possible
                SeriesId = lvwResult.SelectedItems[0].SubItems[1].Text;
                var series = (await _api.GetSeriesFullRecord(SeriesId)).Series;
                lblPlot.Text = $"{series.Overview} ({series.RatingString})";
                await GetPostersAsync(SeriesId);
                await GetSeasonArtAsync(SeriesId);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            TvdbId = lvwResult.SelectedItems[0].SubItems[1].Text;
            DialogResult = DialogResult.OK;
        }

        private async Task GetPostersAsync(string seriesId)
        {
            var banners = await _api.GetArtwork(seriesId, BannerType.poster);
            _posters = _api.BannerImages(banners, BannerType.poster).ToList();
            _posterData = new List<byte[]>(_posters.Count);
            for (int i = 0; i < _posters.Count; i++)
            {
                _posterData.Add(null);
            }

            _posterIndex = 0;
            await LoadPostersAsync();
        }

        private async Task GetSeasonArtAsync(string seriesId)
        {
            try
            {
                var banners = await _api.GetArtwork(seriesId, BannerType.season);
                _fanart = _api.BannerImages(banners, BannerType.season).ToList(); //fanart, episode, poster, actors, season, and series.
                _fanartData = new List<byte[]>(_fanart.Count);
                for (int i = 0; i < _fanart.Count; i++)
                {
                    _fanartData.Add(null);
                }

                _fanartIndex = 0;
                if (_fanartData.Count > 0)
                {
                    await LoadFanArtAsync();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message, "Error getting season art");
            }
        }

        private async Task LoadPostersAsync()
        {
            if (_posterData[_posterIndex] == null)
            {
                //_posterData[_posterIndex] = await ImageHelper.DownloadDataAsync(_posters[_posterIndex]);
                _posterData[_posterIndex] = await _api.GetImageByUrl(_posters[_posterIndex]);
            }
            var poster = _posterData[_posterIndex];

            var originalImage = poster == null ? null : Image.FromStream(new MemoryStream(poster));
            Poster = poster;
            byte[] resized = ImageHelper.ResizeImage(poster, originalImage.Width, originalImage.Height);
            if (poster.LongLength > resized.LongLength)
            {
                picPoster.Image = Image.FromStream(new MemoryStream(resized));
                Poster = resized;
            }
            else
            {
                picPoster.Image = originalImage;
            }

            lblFanArtIndex.CheckInvoke(new Action(() => lblPosterIndex.Text = $"{_posterIndex + 1} of {_posters.Count}"));
        }

        private async Task LoadFanArtAsync()
        {
            if (_fanartData[_fanartIndex] == null)
            {
                //_fanartData[_fanartIndex] = await ImageHelper.DownloadDataAsync(_posters[_fanartIndex]);
                _fanartData[_fanartIndex] = await _api.GetImageByUrl(_posters[_fanartIndex]);
            }
            var fanart = _fanartData[_fanartIndex];

            picFanArt.Image = fanart == null ? null : Image.FromStream(new MemoryStream(fanart));
            FanArt = fanart;
            byte[] resized = ImageHelper.ResizeImage(fanart, picFanArt.Image.Width, picFanArt.Image.Height);
            if (fanart?.LongLength > resized.LongLength)
            {
                picFanArt.Image = Image.FromStream(new MemoryStream(resized));
                FanArt = resized;
            }

            lblFanArtIndex.CheckInvoke(new Action(() => lblFanArtIndex.Text = $"{_fanartIndex + 1} of {_fanart.Count}"));
        }

        private async void btnPrev_Click(object sender, EventArgs e)
        {
            if (_posterIndex > 0)
            {
                _posterIndex--;
                await LoadPostersAsync();
            }
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_posterIndex < _posters.Count - 1)
            {
                _posterIndex++;
                await LoadPostersAsync();
            }
        }

        private async void btnPrevArt_Click(object sender, EventArgs e)
        {
            if (_fanartIndex > 0)
            {
                _fanartIndex--;
                await LoadFanArtAsync();
            }
        }

        private async void btnNextArt_Click(object sender, EventArgs e)
        {
            if (_fanartIndex < _fanart.Count - 1)
            {
                _fanartIndex++;
                await LoadFanArtAsync();
            }
        }

        private void ShowImage(byte[] data)
        {
            var tempFile = SeriesIOHelper.GetTempFileWithExtension(".jpg");
            File.WriteAllBytes(tempFile, data);
            SeriesIOHelper.Launch(tempFile);
        }

        private void picPoster_DoubleClick(object sender, EventArgs e)
        {
            if (_posterData.Count > 0 && _posterData[_posterIndex] != null)
            {
                ShowImage(_posterData[_posterIndex]);
            }
        }

        private void picFanArt_DoubleClick(object sender, EventArgs e)
        {
            if (_fanartData.Count > 0 && _fanartData[_fanartIndex] != null)
            {
                ShowImage(_fanartData[_fanartIndex]);
            }
        }

        private async void SearchForm_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            await DoSearch();
        }
    }
}

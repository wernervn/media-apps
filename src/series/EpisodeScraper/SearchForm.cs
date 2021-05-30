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
        private List<string> _posters = new();
        private List<byte[]> _posterData = new();
        private int _posterIndex = 0;
        private List<string> _fanart = new();
        private List<byte[]> _fanartData = new();
        private int _fanartIndex = 0;

        public SearchForm(TvDbWrapper api, string series)
        {
            InitializeComponent();
            _api = api;
            txtName.Text = series;
        }

        public string TvdbId { get; private set; }
        public string SeriesId { get; private set; }
        public byte[] Poster { get; private set; }
        public byte[] FanArt { get; private set; }

        private async void Search(object sender, EventArgs e)
            => await DoSearch().ConfigureAwait(false);

        private async Task DoSearch()
        {
            lvwResult.Items.Clear();
            var search = txtName.Text;
            try
            {
                var result = await _api.SearchSeries(search).ConfigureAwait(true);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error search for series {search}\r\n{ex.Message}");
            }
        }

        private async void LvwResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAccept.Enabled = lvwResult.SelectedItems.Count == 1;
            if (lvwResult.SelectedItems.Count > 0)
            {
                //get series cover if possible
                SeriesId = lvwResult.SelectedItems[0].SubItems[1].Text;
                var series = (await _api.GetSeriesFullRecord(SeriesId)).Series;
                lblPlot.Text = $"{series.Overview} ({series.RatingString})";
                await GetPostersAsync(SeriesId).ConfigureAwait(true);
                await GetSeasonArtAsync(SeriesId).ConfigureAwait(true);
            }
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            TvdbId = lvwResult.SelectedItems[0].SubItems[1].Text;
            DialogResult = DialogResult.OK;
        }

        private async Task GetPostersAsync(string seriesId)
        {
            var banners = await _api.GetArtwork(seriesId, BannerType.poster);
            _posters = _api.BannerImages(banners, BannerType.poster).ToList();
            _posterData = new List<byte[]>(_posters.Count);
            for (var i = 0; i < _posters.Count; i++)
            {
                _posterData.Add(null);
            }

            _posterIndex = 0;
            await LoadPostersAsync().ConfigureAwait(true);
        }

        private async Task GetSeasonArtAsync(string seriesId)
        {
            try
            {
                var banners = await _api.GetArtwork(seriesId, BannerType.season);
                _fanart = _api.BannerImages(banners, BannerType.season).ToList(); //fanart, episode, poster, actors, season, and series.
                _fanartData = new List<byte[]>(_fanart.Count);
                for (var i = 0; i < _fanart.Count; i++)
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
                MessageBox.Show(ex.Message, "Error getting season art");
            }
        }

        private async Task LoadPostersAsync()
        {
            if (_posterData[_posterIndex] is null)
            {
                _posterData[_posterIndex] = await _api.GetImageByUrl(_posters[_posterIndex]).ConfigureAwait(true);
            }
            var poster = _posterData[_posterIndex];

            var originalImage = poster is null ? null : Image.FromStream(new MemoryStream(poster));
            Poster = poster;
            var resized = ImageHelper.ReduceImageSize(poster);
            if (poster.LongLength > resized.LongLength)
            {
                picPoster.Image = Image.FromStream(new MemoryStream(resized));
                Poster = resized;
            }
            else
            {
                picPoster.Image = originalImage;
            }

            lblFanArtIndex.InvokeUI(() => lblPosterIndex.Text = $"{_posterIndex + 1} of {_posters.Count}");
        }

        private async Task LoadFanArtAsync()
        {
            if (_fanartData[_fanartIndex] is null)
            {
                _fanartData[_fanartIndex] = await _api.GetImageByUrl(_posters[_fanartIndex]).ConfigureAwait(true);
            }
            var fanart = _fanartData[_fanartIndex];

            picFanArt.Image = fanart is null ? null : Image.FromStream(new MemoryStream(fanart));
            FanArt = fanart;
            var resized = ImageHelper.ReduceImageSize(fanart);
            if (fanart?.LongLength > resized.LongLength)
            {
                picFanArt.Image = Image.FromStream(new MemoryStream(resized));
                FanArt = resized;
            }

            lblFanArtIndex.InvokeUI(() => lblFanArtIndex.Text = $"{_fanartIndex + 1} of {_fanart.Count}");
        }

        private async void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_posterIndex > 0)
            {
                _posterIndex--;
                await LoadPostersAsync().ConfigureAwait(false);
            }
        }

        private async void BtnNext_Click(object sender, EventArgs e)
        {
            if (_posterIndex < _posters.Count - 1)
            {
                _posterIndex++;
                await LoadPostersAsync().ConfigureAwait(false);
            }
        }

        private async void BtnPrevArt_Click(object sender, EventArgs e)
        {
            if (_fanartIndex > 0)
            {
                _fanartIndex--;
                await LoadFanArtAsync().ConfigureAwait(false);
            }
        }

        private async void BtnNextArt_Click(object sender, EventArgs e)
        {
            if (_fanartIndex < _fanart.Count - 1)
            {
                _fanartIndex++;
                await LoadFanArtAsync().ConfigureAwait(false);
            }
        }

        private async Task ShowImage(byte[] data)
        {
            var tempFile = SeriesIOHelper.GetTempFileWithExtension(".jpg");
            await File.WriteAllBytesAsync(tempFile, data).ConfigureAwait(false);
            SeriesIOHelper.Launch(tempFile);
        }

        private async void PicPoster_DoubleClick(object sender, EventArgs e)
        {
            if (_posterData.Count > 0 && _posterData[_posterIndex] is not null)
            {
                await ShowImage(_posterData[_posterIndex]).ConfigureAwait(false);
            }
        }

        private async void PicFanArt_DoubleClick(object sender, EventArgs e)
        {
            if (_fanartData.Count > 0 && _fanartData[_fanartIndex] is not null)
            {
                await ShowImage(_fanartData[_fanartIndex]).ConfigureAwait(false);
            }
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            Application.DoEvents();
            this.InvokeUI(async () => await DoSearch().ConfigureAwait(false));
        }
    }
}

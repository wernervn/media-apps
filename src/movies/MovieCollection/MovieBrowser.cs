using System.Reflection;
using MovieCollection.Common;
using MovieCollection.Common.Interfaces;
using MovieCollection.Common.Models;
using MovieCollection.Configuration;
using Movies.TmDb;
using WVN.Configuration;
using WVN.Extensions;
using WVN.IO.Helpers;
using WVN.WinForms.Extensions;
using WVN.WinForms.Serialization;

namespace MovieCollection;

public partial class MovieBrowser : Form
{
    private readonly AppSettings _settings;

    private enum FileFilter
    {
        AllFiles,
        MoviesOnly
    }

    private bool _filterActive = true;

    private const string MOVIE_KEY = "Movie";
    private const string INFO_KEY = "Info";
    private const string WATCHED_KEY = "watched"; // eyes
    private const string POSTER_KEY = "poster";
    private const string MOVIE_TEXT = "movie.txt";
    private const string XML_KEY = "Xml";
    private readonly IMovieData _wrapper;
    private FileFilter _fileFilter;
    private Assembly _executingAssembly = Assembly.GetExecutingAssembly();

    public MovieBrowser()
    {
        InitializeComponent();

        _settings = AppSettingsManager.GetSettings<AppSettings>(options: SerializerOptions.Default);
        _wrapper = new TmDbData(_settings.AppConfiguration.ApiKey);

        SetResourceImages();
    }

    #region Set images from resources

    private void SetResourceImages()
    {
        mniViewWithMovies.Image = GetImageResource(Images.Video);
        mniViewWatched.Image = GetImageResource(Images.Eyes);
        mniViewPosters.Image = GetImageResource(Images.Poster);
        foldersWithXMLToolStripMenuItem.Image = GetImageResource(Images.Xml);
        foldersWithSplitMoviesToolStripMenuItem.Image = GetImageResource(Images.SplitMovie);
        mniMede8erWatched.Image = GetImageResource(Images.Eyes);
        mniMede8erCreatePoster.Image = GetImageResource(Images.Poster);
        splitAllFiles.Image = GetImageResource(Images.AllFiles);
        splitMoviesOnly.Image = GetImageResource(Images.Video);
        btnMakePoster.Image = GetImageResource(Images.Poster);
        searchDoSearch.Image = GetImageResource(Images.Filter);
        searchClearSearch.Image = GetImageResource(Images.Clear);
    }

    #endregion Set images from resources

    #region MNU clicks
    private void mniFileExit_Click(object sender, EventArgs e)
        => Close();

    private void mniViewFolder_Click(object sender, EventArgs e)
        => SelectFolder();

    private void mniViewWithMovies_Click(object sender, EventArgs e)
        => FolderContainsMovie();

    private void mniViewResetFolders_Click(object sender, EventArgs e)
    {
        var root = RootNode();
        if (root != null)
        {
            foreach (TreeNode node in root.Nodes)
            {
                node.ImageKey = Constants.FOLDER_KEY;
                node.SelectedImageKey = Constants.FOLDER_KEY;
            }
        }
    }

    private void mniViewWithInfo_Click(object sender, EventArgs e)
        => FolderContainsInfo();

    private void mniViewWatched_Click(object sender, EventArgs e)
        => MovieWatched();

    private void mniViewPosters_Click(object sender, EventArgs e)
        => FolderContainsPoster();

    private void mniViewReload_Click(object sender, EventArgs e)
        => RefreshView();

    private void RefreshView()
    {
        lvwFiles.Items.Clear();
        PIC.Image = null;
        picBackdrop.Image = null;
        txtMovieDescription.Text = string.Empty;
        txtMovieScore.Text = string.Empty;
        LoadFolders(_settings.AppConfiguration.LastPath);
    }

    private async void mniMovieDataSearch_Click(object sender, EventArgs e)
    {
        using var frm = new MovieSearch();
        var movieFolder = tvwFolder.SelectedNode.Tag.ToString();
        var movieName = new DirectoryInfo(tvwFolder.SelectedNode.Tag.ToString()).Name;
        frm.Show(_settings.AppConfiguration, _wrapper, movieName, this);
        if (frm.DialogResult == DialogResult.OK)
        {
            await PersistMovieInfoAsync(movieFolder, frm.SelectedMovie);
            FixFolderNameAsync(frm.SelectedMovie);
        }
    }

    private async void mniMovieDataDisplay_Click(object sender, EventArgs e)
        => await ShowMovieInfoAsync();

    private async void mniMovieDataCreateNFO_Click(object sender, EventArgs e)
        => await CreateNFOAsync();

    private async Task CreateNFOAsync()
    {
        const string IMDB_URL = @"http://www.imdb.com/title/{0}/";

        var infoFile = CurrentMovieInfoFile();
        if (!string.IsNullOrEmpty(infoFile))
        {
            //write nfo file from movie info
            var movie = await GetMovieDetailsAsync(infoFile);
            var movieURL = string.Format(IMDB_URL, movie.ImdbId);

            var searchFiles = new List<string>(Constants.MOVIE_VALUES.ToArray());
            var movieFiles = FileUtil.GetFiles(Path.GetDirectoryName(infoFile), searchFiles, SearchOption.AllDirectories).ToList();

            movieFiles.ForEach(file =>
            {
                var dir = Path.GetDirectoryName(file);
                var nfo = Path.GetFileNameWithoutExtension(file);
                var nfoFile = string.Concat(nfo, ".nfo");
                File.WriteAllText(Path.Combine(dir, nfoFile), movieURL);
            });
        }
    }

    private void mniBatchSettings_Click(object sender, EventArgs e)
    {
        //launch with path as filename
        var path = tvwFolder.Nodes[0].Text;
        var exe = "BatchMovieInfoGetter.exe";

        Helpers.Launch(exe, path);
    }

    [Obsolete]
    private void mniMede8erWatched_Click(object sender, EventArgs e)
    {
        if (tvwFolder.SelectedNode != null && tvwFolder.SelectedNode != RootNode())
        {
            Mede8erSetWatched(tvwFolder.SelectedNode);
        }
    }

    [Obsolete]
    private async void mniMede8erCreatePoster_Click(object sender, EventArgs e)
    {
        if (tvwFolder.SelectedNode != null && tvwFolder.SelectedNode != RootNode())
        {
            await CreatePosterAsync();
        }
    }

    private void foldersWithXMLToolStripMenuItem_Click(object sender, EventArgs e) => ContainsXml();

    #endregion MNU clicks

    #region CTX clicks
    private void ctxExplore_Click(object sender, EventArgs e)
    {
        var tag = tvwFolder.SelectedNode.Tag;
        if (tag != null && Directory.Exists(tag.ToString()))
        {
            Helpers.Launch("explorer.exe", tag.ToString().DoubleQuote());
        }
    }

    #endregion CTX clicks

    #region Form events
    private async void MovieBrowser_Load(object sender, EventArgs e)
    {
        await SetFilterAsync(FileFilter.AllFiles);
        if (_filterActive)
        {
            btnSplitSearch.Image = GetImageResource(Images.Filter);
            btnSplitSearch.ToolTipText = "Filter movies";
        }

        lvwFiles.SmallImageList = IMG;

        this.SetWindowState(_settings.AppConfiguration.WindowState);

        if (_settings.AppConfiguration.SplitterDistance > 0)
        {
            SPLIT.SplitterDistance = _settings.AppConfiguration.SplitterDistance;
        }

        if (Directory.Exists(_settings.AppConfiguration.LastPath))
        {
            LoadFolders(_settings.AppConfiguration.LastPath);
            Text = _settings.AppConfiguration.LastPath;
        }
    }

    private void MovieBrowser_FormClosing(object sender, FormClosingEventArgs e)
    {
        _settings.AppConfiguration.SplitterDistance = SPLIT.SplitterDistance;
        _settings.AppConfiguration.WindowState = this.GetWindowState();
        AppSettingsManager.SaveSettings(_settings, options: SerializerOptions.Default);
    }

    private void MovieBrowser_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            NextMovie();
        }
    }

    #endregion

    #region tvwFolder events
    private async void tvwFolder_AfterSelect(object sender, TreeViewEventArgs e)
    {
        var folder = e.Node.Tag.ToString();
        if (Directory.Exists(folder))
        {
            await LoadFilesByFilterAsync(folder);
            lblStatus.Text = string.Format("'{0}' contains {1} movie file(s)", folder, GetMovieFiles(folder).Count);

            //if its a movie folder then allow getting movie data
            SetMovieFolder();

            lvwFiles.ResizeColumnsAll();

            ResizeRest();
        }
        else
        {
            MessageBox.Show("The folder no longer exists. It has either been moved or deleted.", "Folder doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void tvwFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
    {
        //if the sub-folder is a dummy folder, remove it and add any real folder
        var node = e.Node;
        if (node.Nodes.Count == 1 && node.Nodes[0].Text == "dummy" && e.Node.Nodes[0].Tag == null)
        {
            e.Node.Nodes.Clear();
            tvwFolder.LoadFolders(node, node.Tag.ToString(), Constants.FOLDER_KEY);
        }
    }

    #endregion

    #region lvwFiles events
    private async void lvwFiles_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if (lvwFiles.SelectedItems.Count == 1)
        {
            await LaunchAsync();
        }
    }

    private Image _savedImage;

    private void lvwFiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedFile = GetSelectedFile();
        if (!string.IsNullOrWhiteSpace(selectedFile))
        {
            var fi = new FileInfo(selectedFile);
            if (Helpers.IsImageFile(fi.Extension))
            {
                _savedImage = PIC.Image;
                PIC.Image = Image.FromFile(selectedFile);
            }
            else
            {
                if (_savedImage != null)
                {
                    PIC.Image = _savedImage;
                }
            }
        }
    }

    #endregion

    #region Private methods
    private void SelectFolder()
    {
        using var dlg = new FolderBrowserDialog();
        if (Directory.Exists(_settings.AppConfiguration.LastPath))
        {
            dlg.SelectedPath = _settings.AppConfiguration.LastPath;
        }

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            LoadFolders(dlg.SelectedPath);
        }
    }

    private void LoadFolders(string path)
    {
        lvwFiles.Items.Clear();
        var count = tvwFolder.LoadFolders(path, Constants.FOLDER_KEY);
        _settings.AppConfiguration.LastPath = path;
        lblStatus.Text = string.Format("Root folder contains {0} movie folder(s)", count);
        if (tvwFolder.Nodes[0].Nodes.Count > 0)
        {
            tvwFolder.SelectedNode = tvwFolder.Nodes[0].Nodes[0];
        }
    }

    private void LoadFolders(string path, string filter)
    {
        lvwFiles.Items.Clear();
        var count = tvwFolder.LoadFolders(path, Constants.FOLDER_KEY, filter);
        _settings.AppConfiguration.LastPath = path;
        lblStatus.Text = string.Format("Root folder contains {0} movie folder(s)", count);
    }

    private void FolderContainsMovie()
    {
        var root = RootNode();
        if (root != null)
        {
            foreach (TreeNode node in root.Nodes)
            {
                FolderContainsMovie(node);
            }
        }
    }

    private void FolderContainsMovie(TreeNode node)
    {
        if (node.Tag != null && GetMovieFiles(node.Tag.ToString()).Any())
        {
            node.ImageKey = MOVIE_KEY;
            node.SelectedImageKey = MOVIE_KEY;
        }
    }

    private TreeNode RootNode() => tvwFolder.Nodes.Count > 0 ? tvwFolder.Nodes[0] : null;

    private List<string> GetMovieFiles(string folderPath)
    {
        var extensions = (from ext in Constants.MOVIE_VALUES
                          select "*" + ext).ToList();
        return FileUtil.GetFiles(folderPath, extensions, SearchOption.AllDirectories).ToList();
    }

    private List<string> GetInfoFiles(string folderPath)
        => FileUtil.GetFiles(folderPath, new string[] { Constants.MOVIE_DATA }, SearchOption.TopDirectoryOnly).ToList();

    private void FolderContainsInfo()
    {
        var root = RootNode();
        if (root != null)
        {
            foreach (TreeNode node in root.Nodes)
            {
                FolderContainsInfo(node);
            }
        }
    }

    private void FolderContainsInfo(TreeNode node)
    {
        if (node.Tag != null && GetInfoFiles(node.Tag.ToString()).Count > 0)
        {
            node.ImageKey = INFO_KEY;
            node.SelectedImageKey = INFO_KEY;
        }
    }

    private void MovieWatched()
    {
        var root = RootNode();
        if (root != null)
        {
            foreach (TreeNode node in root.Nodes)
            {
                MovieWatched(node);
            }
        }
    }

    private void MovieWatched(TreeNode node)
    {
        if (node.Tag != null && GetWatchedFiles(node.Tag.ToString()).Any())
        {
            node.ImageKey = WATCHED_KEY;
            node.SelectedImageKey = WATCHED_KEY;
        }
    }

    private void FolderContainsPoster()
    {
        var root = RootNode();
        if (root != null)
        {
            foreach (TreeNode node in root.Nodes)
            {
                FolderContainsPoster(node);
            }
        }
    }

    private void FolderContainsPoster(TreeNode node)
    {
        if (node.Tag != null && GetImageFiles(node.Tag.ToString()).Any())
        {
            node.ImageKey = POSTER_KEY;
            node.SelectedImageKey = POSTER_KEY;
        }
    }

    private List<string> GetWatchedFiles(string folderPath)
        => FileUtil.GetFiles(folderPath, new string[] { "*.t" }, SearchOption.AllDirectories).ToList();

    private List<string> GetImageFiles(string folderPath)
        => FileUtil.GetFiles(folderPath, Constants.IMAGE_VALUES, SearchOption.TopDirectoryOnly).ToList();

    private List<string> GetXmlFiles(string folderPath)
        => FileUtil.GetFiles(folderPath, new List<string>(new string[] { ".xml" }), SearchOption.TopDirectoryOnly).ToList();

    private async Task PersistMovieInfoAsync(string path, MovieDetails movie)
    {
        await Common.DB.MovieFile.WriteFile(path, movie);
        await LoadFilesByFilterAsync(path);
    }

    private async Task LoadFilesByFilterAsync(string path)
    {
        btnMakePoster.Enabled = false;

        switch (_fileFilter)
        {
            case FileFilter.AllFiles:
                await LoadAllFilesAsync(path);
                break;
            case FileFilter.MoviesOnly:
                await LoadMovieFilesAsync(path);
                break;
            default:
                await LoadAllFilesAsync(path);
                break;
        }
        ResizeRest();
    }

    private async Task LoadMovieFilesAsync(string path)
    {
        if (tvwFolder.SelectedNode != null && tvwFolder.SelectedNode != RootNode())
        {
            mniMovieDataDisplay.Enabled = false;
            mniMovieDataCreateNFO.Enabled = false;

            var searchFiles = new List<string>(Constants.MOVIE_VALUES.ToArray()) { "*.tmdb" };
            var files = FileUtil.GetFiles(path, searchFiles, SearchOption.AllDirectories).ToList();

            lvwFiles.BeginUpdate();
            lvwFiles.Items.Clear();

            PIC.Image = null;
            var movieText = string.Empty;
            var movieInfo = string.Empty;

            foreach (var file in files)
            {
                var fi = new FileInfo(file);
                var imgKey = fi.Extension;
                AddIcon(fi.FullName, imgKey);
                var item = lvwFiles.Items.Add(fi.Name, imgKey);
                item.SubItems.Add(Helpers.GetSize(fi.Length));
                item.SubItems.Add(path);

                if (fi.Name == Constants.MOVIE_DATA)
                {
                    item.ForeColor = Color.Blue;
                    item.Font = new Font(item.Font.FontFamily.Name, item.Font.Size, FontStyle.Bold);
                }

                //check if we can display any movie data upon request
                if (fi.Name.Equals(Constants.MOVIE_DATA, StringComparison.InvariantCultureIgnoreCase))
                {
                    mniMovieDataDisplay.Enabled = true;
                    mniMovieDataCreateNFO.Enabled = true;
                    movieInfo = fi.FullName;
                }
            }

            txtMovieDescription.Text = movieText;
            picBackdrop.Image = null;

            if (File.Exists(movieInfo))
            {
                var movie = await GetMovieDetailsAsync(movieInfo);
                PIC.Image = movie.PosterImage;
                txtMovieDescription.Text = movie.Overview;
                txtMovieScore.Text = $"Score: {movie.Popularity}";
                picBackdrop.Image = movie.BackdropImage;
            }

            lvwFiles.ResizeColumnsAll();
            lvwFiles.EndUpdate();
        }
    }

    private async Task LoadAllFilesAsync(string path)
    {
        var imgShown = false;
        mniMovieDataDisplay.Enabled = false;
        mniMovieDataCreateNFO.Enabled = false;

        var files = new List<string>(Directory.GetFiles(path));

        lvwFiles.BeginUpdate();
        lvwFiles.Items.Clear();

        PIC.Image = null;
        var movieText = string.Empty;

        var movieInfo = string.Empty;

        foreach (var file in files)
        {
            var fi = new FileInfo(file);
            var imgKey = fi.Extension;
            AddIcon(fi.FullName, imgKey);
            var item = lvwFiles.Items.Add(fi.Name, imgKey);
            item.SubItems.Add(Helpers.GetSize(fi.Length));
            item.SubItems.Add(path);

            if (fi.Name == Constants.MOVIE_DATA)
            {
                item.ForeColor = Color.Blue;
                item.Font = new Font(item.Font.FontFamily.Name, item.Font.Size, FontStyle.Bold);
            }

            //show the first image in the folder
            if (!imgShown && Helpers.IsImageFile(fi.Extension))
            {
                PIC.Image = Helpers.ImageFromFile(fi.FullName);
                imgShown = true;
            }

            //show movie.txt content if present
            if (fi.Name.Equals(MOVIE_TEXT, StringComparison.InvariantCultureIgnoreCase))
            {
                movieText = File.ReadAllText(file);
            }

            //set movie.info if present
            if (fi.Name.Equals(Constants.MOVIE_DATA, StringComparison.InvariantCultureIgnoreCase))
            {
                movieInfo = fi.FullName;
                mniMovieDataDisplay.Enabled = true;
                mniMovieDataCreateNFO.Enabled = true;
            }
        }

        txtMovieDescription.Text = movieText;
        picBackdrop.Image = null;

        if (File.Exists(movieInfo))
        {
            try
            {
                var movie = await GetMovieDetailsAsync(movieInfo);
                PIC.Image = movie.PosterImage;
                txtMovieDescription.Text = movie.Overview;
                txtMovieScore.Text = $"Score: {movie.Popularity}";
                picBackdrop.Image = movie.BackdropImage;
                btnMakePoster.Enabled = true;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during movie DB load. OK to delete db file?\r\n{ex.Message}";
                if (MessageBox.Show(message, "Delete movie db file?", MessageBoxButtons.YesNo) == DialogResult.Yes && File.Exists(movieInfo))
                {
                    File.Delete(movieInfo);
                }
            }
        }

        lvwFiles.ResizeColumnsAll();
        lvwFiles.EndUpdate();
    }

    private void AddIcon(string fileName, string extension)
    {
        try
        {
            if (!IMG.Images.ContainsKey(extension) && !string.IsNullOrEmpty(extension))
            {
                var icon = Icon.ExtractAssociatedIcon(fileName);
                IMG.Images.Add(extension, icon);
            }
        }
        catch
        {
            //Consume exception
        }
    }

    private async Task<MovieDetails> GetMovieDetailsAsync(string path)
        => await Common.DB.MovieFile.GetMovieDetailsAsync(path);

    private async Task ShowMovieInfoAsync()
    {
        var movie = CurrentMovieInfoFile();
        if (!string.IsNullOrEmpty(movie))
        {
            await ShowMovieDetailsAsync(movie);
        }
    }

    private string CurrentMovieInfoFile()
    {
        if (IsMovieFolder())
        {
            var folder = tvwFolder.SelectedNode.Tag.ToString();
            return Directory.GetFiles(folder, Constants.MOVIE_DATA).FirstOrDefault();
        }
        return string.Empty;
    }

    private bool IsMovieFolder()
        => tvwFolder.SelectedNode != null && tvwFolder.SelectedNode != RootNode();

    private async Task ShowMovieDetailsAsync(string archivePath)
    {
        if (File.Exists(archivePath))
        {
            var movie = await GetMovieDetailsAsync(archivePath);
            using var frm = new MovieDetailsView();
            frm.Show(_settings.AppConfiguration, movie, this);
        }
        else
        {
            MessageBox.Show(archivePath, "The archive no longer exists");
        }
    }

    [Obsolete]
    private void Mede8erSetWatched(TreeNode node)
    {
        //get all the movie file in the current folder
        if (node.Tag != null)
        {
            //create .t files for them
            var movies = GetMovieFiles(node.Tag.ToString());
            movies.ForEach(m =>
            {
                var watched = string.Concat(m, ".t");
                if (!File.Exists(watched))
                {
                    using (var fs = File.Create(watched))
                    {
                        fs.Close();
                    }
                }
            });
        }
    }

    private void SetMovieFolder()
    {
        var isMovieFolder = IsMovieFolder();
        mniMovieDataSearch.Enabled = isMovieFolder;
    }

    private string GetSelectedFile()
    {
        var retVal = string.Empty;

        if (lvwFiles.SelectedItems.Count == 1)
        {
            retVal = Path.Combine(lvwFiles.SelectedItems[0].SubItems[2].Text, lvwFiles.SelectedItems[0].SubItems[0].Text);
        }

        return retVal;
    }

    private async Task LaunchAsync()
    {
        var fi = GetSelectedFileInfo();
        if (fi != null)
        {
            switch (fi.Extension.ToLower())
            {
                case ".torrent":
                    //copy the torrent folder path to the clipboard
                    //launch the torrent downloader
                    Clipboard.SetText(fi.DirectoryName);
                    Helpers.Launch(fi.FullName);
                    break;
                case ".tmdb":
                    if (fi.Name.Equals(Constants.MOVIE_DATA, StringComparison.InvariantCultureIgnoreCase))
                    {
                        await ShowMovieDetailsAsync(fi.FullName);
                    }
                    break;
                case ".txt":
                case ".jpg":
                    Helpers.Launch(fi.FullName);
                    break;
                default:
                    if (Helpers.IsImageFile(fi.Extension) || Helpers.IsMovieFile(fi.Extension))
                    {
                        //launch the image in the default viewer
                        Helpers.Launch(fi.FullName);
                    }
                    break;
            }
        }
    }

    private FileInfo GetSelectedFileInfo()
    {
        FileInfo fi = null;
        var selectedFile = GetSelectedFile();
        if (selectedFile.Length > 0 && File.Exists(selectedFile))
        {
            fi = new FileInfo(selectedFile);
        }
        return fi;
    }

    private string GetCurrentFolder() => tvwFolder.SelectedNode.Tag.ToString();

    private async Task CreatePosterAsync()
    {
        var movieFile = CurrentMovieInfoFile();
        if (File.Exists(movieFile))
        {
            var movie = await GetMovieDetailsAsync(movieFile);
            if (movie.Poster != null)
            {
                var folder = Path.GetDirectoryName(movieFile);
                var poster = Path.Combine(folder, "poster.jpg");
                File.WriteAllBytes(poster, movie.Poster);
                await LoadFilesByFilterAsync(GetCurrentFolder());
            }
        }
    }

    /// <summary>
    /// renames the current folder name to MOVIE_NAME (YEAR)
    /// </summary>
    private void FixFolderNameAsync(MovieDetails movie)
    {
        if (!Directory.Exists(tvwFolder.SelectedNode.Tag.ToString()))
        {
            MessageBox.Show("Directory no longer exists - it may have been deleted or rename", "Directory does not exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        var movieFile = CurrentMovieInfoFile();
        if (movie.Poster != null)
        {
            var folder = Path.GetDirectoryName(movieFile);
            var dirInfo = new DirectoryInfo(folder);

            var title = movie.Title;
            var year = !string.IsNullOrWhiteSpace(movie.Released) ?  DateTime.Parse(movie.Released).Year.ToString() : "(0000)";
            var newName = IOHelper.CleanFileName(string.Format("{0} ({1})", title, year));
            var fixedName = Path.Combine(dirInfo.Parent.FullName, newName);

            try
            {
                //fix the name
                if (!string.Equals(folder, fixedName, StringComparison.OrdinalIgnoreCase))
                {
                    // the rename will fail if any files are locked
                    Directory.Move(folder, fixedName);

                    //fix the treeview
                    var node = tvwFolder.SelectedNode;
                    node.Tag = fixedName;
                    node.Text = newName;
                }

                //advance to the next folder
                NextMovie();
            }
            catch (Exception ex)
            {
                var msg = string.Format("Error renaming folder from:\r\n{0}\r\n{1}\r\n{2}", folder, fixedName, ex.Message);
                MessageBox.Show(msg, "Error renaming folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void NextMovie()
    {
        //move to next movie
        if (tvwFolder.SelectedNode != null
            && tvwFolder.SelectedNode != RootNode()
            && tvwFolder.SelectedNode.NextNode != null)
        {
            tvwFolder.SelectedNode = tvwFolder.SelectedNode.NextNode;
        }
    }

    private void ContainsXml()
    {
        var root = RootNode();
        if (root != null)
        {
            foreach (TreeNode node in root.Nodes)
            {
                ContainsXml(node);
            }
        }
    }

    private void ContainsXml(TreeNode node)
    {
        if (node.Tag != null && GetXmlFiles(node.Tag.ToString()).Count > 0)
        {
            node.ImageKey = XML_KEY;
            node.SelectedImageKey = XML_KEY;
        }
    }

    #endregion Private methods

    #region Toolbar

    #region View filters
    private async void splitAllFiles_Click(object sender, EventArgs e)
        => await SetFilterAsync(FileFilter.AllFiles);

    private async void splitMoviesOnly_Click(object sender, EventArgs e)
        => await SetFilterAsync(FileFilter.MoviesOnly);

    private async Task SetFilterAsync(FileFilter filter)
    {
        _fileFilter = filter;
        btnSplit.Image = GetFilterImage(_fileFilter);
        btnSplit.ToolTipText = _fileFilter.ToString();
        if (tvwFolder.SelectedNode != null)
        {
            await LoadFilesByFilterAsync(tvwFolder.SelectedNode.Tag.ToString());
        }
    }

    private Image GetFilterImage(FileFilter filter)
    {
        return filter switch
        {
            FileFilter.AllFiles => GetImageResource(Images.AllFiles),
            FileFilter.MoviesOnly => GetImageResource(Images.Video),
            _ => GetImageResource(Images.AllFiles),
        };
    }

    #endregion View filters

    private async void btnMakePoster_Click(object sender, EventArgs e)
        => await CreatePosterAsync();

    #region Search
    #endregion Search

    #endregion Toolbar

    #region Resize
    private void PIC_Resize(object sender, EventArgs e)
        => ResizeAll();

    private void SPLIT_Panel2_Resize(object sender, EventArgs e)
        => ResizeRest();

    private void ResizeAll()
    {
        //width should be 67% of height
        PIC.Width = Convert.ToInt32(PIC.Height * 0.67);
        ResizeRest();
    }

    private void ResizeRest()
    {
        SPLIT.Panel2.SuspendLayout();

        picBackdrop.Left = PIC.Width + 0;
        picBackdrop.Top = PIC.Top;
        picBackdrop.Width = SPLIT.Panel2.ClientSize.Width - txtMovieDescription.Left;
        txtMovieDescription.Left = picBackdrop.Left;
        txtMovieDescription.Width = picBackdrop.Width;

        if (picBackdrop.Image != null)
        {
            //keep aspect ratio
            var ratio = picBackdrop.Image.Height / (decimal)picBackdrop.Image.Width;
            var height = Convert.ToInt32(picBackdrop.Width * ratio);
            picBackdrop.Size = new Size(picBackdrop.Width, height);
        }
        else
        {
            picBackdrop.Size = new Size(0, 0);
        }

        txtMovieDescription.Top = (picBackdrop.Height + picBackdrop.Top);
        txtMovieDescription.Height = SPLIT.Panel2.ClientSize.Height - txtMovieDescription.Top - txtMovieScore.Height;

        txtMovieScore.Left = txtMovieDescription.Left;
        txtMovieScore.Width = txtMovieDescription.Width;
        txtMovieScore.Top = (txtMovieDescription.Height + txtMovieDescription.Top);

        lvwFiles.Width = SPLIT.Panel2.Width;

        SPLIT.Panel2.ResumeLayout();
    }

    #endregion Resize

    #region Filter movies by title
    private void searchDoSearch_Click(object sender, EventArgs e)
        => FilterMovies();

    private void searchClearSearch_Click(object sender, EventArgs e)
        => ClearMovieFilter();

    private void FilterMovies()
    {
        _filterActive = true;
        if (!string.IsNullOrWhiteSpace(txtSearch.Text))
        {
            btnSplitSearch.Image = GetImageResource(Images.Filter);
            lvwFiles.Items.Clear();
            PIC.Image = null;
            picBackdrop.Image = null;
            txtMovieDescription.Text = string.Empty;
            txtMovieScore.Text = string.Empty;
            LoadFolders(_settings.AppConfiguration.LastPath, txtSearch.Text);
        }
        btnSplitSearch.Image = GetImageResource(Images.Filter);
        btnSplitSearch.ToolTipText = "Filter movies";
    }

    private void ClearMovieFilter()
    {
        _filterActive = false;
        btnSplitSearch.Image = GetImageResource(Images.Clear);
        btnSplitSearch.ToolTipText = "Remove filter";
        txtSearch.Text = string.Empty;
        LoadFolders(_settings.AppConfiguration.LastPath);

        //TODO: reset to filter

    }

    private void btnSplitSearch_ButtonClick(object sender, EventArgs e)
    {
        if (_filterActive)
        {
            FilterMovies();
        }
        else
        {
            ClearMovieFilter();
        }
    }

    #endregion Filter movies by title

    private void mniCleanDeleteFolder_Click(object sender, EventArgs e)
    {
        if (IsMovieFolder())
        {
            var folder = GetCurrentFolder();
            if (MessageBox.Show($"Do you really want to delete folder '{folder}'?", "OK to delete folder?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Directory.Delete(folder, true);

                var oldNode = tvwFolder.SelectedNode;
                var newNode = tvwFolder.SelectedNode.NextNode;
                newNode ??= tvwFolder.SelectedNode.PrevNode;

                tvwFolder.Nodes.Remove(oldNode);
                if (newNode != null)
                {
                    tvwFolder.SelectedNode = newNode;
                    tvwFolder.SelectedNode = tvwFolder.SelectedNode.PrevNode;
                }
            }
        }
    }

    private Image GetImageResource(Images image)
        => _executingAssembly.GetResourceImage($"MovieCollection.Resources.{image}.png");
}

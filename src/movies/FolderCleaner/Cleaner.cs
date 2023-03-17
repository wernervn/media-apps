using System.Reflection;
using System.Text.RegularExpressions;
using FolderCleaner.Configuration;
using MovieCollection.Common;
using WVN.Configuration;
using WVN.Extensions;
using WVN.IO.Helpers;
using WVN.WinForms.Extensions;
using WVN.WinForms.Serialization;

namespace FolderCleaner;

public partial class Cleaner : Form
{
    private readonly AppSettings _settings;
    private StringComparer COMPARER = StringComparer.CurrentCultureIgnoreCase;
    private List<string> _ignoreFiles = new();
    private readonly Assembly _executingAssembly;

    public Cleaner()
    {
        InitializeComponent();

        _executingAssembly = Assembly.GetExecutingAssembly();
        _settings = AppSettingsManager.GetSettings<AppSettings>(options: SerializerOptions.Default);

        SetResourceImages();
    }

    private void SetResourceImages()
    {
        btnCleanFolder.Image = GetImageResource(Images.Gear);
    }

    private Image GetImageResource(Images image)
        => _executingAssembly.GetResourceImage($"FolderCleaner.Resources.{image}.png");

    #region Start & Stop
    private void frmMain_Load(object sender, EventArgs e)
    {
        this.SetWindowState(_settings.AppConfiguration.WindowState);

        SetIgnoreFiles();

        LoadFolders();

        if (_settings.AppConfiguration.FoldersWidth > 0)
        {
            SPLIT.SplitterDistance = _settings.AppConfiguration.FoldersWidth;
        }

        if (_settings.AppConfiguration.DeleteItemsHeight > 0)
        {
            splitFiles.SplitterDistance = _settings.AppConfiguration.DeleteItemsHeight;
        }
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        _settings.AppConfiguration.WindowState = this.GetWindowState();
        _settings.AppConfiguration.FoldersWidth = SPLIT.SplitterDistance;
        _settings.AppConfiguration.DeleteItemsHeight = splitFiles.SplitterDistance;
        AppSettingsManager.SaveSettings(_settings, options: SerializerOptions.Default);
    }

    #endregion

    #region Private methods

    private void LoadFolders()
    {
        if (!string.IsNullOrWhiteSpace(_settings.AppConfiguration.LastPath) && Directory.Exists(_settings.AppConfiguration.LastPath))
        {
            tvwFolder.LoadFolders(_settings.AppConfiguration.LastPath, MovieCollection.Common.Constants.FOLDER_KEY);
        }
    }

    private void SetMovieFolder()
    {
        var isMovieFolder = IsMovieFolder();
        //TODO: ???
    }

    private bool IsMovieFolder()
        => tvwFolder.SelectedNode != null && tvwFolder.SelectedNode != RootNode();

    private TreeNode RootNode()
    {
        if (tvwFolder.Nodes.Count > 0)
        {
            return tvwFolder.Nodes[0];
        }

        return null;
    }

    private void CleanFolder()
    {
        if (MessageBox.Show("Are you sure you want to perform the outlined actions", "OK to clean folder?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        try
        {
            //1) move the files first
            var checkedItems = (from item in lvwFilesRename.Items.Cast<ListViewItem>()
                                where item.Checked
                                select new { Source = item.SubItems[1].Text, Destination = item.SubItems[2].Text }).ToList();
            if (!checkedItems.Any())
            {
                MessageBox.Show("There must be at least one file to keep. Check your file selection?", "No files to keep", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            checkedItems.ForEach(move => File.Move(move.Source, move.Destination));

            //2) the delete the folders
            var deleteFolder = (from item in lvwDeleteFolders.Items.Cast<ListViewItem>()
                                where item.ImageKey != "AllFiles"
                                select item.Text).ToList();
            deleteFolder.ForEach(folder =>
            {
                if (Directory.Exists(folder))
                    Directory.Delete(folder, true);
            });

            //delete all ignore files
            var ignoreItems = (from item in lvwFilesRename.Items.Cast<ListViewItem>()
                               let path = item.SubItems[1].Text
                               where !item.Checked
                               where _ignoreFiles.Contains(Path.GetFileName(path), COMPARER)
                               select path).ToList();
            ignoreItems.ForEach(File.Delete);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "Error occurred during cleanup", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        LoadAllFiles(tvwFolder.SelectedNode.Tag.ToString());
    }

    private void SetIgnoreFiles()
    {
        _ignoreFiles.Clear();
        if (_settings.AppConfiguration.IgnoreList.Count > 0)
        {
            _ignoreFiles.AddRange(_settings.AppConfiguration.IgnoreList);
        }
    }

    #endregion

    #region tvwFolder events
    private void tvwFolder_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node == RootNode())
        {
            lvwFilesRename.Items.Clear();
            return;
        }

        var folder = e.Node.Tag.ToString();
        if (Directory.Exists(folder))
        {
            LoadAllFiles(folder);

            //if its a movie folder then allow getting movie data
            SetMovieFolder();

            lvwFilesRename.ResizeColumnsAll();
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
            tvwFolder.LoadFolders(node, node.Tag.ToString(), MovieCollection.Common.Constants.FOLDER_KEY);
        }
    }

    private void ctxExplore_Click(object sender, EventArgs e)
    {
        var tag = tvwFolder.SelectedNode.Tag;
        if (tag != null && Directory.Exists(tag.ToString()))
        {
            Helpers.Launch(@"C:\Windows\explorer.exe", tag.ToString().DoubleQuote());
        }
    }

    #endregion

    #region load files

    private static List<string> GetExtensions()
    {
        return (from x in Constants.RENAME_FILES.Concat(Constants.ONLY_MOVE_FILES).Distinct()
                select $"*{x}").ToList();
    }

    private void LoadAllFiles(string path)
    {
        var extensions = GetExtensions();
        var files = FileUtil.GetFiles(path, extensions, SearchOption.AllDirectories).ToList();

        //check for existing new names
        var newNames = new List<string>();

        #region Folders and files to delete
        LoadDeleteItems(path);
        #endregion

        lvwFilesRename.BeginUpdate();
        lvwFilesRename.Items.Clear();

        foreach (var file in files)
        {
            var nameOnly = Path.GetFileName(file);
            var imgKey = Path.GetExtension(file);
            AddIcon(file);
            var item = lvwFilesRename.Items.Add(nameOnly, imgKey);
            item.SubItems.Add(file);
            var newName = NewPath(path, nameOnly);
            if (newNames.Contains(newName, COMPARER))
            {
                item.ForeColor = Color.Red;
            }
            else
            {
                if (!_ignoreFiles.Contains(nameOnly, COMPARER))
                {
                    newNames.Add(newName);
                    item.Checked = true;
                }
            }

            item.SubItems.Add(newName);
            if (string.Equals(item.SubItems[1].Text, item.SubItems[2].Text, StringComparison.OrdinalIgnoreCase))
            {
                item.Checked = false;
                item.ForeColor = Color.Green;
            }

            if (_ignoreFiles.Contains(item.Text, COMPARER))
            {
                item.Checked = false;
            }
        }

        lvwFilesRename.ResizeColumnsAll();
        lvwFilesRename.EndUpdate();

        tvwFolder.Focus();
    }

    private void LoadDeleteItems(string path)
    {
        lvwDeleteFolders.Items.Clear();
        var removeDirs = Directory.EnumerateDirectories(path, "*", SearchOption.TopDirectoryOnly).AsParallel();
        var deleteFolders = (from dir in removeDirs
                             select new ListViewItem(dir, 0) { Checked = true }).ToArray();

        var toDelete = (removeDirs.SelectMany(dir => Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).AsParallel()
                            .Where(file => !Constants.RENAME_FILES.Contains(Path.GetExtension(file), COMPARER))
                            .Where(file => !Constants.RENAME_FILES.Contains(Path.GetExtension(file), COMPARER)) //?? why duplicate?
                            .Where(file => !Constants.ONLY_MOVE_FILES.Contains(Path.GetExtension(file), COMPARER))
                            )).ToList();
        //add icons
        toDelete.ForEach(AddIcon);

        var deletedFiles = (from item in toDelete
                            select new ListViewItem(item, Path.GetExtension(item)) { Checked = true }).ToArray();

        lvwDeleteFolders.Items.AddRange(deleteFolders);
        lvwDeleteFolders.Items.AddRange(deletedFiles);
        lvwDeleteFolders.ResizeColumnsAll();
    }

    //TODO: wrap this in a class that gets and stores icons
    private void AddIcon(string fileName)
    {
        var extension = Path.GetExtension(fileName);
        if (!IMG.Images.ContainsKey(extension) && extension.Length > 0)
        {
            var icon = Icon.ExtractAssociatedIcon(fileName);
            IMG.Images.Add(extension, icon);
        }
    }

    private string NewPath(string path, string fileName)
    {
        var folderFileName = new DirectoryInfo(path).Name;
        var extension = Path.GetExtension(fileName);

        if (Constants.RENAME_FILES.Contains(extension, COMPARER))
        {
            if (!Constants.WATCHED_FILES.Contains(extension, COMPARER))
            {
                var noExtension = Regex.Escape(Path.GetFileNameWithoutExtension(fileName));
                var newName = Regex.Replace(fileName, noExtension, folderFileName, RegexOptions.IgnoreCase);
                return Path.Combine(path, newName);
            }
            else
            {
                //handle .t files different
                var matchFile = Path.GetFileNameWithoutExtension(fileName);
                var noExtension = Regex.Escape(Path.GetFileNameWithoutExtension(matchFile));
                var newName = Regex.Replace(matchFile, noExtension, folderFileName, RegexOptions.IgnoreCase);
                return Path.Combine(path, string.Concat(newName, extension));
            }
        }
        else
        {
            //do not rename the file, just move it
            return Path.Combine(path, fileName);
        }
    }
    #endregion

    #region Misc events

    private void btnCleanFolder_Click(object sender, EventArgs e)
    {
        CleanFolder();
    }

    private void frmMain_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F6)
        {
            CleanFolder();
        }
    }

    #endregion

    #region Settings menu
    private void mniSettingsFolder_Click(object sender, EventArgs e)
    {
        using var dlg = new FolderBrowserDialog();
        if (!string.IsNullOrWhiteSpace(_settings.AppConfiguration.LastPath))
        {
            dlg.SelectedPath = _settings.AppConfiguration.LastPath;
        }

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            _settings.AppConfiguration.LastPath = dlg.SelectedPath;
            LoadFolders();
        }
    }

    private void mniSettingsUpdate_Click(object sender, EventArgs e)
    {
        using var frm = new SettingsForm();
        frm.Show(_settings.AppConfiguration);
        if (frm.DialogResult == DialogResult.OK)
        {
            SetIgnoreFiles();
        }
    }

    #endregion

    private void mniViewReload_Click(object sender, EventArgs e)
    {
        lvwFilesRename.Items.Clear();
        LoadFolders();
    }
}

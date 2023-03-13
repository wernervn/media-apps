namespace MovieCollection
{
    partial class MovieBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieBrowser));
            this.MNU = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewWithMovies = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewResetFolders = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewWithInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewWatched = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewPosters = new System.Windows.Forms.ToolStripMenuItem();
            this.mniViewReload = new System.Windows.Forms.ToolStripMenuItem();
            this.foldersWithXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foldersWithSplitMoviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuData = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMovieDataSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMovieDataDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMovieDataCreateNFO = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBatch = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBatchSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMede8er = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMede8erWatched = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMede8erCreatePoster = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMede8erFixFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.STB = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.SPLIT = new System.Windows.Forms.SplitContainer();
            this.tvwFolder = new System.Windows.Forms.TreeView();
            this.CTX = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.IMG = new System.Windows.Forms.ImageList(this.components);
            this.txtMovieScore = new System.Windows.Forms.TextBox();
            this.txtMovieDescription = new System.Windows.Forms.TextBox();
            this.picBackdrop = new System.Windows.Forms.PictureBox();
            this.PIC = new System.Windows.Forms.PictureBox();
            this.TOOLS = new System.Windows.Forms.ToolStrip();
            this.btnSplit = new System.Windows.Forms.ToolStripSplitButton();
            this.splitAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.splitMoviesOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMakePoster = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSplitSearch = new System.Windows.Forms.ToolStripSplitButton();
            this.searchDoSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.searchClearSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.colFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuClean = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCleanDeleteFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.MNU.SuspendLayout();
            this.STB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPLIT)).BeginInit();
            this.SPLIT.Panel1.SuspendLayout();
            this.SPLIT.Panel2.SuspendLayout();
            this.SPLIT.SuspendLayout();
            this.CTX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackdrop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIC)).BeginInit();
            this.TOOLS.SuspendLayout();
            this.SuspendLayout();
            // 
            // MNU
            // 
            this.MNU.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MNU.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MNU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuData,
            this.mnuBatch,
            this.mnuMede8er,
            this.mnuClean});
            this.MNU.Location = new System.Drawing.Point(0, 0);
            this.MNU.Name = "MNU";
            this.MNU.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.MNU.Size = new System.Drawing.Size(968, 36);
            this.MNU.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(54, 32);
            this.mnuFile.Text = "&File";
            // 
            // mniFileExit
            // 
            this.mniFileExit.Name = "mniFileExit";
            this.mniFileExit.Size = new System.Drawing.Size(127, 32);
            this.mniFileExit.Text = "E&xit";
            this.mniFileExit.Click += new System.EventHandler(this.mniFileExit_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniViewFolder,
            this.mniViewWithMovies,
            this.mniViewResetFolders,
            this.mniViewWithInfo,
            this.mniViewWatched,
            this.mniViewPosters,
            this.mniViewReload,
            this.foldersWithXMLToolStripMenuItem,
            this.foldersWithSplitMoviesToolStripMenuItem});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(65, 32);
            this.mnuView.Text = "View";
            // 
            // mniViewFolder
            // 
            this.mniViewFolder.Name = "mniViewFolder";
            this.mniViewFolder.Size = new System.Drawing.Size(400, 32);
            this.mniViewFolder.Text = "Select folder...";
            this.mniViewFolder.Click += new System.EventHandler(this.mniViewFolder_Click);
            // 
            // mniViewWithMovies
            // 
            //this.mniViewWithMovies.Image = global::MovieCollection.Properties.Resources.Video;
            this.mniViewWithMovies.Name = "mniViewWithMovies";
            this.mniViewWithMovies.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.M)));
            this.mniViewWithMovies.Size = new System.Drawing.Size(400, 32);
            this.mniViewWithMovies.Text = "Folders with movies";
            this.mniViewWithMovies.Click += new System.EventHandler(this.mniViewWithMovies_Click);
            // 
            // mniViewResetFolders
            // 
            this.mniViewResetFolders.Name = "mniViewResetFolders";
            this.mniViewResetFolders.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.R)));
            this.mniViewResetFolders.Size = new System.Drawing.Size(400, 32);
            this.mniViewResetFolders.Text = "Reset folders";
            this.mniViewResetFolders.Click += new System.EventHandler(this.mniViewResetFolders_Click);
            // 
            // mniViewWithInfo
            // 
            this.mniViewWithInfo.Name = "mniViewWithInfo";
            this.mniViewWithInfo.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.I)));
            this.mniViewWithInfo.Size = new System.Drawing.Size(400, 32);
            this.mniViewWithInfo.Text = "Folders with info";
            this.mniViewWithInfo.Click += new System.EventHandler(this.mniViewWithInfo_Click);
            // 
            // mniViewWatched
            // 
            //this.mniViewWatched.Image = global::MovieCollection.Properties.Resources.eyes;
            this.mniViewWatched.Name = "mniViewWatched";
            this.mniViewWatched.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.W)));
            this.mniViewWatched.Size = new System.Drawing.Size(400, 32);
            this.mniViewWatched.Text = "Watched movies";
            this.mniViewWatched.Click += new System.EventHandler(this.mniViewWatched_Click);
            // 
            // mniViewPosters
            // 
            //this.mniViewPosters.Image = global::MovieCollection.Properties.Resources.Poster;
            this.mniViewPosters.Name = "mniViewPosters";
            this.mniViewPosters.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.P)));
            this.mniViewPosters.Size = new System.Drawing.Size(400, 32);
            this.mniViewPosters.Text = "Folders with a poster";
            this.mniViewPosters.Click += new System.EventHandler(this.mniViewPosters_Click);
            // 
            // mniViewReload
            // 
            this.mniViewReload.Name = "mniViewReload";
            this.mniViewReload.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mniViewReload.Size = new System.Drawing.Size(400, 32);
            this.mniViewReload.Text = "Reload folders";
            this.mniViewReload.Click += new System.EventHandler(this.mniViewReload_Click);
            // 
            // foldersWithXMLToolStripMenuItem
            // 
            //this.foldersWithXMLToolStripMenuItem.Image = global::MovieCollection.Properties.Resources.Xml;
            this.foldersWithXMLToolStripMenuItem.Name = "foldersWithXMLToolStripMenuItem";
            this.foldersWithXMLToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.X)));
            this.foldersWithXMLToolStripMenuItem.Size = new System.Drawing.Size(400, 32);
            this.foldersWithXMLToolStripMenuItem.Text = "Folders with XML";
            this.foldersWithXMLToolStripMenuItem.Click += new System.EventHandler(this.foldersWithXMLToolStripMenuItem_Click);
            // 
            // foldersWithSplitMoviesToolStripMenuItem
            // 
            //this.foldersWithSplitMoviesToolStripMenuItem.Image = global::MovieCollection.Properties.Resources.SplitMovie;
            this.foldersWithSplitMoviesToolStripMenuItem.Name = "foldersWithSplitMoviesToolStripMenuItem";
            this.foldersWithSplitMoviesToolStripMenuItem.Size = new System.Drawing.Size(400, 32);
            this.foldersWithSplitMoviesToolStripMenuItem.Text = "Folders with split movies";
            // 
            // mnuData
            // 
            this.mnuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniMovieDataSearch,
            this.mniMovieDataDisplay,
            this.mniMovieDataCreateNFO});
            this.mnuData.Name = "mnuData";
            this.mnuData.Size = new System.Drawing.Size(65, 32);
            this.mnuData.Text = "&Data";
            // 
            // mniMovieDataSearch
            // 
            this.mniMovieDataSearch.Enabled = false;
            this.mniMovieDataSearch.Name = "mniMovieDataSearch";
            this.mniMovieDataSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mniMovieDataSearch.Size = new System.Drawing.Size(273, 32);
            this.mniMovieDataSearch.Text = "&Search...";
            this.mniMovieDataSearch.Click += new System.EventHandler(this.mniMovieDataSearch_Click);
            // 
            // mniMovieDataDisplay
            // 
            this.mniMovieDataDisplay.Enabled = false;
            this.mniMovieDataDisplay.Name = "mniMovieDataDisplay";
            this.mniMovieDataDisplay.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mniMovieDataDisplay.Size = new System.Drawing.Size(273, 32);
            this.mniMovieDataDisplay.Text = "Display info...";
            this.mniMovieDataDisplay.Click += new System.EventHandler(this.mniMovieDataDisplay_Click);
            // 
            // mniMovieDataCreateNFO
            // 
            this.mniMovieDataCreateNFO.Name = "mniMovieDataCreateNFO";
            this.mniMovieDataCreateNFO.Size = new System.Drawing.Size(273, 32);
            this.mniMovieDataCreateNFO.Text = "Create NFO";
            this.mniMovieDataCreateNFO.Click += new System.EventHandler(this.mniMovieDataCreateNFO_Click);
            // 
            // mnuBatch
            // 
            this.mnuBatch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniBatchSettings});
            this.mnuBatch.Name = "mnuBatch";
            this.mnuBatch.Size = new System.Drawing.Size(72, 32);
            this.mnuBatch.Text = "&Batch";
            // 
            // mniBatchSettings
            // 
            this.mniBatchSettings.Name = "mniBatchSettings";
            this.mniBatchSettings.Size = new System.Drawing.Size(179, 32);
            this.mniBatchSettings.Text = "Settings...";
            this.mniBatchSettings.Click += new System.EventHandler(this.mniBatchSettings_Click);
            // 
            // mnuMede8er
            // 
            this.mnuMede8er.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniMede8erWatched,
            this.mniMede8erCreatePoster,
            this.mniMede8erFixFolder});
            this.mnuMede8er.Name = "mnuMede8er";
            this.mnuMede8er.Size = new System.Drawing.Size(102, 32);
            this.mnuMede8er.Text = "Mede8er";
            // 
            // mniMede8erWatched
            // 
            //this.mniMede8erWatched.Image = global::MovieCollection.Properties.Resources.eyes;
            this.mniMede8erWatched.Name = "mniMede8erWatched";
            this.mniMede8erWatched.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mniMede8erWatched.Size = new System.Drawing.Size(390, 32);
            this.mniMede8erWatched.Text = "Mark content as watched";
            this.mniMede8erWatched.Click += new System.EventHandler(this.mniMede8erWatched_Click);
            // 
            // mniMede8erCreatePoster
            // 
            //this.mniMede8erCreatePoster.Image = global::MovieCollection.Properties.Resources.Poster;
            this.mniMede8erCreatePoster.Name = "mniMede8erCreatePoster";
            this.mniMede8erCreatePoster.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mniMede8erCreatePoster.Size = new System.Drawing.Size(390, 32);
            this.mniMede8erCreatePoster.Text = "Create poster";
            this.mniMede8erCreatePoster.Click += new System.EventHandler(this.mniMede8erCreatePoster_Click);
            // 
            // mniMede8erFixFolder
            // 
            this.mniMede8erFixFolder.Name = "mniMede8erFixFolder";
            this.mniMede8erFixFolder.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mniMede8erFixFolder.Size = new System.Drawing.Size(390, 32);
            this.mniMede8erFixFolder.Text = "Fix folder name";
            this.mniMede8erFixFolder.Click += new System.EventHandler(this.mniMede8erFixFolder_Click);
            // 
            // STB
            // 
            this.STB.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STB.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.STB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.STB.Location = new System.Drawing.Point(0, 728);
            this.STB.Name = "STB";
            this.STB.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.STB.Size = new System.Drawing.Size(968, 22);
            this.STB.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(948, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SPLIT
            // 
            this.SPLIT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPLIT.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SPLIT.Location = new System.Drawing.Point(0, 36);
            this.SPLIT.Margin = new System.Windows.Forms.Padding(4);
            this.SPLIT.Name = "SPLIT";
            // 
            // SPLIT.Panel1
            // 
            this.SPLIT.Panel1.Controls.Add(this.tvwFolder);
            // 
            // SPLIT.Panel2
            // 
            this.SPLIT.Panel2.BackColor = System.Drawing.Color.Black;
            this.SPLIT.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SPLIT.Panel2.Controls.Add(this.txtMovieScore);
            this.SPLIT.Panel2.Controls.Add(this.txtMovieDescription);
            this.SPLIT.Panel2.Controls.Add(this.picBackdrop);
            this.SPLIT.Panel2.Controls.Add(this.PIC);
            this.SPLIT.Panel2.Controls.Add(this.TOOLS);
            this.SPLIT.Panel2.Controls.Add(this.lvwFiles);
            this.SPLIT.Panel2.Resize += new System.EventHandler(this.SPLIT_Panel2_Resize);
            this.SPLIT.Size = new System.Drawing.Size(968, 692);
            this.SPLIT.SplitterDistance = 200;
            this.SPLIT.SplitterWidth = 5;
            this.SPLIT.TabIndex = 2;
            this.SPLIT.TabStop = false;
            // 
            // tvwFolder
            // 
            this.tvwFolder.BackColor = System.Drawing.Color.AliceBlue;
            this.tvwFolder.ContextMenuStrip = this.CTX;
            this.tvwFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwFolder.HideSelection = false;
            this.tvwFolder.ImageIndex = 0;
            this.tvwFolder.ImageList = this.IMG;
            this.tvwFolder.Location = new System.Drawing.Point(0, 0);
            this.tvwFolder.Margin = new System.Windows.Forms.Padding(4);
            this.tvwFolder.Name = "tvwFolder";
            this.tvwFolder.SelectedImageIndex = 0;
            this.tvwFolder.Size = new System.Drawing.Size(200, 692);
            this.tvwFolder.TabIndex = 0;
            this.tvwFolder.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwFolder_BeforeExpand);
            this.tvwFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwFolder_AfterSelect);
            // 
            // CTX
            // 
            this.CTX.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CTX.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxExplore});
            this.CTX.Name = "CTX";
            this.CTX.Size = new System.Drawing.Size(182, 34);
            // 
            // ctxExplore
            // 
            this.ctxExplore.Name = "ctxExplore";
            this.ctxExplore.Size = new System.Drawing.Size(181, 30);
            this.ctxExplore.Text = "Explore here";
            this.ctxExplore.Click += new System.EventHandler(this.ctxExplore_Click);
            // 
            // IMG
            // 
            this.IMG.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IMG.ImageStream")));
            this.IMG.TransparentColor = System.Drawing.Color.White;
            this.IMG.Images.SetKeyName(0, "Folder");
            this.IMG.Images.SetKeyName(1, "Folder2");
            this.IMG.Images.SetKeyName(2, "Movie");
            this.IMG.Images.SetKeyName(3, "Info");
            this.IMG.Images.SetKeyName(4, "eyes");
            this.IMG.Images.SetKeyName(5, "watched");
            this.IMG.Images.SetKeyName(6, "poster");
            this.IMG.Images.SetKeyName(7, "Xml");
            this.IMG.Images.SetKeyName(8, "SplitMovie");
            // 
            // txtMovieScore
            // 
            this.txtMovieScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMovieScore.BackColor = System.Drawing.Color.Black;
            this.txtMovieScore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMovieScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMovieScore.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txtMovieScore.Location = new System.Drawing.Point(348, 627);
            this.txtMovieScore.Margin = new System.Windows.Forms.Padding(4);
            this.txtMovieScore.Name = "txtMovieScore";
            this.txtMovieScore.Size = new System.Drawing.Size(367, 23);
            this.txtMovieScore.TabIndex = 12;
            this.txtMovieScore.TabStop = false;
            // 
            // txtMovieDescription
            // 
            this.txtMovieDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMovieDescription.BackColor = System.Drawing.Color.Black;
            this.txtMovieDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMovieDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMovieDescription.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.txtMovieDescription.Location = new System.Drawing.Point(348, 437);
            this.txtMovieDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtMovieDescription.Multiline = true;
            this.txtMovieDescription.Name = "txtMovieDescription";
            this.txtMovieDescription.Size = new System.Drawing.Size(367, 116);
            this.txtMovieDescription.TabIndex = 11;
            this.txtMovieDescription.TabStop = false;
            // 
            // picBackdrop
            // 
            this.picBackdrop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picBackdrop.Location = new System.Drawing.Point(348, 247);
            this.picBackdrop.Margin = new System.Windows.Forms.Padding(4);
            this.picBackdrop.Name = "picBackdrop";
            this.picBackdrop.Size = new System.Drawing.Size(367, 182);
            this.picBackdrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackdrop.TabIndex = 10;
            this.picBackdrop.TabStop = false;
            // 
            // PIC
            // 
            this.PIC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PIC.Location = new System.Drawing.Point(0, 253);
            this.PIC.Margin = new System.Windows.Forms.Padding(4);
            this.PIC.Name = "PIC";
            this.PIC.Size = new System.Drawing.Size(313, 439);
            this.PIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PIC.TabIndex = 7;
            this.PIC.TabStop = false;
            this.PIC.Resize += new System.EventHandler(this.PIC_Resize);
            // 
            // TOOLS
            // 
            this.TOOLS.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.TOOLS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSplit,
            this.btnMakePoster,
            this.txtSearch,
            this.btnSplitSearch,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.TOOLS.Location = new System.Drawing.Point(0, 0);
            this.TOOLS.Name = "TOOLS";
            this.TOOLS.Size = new System.Drawing.Size(763, 31);
            this.TOOLS.TabIndex = 4;
            this.TOOLS.Text = "toolStrip1";
            // 
            // btnSplit
            // 
            this.btnSplit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSplit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitAllFiles,
            this.splitMoviesOnly});
            this.btnSplit.Image = ((System.Drawing.Image)(resources.GetObject("btnSplit.Image")));
            this.btnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(45, 28);
            // 
            // splitAllFiles
            // 
            //this.splitAllFiles.Image = global::MovieCollection.Properties.Resources.AllFiles;
            this.splitAllFiles.Name = "splitAllFiles";
            this.splitAllFiles.Size = new System.Drawing.Size(192, 30);
            this.splitAllFiles.Text = "All files";
            this.splitAllFiles.Click += new System.EventHandler(this.splitAllFiles_Click);
            // 
            // splitMoviesOnly
            // 
            //this.splitMoviesOnly.Image = global::MovieCollection.Properties.Resources.Video;
            this.splitMoviesOnly.Name = "splitMoviesOnly";
            this.splitMoviesOnly.Size = new System.Drawing.Size(192, 30);
            this.splitMoviesOnly.Text = "Movies only";
            this.splitMoviesOnly.Click += new System.EventHandler(this.splitMoviesOnly_Click);
            // 
            // btnMakePoster
            // 
            this.btnMakePoster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMakePoster.Enabled = false;
            //this.btnMakePoster.Image = global::MovieCollection.Properties.Resources.Poster;
            this.btnMakePoster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMakePoster.Name = "btnMakePoster";
            this.btnMakePoster.Size = new System.Drawing.Size(28, 28);
            this.btnMakePoster.ToolTipText = "Create a poster file";
            this.btnMakePoster.Click += new System.EventHandler(this.btnMakePoster_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 31);
            // 
            // btnSplitSearch
            // 
            this.btnSplitSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSplitSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchDoSearch,
            this.searchClearSearch});
            this.btnSplitSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSplitSearch.Image")));
            this.btnSplitSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplitSearch.Name = "btnSplitSearch";
            this.btnSplitSearch.Size = new System.Drawing.Size(45, 28);
            this.btnSplitSearch.ButtonClick += new System.EventHandler(this.btnSplitSearch_ButtonClick);
            // 
            // searchDoSearch
            // 
            //this.searchDoSearch.Image = global::MovieCollection.Properties.Resources.Filter;
            this.searchDoSearch.Name = "searchDoSearch";
            this.searchDoSearch.Size = new System.Drawing.Size(148, 30);
            this.searchDoSearch.Text = "Search";
            this.searchDoSearch.Click += new System.EventHandler(this.searchDoSearch_Click);
            // 
            // searchClearSearch
            // 
            //this.searchClearSearch.Image = global::MovieCollection.Properties.Resources.Clear;
            this.searchClearSearch.Name = "searchClearSearch";
            this.searchClearSearch.Size = new System.Drawing.Size(148, 30);
            this.searchClearSearch.Text = "Clear";
            this.searchClearSearch.Click += new System.EventHandler(this.searchClearSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // lvwFiles
            // 
            this.lvwFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFile,
            this.colSize,
            this.colPath});
            this.lvwFiles.FullRowSelect = true;
            this.lvwFiles.Location = new System.Drawing.Point(0, 22);
            this.lvwFiles.Margin = new System.Windows.Forms.Padding(4);
            this.lvwFiles.MultiSelect = false;
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(760, 232);
            this.lvwFiles.TabIndex = 0;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            this.lvwFiles.SelectedIndexChanged += new System.EventHandler(this.lvwFiles_SelectedIndexChanged);
            this.lvwFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwFiles_MouseDoubleClick);
            // 
            // colFile
            // 
            this.colFile.Text = "File";
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            // 
            // mnuClean
            // 
            this.mnuClean.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniCleanDeleteFolder});
            this.mnuClean.Name = "mnuClean";
            this.mnuClean.Size = new System.Drawing.Size(72, 32);
            this.mnuClean.Text = "Clean";
            // 
            // mniCleanDeleteFolder
            // 
            this.mniCleanDeleteFolder.Name = "mniCleanDeleteFolder";
            this.mniCleanDeleteFolder.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.mniCleanDeleteFolder.Size = new System.Drawing.Size(292, 32);
            this.mniCleanDeleteFolder.Text = "&Delete folder...";
            this.mniCleanDeleteFolder.Click += new System.EventHandler(this.mniCleanDeleteFolder_Click);
            // 
            // MovieBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 750);
            this.Controls.Add(this.SPLIT);
            this.Controls.Add(this.STB);
            this.Controls.Add(this.MNU);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.MainMenuStrip = this.MNU;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MovieBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MovieBrowser_FormClosing);
            this.Load += new System.EventHandler(this.MovieBrowser_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MovieBrowser_KeyUp);
            this.MNU.ResumeLayout(false);
            this.MNU.PerformLayout();
            this.STB.ResumeLayout(false);
            this.STB.PerformLayout();
            this.SPLIT.Panel1.ResumeLayout(false);
            this.SPLIT.Panel2.ResumeLayout(false);
            this.SPLIT.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SPLIT)).EndInit();
            this.SPLIT.ResumeLayout(false);
            this.CTX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackdrop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PIC)).EndInit();
            this.TOOLS.ResumeLayout(false);
            this.TOOLS.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MNU;
        private System.Windows.Forms.StatusStrip STB;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuData;
        private System.Windows.Forms.ToolStripMenuItem mnuBatch;
        private System.Windows.Forms.ToolStripMenuItem mnuMede8er;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.SplitContainer SPLIT;
        private System.Windows.Forms.TreeView tvwFolder;
        private System.Windows.Forms.ImageList IMG;
        private System.Windows.Forms.ContextMenuStrip CTX;
        private System.Windows.Forms.ToolStripMenuItem ctxExplore;
        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.ColumnHeader colFile;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ToolStripMenuItem mniFileExit;
        private System.Windows.Forms.ToolStripMenuItem mniViewFolder;
        private System.Windows.Forms.ToolStripMenuItem mniViewWithMovies;
        private System.Windows.Forms.ToolStripMenuItem mniViewResetFolders;
        private System.Windows.Forms.ToolStripMenuItem mniViewWithInfo;
        private System.Windows.Forms.ToolStripMenuItem mniViewWatched;
        private System.Windows.Forms.ToolStripMenuItem mniMovieDataSearch;
        private System.Windows.Forms.ToolStripMenuItem mniMovieDataDisplay;
        private System.Windows.Forms.ToolStripMenuItem mniMovieDataCreateNFO;
        private System.Windows.Forms.ToolStripMenuItem mniBatchSettings;
        private System.Windows.Forms.ToolStripMenuItem mniMede8erWatched;
        private System.Windows.Forms.ToolStrip TOOLS;
        private System.Windows.Forms.ToolStripSplitButton btnSplit;
        private System.Windows.Forms.ToolStripMenuItem splitAllFiles;
        private System.Windows.Forms.ToolStripMenuItem splitMoviesOnly;
        private System.Windows.Forms.PictureBox PIC;
        private System.Windows.Forms.PictureBox picBackdrop;
        private System.Windows.Forms.TextBox txtMovieDescription;
        private System.Windows.Forms.ToolStripButton btnMakePoster;
        private System.Windows.Forms.ToolStripMenuItem mniViewPosters;
        private System.Windows.Forms.ToolStripMenuItem mniMede8erCreatePoster;
        private System.Windows.Forms.ToolStripMenuItem mniViewReload;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripSplitButton btnSplitSearch;
        private System.Windows.Forms.ToolStripMenuItem searchDoSearch;
        private System.Windows.Forms.ToolStripMenuItem searchClearSearch;
        private System.Windows.Forms.ToolStripMenuItem mniMede8erFixFolder;
        private System.Windows.Forms.ToolStripMenuItem foldersWithXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldersWithSplitMoviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox txtMovieScore;
        private System.Windows.Forms.ToolStripMenuItem mnuClean;
        private System.Windows.Forms.ToolStripMenuItem mniCleanDeleteFolder;
    }
}


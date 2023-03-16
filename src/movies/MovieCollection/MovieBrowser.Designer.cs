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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieBrowser));
            MNU = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mniFileExit = new ToolStripMenuItem();
            mnuView = new ToolStripMenuItem();
            mniViewFolder = new ToolStripMenuItem();
            mniViewWithMovies = new ToolStripMenuItem();
            mniViewResetFolders = new ToolStripMenuItem();
            mniViewWithInfo = new ToolStripMenuItem();
            mniViewWatched = new ToolStripMenuItem();
            mniViewPosters = new ToolStripMenuItem();
            mniViewReload = new ToolStripMenuItem();
            foldersWithXMLToolStripMenuItem = new ToolStripMenuItem();
            foldersWithSplitMoviesToolStripMenuItem = new ToolStripMenuItem();
            mnuData = new ToolStripMenuItem();
            mniMovieDataSearch = new ToolStripMenuItem();
            mniMovieDataDisplay = new ToolStripMenuItem();
            mniMovieDataCreateNFO = new ToolStripMenuItem();
            mnuBatch = new ToolStripMenuItem();
            mniBatchSettings = new ToolStripMenuItem();
            mnuMede8er = new ToolStripMenuItem();
            mniMede8erWatched = new ToolStripMenuItem();
            mniMede8erCreatePoster = new ToolStripMenuItem();
            mnuClean = new ToolStripMenuItem();
            mniCleanDeleteFolder = new ToolStripMenuItem();
            STB = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            SPLIT = new SplitContainer();
            tvwFolder = new TreeView();
            CTX = new ContextMenuStrip(components);
            ctxExplore = new ToolStripMenuItem();
            IMG = new ImageList(components);
            txtMovieScore = new TextBox();
            txtMovieDescription = new TextBox();
            picBackdrop = new PictureBox();
            PIC = new PictureBox();
            TOOLS = new ToolStrip();
            btnSplit = new ToolStripSplitButton();
            splitAllFiles = new ToolStripMenuItem();
            splitMoviesOnly = new ToolStripMenuItem();
            btnMakePoster = new ToolStripButton();
            txtSearch = new ToolStripTextBox();
            btnSplitSearch = new ToolStripSplitButton();
            searchDoSearch = new ToolStripMenuItem();
            searchClearSearch = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            lvwFiles = new ListView();
            colFile = new ColumnHeader();
            colSize = new ColumnHeader();
            colPath = new ColumnHeader();
            MNU.SuspendLayout();
            STB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SPLIT).BeginInit();
            SPLIT.Panel1.SuspendLayout();
            SPLIT.Panel2.SuspendLayout();
            SPLIT.SuspendLayout();
            CTX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBackdrop).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PIC).BeginInit();
            TOOLS.SuspendLayout();
            SuspendLayout();
            // 
            // MNU
            // 
            MNU.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            MNU.ImageScalingSize = new Size(24, 24);
            MNU.Items.AddRange(new ToolStripItem[] { mnuFile, mnuView, mnuData, mnuBatch, mnuMede8er, mnuClean });
            MNU.Location = new Point(0, 0);
            MNU.Name = "MNU";
            MNU.Padding = new Padding(8, 2, 0, 2);
            MNU.Size = new Size(968, 25);
            MNU.TabIndex = 0;
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mniFileExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(39, 21);
            mnuFile.Text = "&File";
            // 
            // mniFileExit
            // 
            mniFileExit.Name = "mniFileExit";
            mniFileExit.Size = new Size(96, 22);
            mniFileExit.Text = "E&xit";
            mniFileExit.Click += mniFileExit_Click;
            // 
            // mnuView
            // 
            mnuView.DropDownItems.AddRange(new ToolStripItem[] { mniViewFolder, mniViewWithMovies, mniViewResetFolders, mniViewWithInfo, mniViewWatched, mniViewPosters, mniViewReload, foldersWithXMLToolStripMenuItem, foldersWithSplitMoviesToolStripMenuItem });
            mnuView.Name = "mnuView";
            mnuView.Size = new Size(47, 21);
            mnuView.Text = "View";
            // 
            // mniViewFolder
            // 
            mniViewFolder.Name = "mniViewFolder";
            mniViewFolder.Size = new Size(277, 22);
            mniViewFolder.Text = "Select folder...";
            mniViewFolder.Click += mniViewFolder_Click;
            // 
            // mniViewWithMovies
            // 
            mniViewWithMovies.Name = "mniViewWithMovies";
            mniViewWithMovies.ShortcutKeys = Keys.Control | Keys.Shift | Keys.M;
            mniViewWithMovies.Size = new Size(277, 22);
            mniViewWithMovies.Text = "Folders with movies";
            mniViewWithMovies.Click += mniViewWithMovies_Click;
            // 
            // mniViewResetFolders
            // 
            mniViewResetFolders.Name = "mniViewResetFolders";
            mniViewResetFolders.ShortcutKeys = Keys.Control | Keys.Shift | Keys.R;
            mniViewResetFolders.Size = new Size(277, 22);
            mniViewResetFolders.Text = "Reset folders";
            mniViewResetFolders.Click += mniViewResetFolders_Click;
            // 
            // mniViewWithInfo
            // 
            mniViewWithInfo.Name = "mniViewWithInfo";
            mniViewWithInfo.ShortcutKeys = Keys.Control | Keys.Shift | Keys.I;
            mniViewWithInfo.Size = new Size(277, 22);
            mniViewWithInfo.Text = "Folders with info";
            mniViewWithInfo.Click += mniViewWithInfo_Click;
            // 
            // mniViewWatched
            // 
            mniViewWatched.Name = "mniViewWatched";
            mniViewWatched.ShortcutKeys = Keys.Control | Keys.Shift | Keys.W;
            mniViewWatched.Size = new Size(277, 22);
            mniViewWatched.Text = "Watched movies";
            mniViewWatched.Click += mniViewWatched_Click;
            // 
            // mniViewPosters
            // 
            mniViewPosters.Name = "mniViewPosters";
            mniViewPosters.ShortcutKeys = Keys.Control | Keys.Shift | Keys.P;
            mniViewPosters.Size = new Size(277, 22);
            mniViewPosters.Text = "Folders with a poster";
            mniViewPosters.Click += mniViewPosters_Click;
            // 
            // mniViewReload
            // 
            mniViewReload.Name = "mniViewReload";
            mniViewReload.ShortcutKeys = Keys.F5;
            mniViewReload.Size = new Size(277, 22);
            mniViewReload.Text = "Reload folders";
            mniViewReload.Click += mniViewReload_Click;
            // 
            // foldersWithXMLToolStripMenuItem
            // 
            foldersWithXMLToolStripMenuItem.Name = "foldersWithXMLToolStripMenuItem";
            foldersWithXMLToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.X;
            foldersWithXMLToolStripMenuItem.Size = new Size(277, 22);
            foldersWithXMLToolStripMenuItem.Text = "Folders with XML";
            foldersWithXMLToolStripMenuItem.Click += foldersWithXMLToolStripMenuItem_Click;
            // 
            // foldersWithSplitMoviesToolStripMenuItem
            // 
            foldersWithSplitMoviesToolStripMenuItem.Name = "foldersWithSplitMoviesToolStripMenuItem";
            foldersWithSplitMoviesToolStripMenuItem.Size = new Size(277, 22);
            foldersWithSplitMoviesToolStripMenuItem.Text = "Folders with split movies";
            // 
            // mnuData
            // 
            mnuData.DropDownItems.AddRange(new ToolStripItem[] { mniMovieDataSearch, mniMovieDataDisplay, mniMovieDataCreateNFO });
            mnuData.Name = "mnuData";
            mnuData.Size = new Size(47, 21);
            mnuData.Text = "&Data";
            // 
            // mniMovieDataSearch
            // 
            mniMovieDataSearch.Enabled = false;
            mniMovieDataSearch.Name = "mniMovieDataSearch";
            mniMovieDataSearch.ShortcutKeys = Keys.Control | Keys.S;
            mniMovieDataSearch.Size = new Size(193, 22);
            mniMovieDataSearch.Text = "&Search...";
            mniMovieDataSearch.Click += mniMovieDataSearch_Click;
            // 
            // mniMovieDataDisplay
            // 
            mniMovieDataDisplay.Enabled = false;
            mniMovieDataDisplay.Name = "mniMovieDataDisplay";
            mniMovieDataDisplay.ShortcutKeys = Keys.Control | Keys.I;
            mniMovieDataDisplay.Size = new Size(193, 22);
            mniMovieDataDisplay.Text = "Display info...";
            mniMovieDataDisplay.Click += mniMovieDataDisplay_Click;
            // 
            // mniMovieDataCreateNFO
            // 
            mniMovieDataCreateNFO.Name = "mniMovieDataCreateNFO";
            mniMovieDataCreateNFO.Size = new Size(193, 22);
            mniMovieDataCreateNFO.Text = "Create NFO";
            mniMovieDataCreateNFO.Click += mniMovieDataCreateNFO_Click;
            // 
            // mnuBatch
            // 
            mnuBatch.DropDownItems.AddRange(new ToolStripItem[] { mniBatchSettings });
            mnuBatch.Name = "mnuBatch";
            mnuBatch.Size = new Size(51, 21);
            mnuBatch.Text = "&Batch";
            // 
            // mniBatchSettings
            // 
            mniBatchSettings.Name = "mniBatchSettings";
            mniBatchSettings.Size = new Size(131, 22);
            mniBatchSettings.Text = "Settings...";
            mniBatchSettings.Click += mniBatchSettings_Click;
            // 
            // mnuMede8er
            // 
            mnuMede8er.DropDownItems.AddRange(new ToolStripItem[] { mniMede8erWatched, mniMede8erCreatePoster });
            mnuMede8er.Name = "mnuMede8er";
            mnuMede8er.Size = new Size(73, 21);
            mnuMede8er.Text = "Mede8er";
            // 
            // mniMede8erWatched
            // 
            mniMede8erWatched.Name = "mniMede8erWatched";
            mniMede8erWatched.ShortcutKeys = Keys.Control | Keys.W;
            mniMede8erWatched.Size = new Size(271, 22);
            mniMede8erWatched.Text = "Mark content as watched";
            mniMede8erWatched.Click += mniMede8erWatched_Click;
            // 
            // mniMede8erCreatePoster
            // 
            mniMede8erCreatePoster.Name = "mniMede8erCreatePoster";
            mniMede8erCreatePoster.ShortcutKeys = Keys.Control | Keys.P;
            mniMede8erCreatePoster.Size = new Size(271, 22);
            mniMede8erCreatePoster.Text = "Create poster";
            mniMede8erCreatePoster.Click += mniMede8erCreatePoster_Click;
            // 
            // mnuClean
            // 
            mnuClean.DropDownItems.AddRange(new ToolStripItem[] { mniCleanDeleteFolder });
            mnuClean.Name = "mnuClean";
            mnuClean.Size = new Size(52, 21);
            mnuClean.Text = "Clean";
            // 
            // mniCleanDeleteFolder
            // 
            mniCleanDeleteFolder.Name = "mniCleanDeleteFolder";
            mniCleanDeleteFolder.ShortcutKeys = Keys.Control | Keys.D;
            mniCleanDeleteFolder.Size = new Size(207, 22);
            mniCleanDeleteFolder.Text = "&Delete folder...";
            mniCleanDeleteFolder.Click += mniCleanDeleteFolder_Click;
            // 
            // STB
            // 
            STB.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            STB.ImageScalingSize = new Size(24, 24);
            STB.Items.AddRange(new ToolStripItem[] { lblStatus });
            STB.Location = new Point(0, 728);
            STB.Name = "STB";
            STB.Padding = new Padding(1, 0, 19, 0);
            STB.Size = new Size(968, 22);
            STB.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(948, 17);
            lblStatus.Spring = true;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SPLIT
            // 
            SPLIT.Dock = DockStyle.Fill;
            SPLIT.FixedPanel = FixedPanel.Panel1;
            SPLIT.Location = new Point(0, 25);
            SPLIT.Margin = new Padding(4);
            SPLIT.Name = "SPLIT";
            // 
            // SPLIT.Panel1
            // 
            SPLIT.Panel1.Controls.Add(tvwFolder);
            // 
            // SPLIT.Panel2
            // 
            SPLIT.Panel2.BackColor = Color.Black;
            SPLIT.Panel2.BackgroundImageLayout = ImageLayout.Zoom;
            SPLIT.Panel2.Controls.Add(txtMovieScore);
            SPLIT.Panel2.Controls.Add(txtMovieDescription);
            SPLIT.Panel2.Controls.Add(picBackdrop);
            SPLIT.Panel2.Controls.Add(PIC);
            SPLIT.Panel2.Controls.Add(TOOLS);
            SPLIT.Panel2.Controls.Add(lvwFiles);
            SPLIT.Panel2.Resize += SPLIT_Panel2_Resize;
            SPLIT.Size = new Size(968, 703);
            SPLIT.SplitterDistance = 200;
            SPLIT.SplitterWidth = 5;
            SPLIT.TabIndex = 2;
            SPLIT.TabStop = false;
            // 
            // tvwFolder
            // 
            tvwFolder.BackColor = Color.AliceBlue;
            tvwFolder.ContextMenuStrip = CTX;
            tvwFolder.Dock = DockStyle.Fill;
            tvwFolder.HideSelection = false;
            tvwFolder.ImageIndex = 0;
            tvwFolder.ImageList = IMG;
            tvwFolder.Location = new Point(0, 0);
            tvwFolder.Margin = new Padding(4);
            tvwFolder.Name = "tvwFolder";
            tvwFolder.SelectedImageIndex = 0;
            tvwFolder.Size = new Size(200, 703);
            tvwFolder.TabIndex = 0;
            tvwFolder.BeforeExpand += tvwFolder_BeforeExpand;
            tvwFolder.AfterSelect += tvwFolder_AfterSelect;
            // 
            // CTX
            // 
            CTX.ImageScalingSize = new Size(24, 24);
            CTX.Items.AddRange(new ToolStripItem[] { ctxExplore });
            CTX.Name = "CTX";
            CTX.Size = new Size(140, 26);
            // 
            // ctxExplore
            // 
            ctxExplore.Name = "ctxExplore";
            ctxExplore.Size = new Size(139, 22);
            ctxExplore.Text = "Explore here";
            ctxExplore.Click += ctxExplore_Click;
            // 
            // IMG
            // 
            IMG.ColorDepth = ColorDepth.Depth32Bit;
            IMG.ImageStream = (ImageListStreamer)resources.GetObject("IMG.ImageStream");
            IMG.TransparentColor = Color.White;
            IMG.Images.SetKeyName(0, "Folder");
            IMG.Images.SetKeyName(1, "Folder2");
            IMG.Images.SetKeyName(2, "Movie");
            IMG.Images.SetKeyName(3, "Info");
            IMG.Images.SetKeyName(4, "eyes");
            IMG.Images.SetKeyName(5, "watched");
            IMG.Images.SetKeyName(6, "poster");
            IMG.Images.SetKeyName(7, "Xml");
            IMG.Images.SetKeyName(8, "SplitMovie");
            // 
            // txtMovieScore
            // 
            txtMovieScore.Anchor = AnchorStyles.None;
            txtMovieScore.BackColor = Color.Black;
            txtMovieScore.BorderStyle = BorderStyle.None;
            txtMovieScore.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtMovieScore.ForeColor = Color.CornflowerBlue;
            txtMovieScore.Location = new Point(344, 632);
            txtMovieScore.Margin = new Padding(4);
            txtMovieScore.Name = "txtMovieScore";
            txtMovieScore.Size = new Size(367, 15);
            txtMovieScore.TabIndex = 12;
            txtMovieScore.TabStop = false;
            // 
            // txtMovieDescription
            // 
            txtMovieDescription.Anchor = AnchorStyles.None;
            txtMovieDescription.BackColor = Color.Black;
            txtMovieDescription.BorderStyle = BorderStyle.None;
            txtMovieDescription.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtMovieDescription.ForeColor = Color.CornflowerBlue;
            txtMovieDescription.Location = new Point(344, 442);
            txtMovieDescription.Margin = new Padding(4);
            txtMovieDescription.Multiline = true;
            txtMovieDescription.Name = "txtMovieDescription";
            txtMovieDescription.Size = new Size(367, 116);
            txtMovieDescription.TabIndex = 11;
            txtMovieDescription.TabStop = false;
            // 
            // picBackdrop
            // 
            picBackdrop.Anchor = AnchorStyles.None;
            picBackdrop.Location = new Point(344, 252);
            picBackdrop.Margin = new Padding(4);
            picBackdrop.Name = "picBackdrop";
            picBackdrop.Size = new Size(367, 182);
            picBackdrop.SizeMode = PictureBoxSizeMode.StretchImage;
            picBackdrop.TabIndex = 10;
            picBackdrop.TabStop = false;
            // 
            // PIC
            // 
            PIC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            PIC.Location = new Point(0, 253);
            PIC.Margin = new Padding(4);
            PIC.Name = "PIC";
            PIC.Size = new Size(313, 450);
            PIC.SizeMode = PictureBoxSizeMode.StretchImage;
            PIC.TabIndex = 7;
            PIC.TabStop = false;
            PIC.Resize += PIC_Resize;
            // 
            // TOOLS
            // 
            TOOLS.ImageScalingSize = new Size(24, 24);
            TOOLS.Items.AddRange(new ToolStripItem[] { btnSplit, btnMakePoster, txtSearch, btnSplitSearch, toolStripSeparator1 });
            TOOLS.Location = new Point(0, 0);
            TOOLS.Name = "TOOLS";
            TOOLS.Size = new Size(763, 31);
            TOOLS.TabIndex = 4;
            TOOLS.Text = "toolStrip1";
            // 
            // btnSplit
            // 
            btnSplit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSplit.DropDownItems.AddRange(new ToolStripItem[] { splitAllFiles, splitMoviesOnly });
            btnSplit.Image = (Image)resources.GetObject("btnSplit.Image");
            btnSplit.ImageTransparentColor = Color.Magenta;
            btnSplit.Name = "btnSplit";
            btnSplit.Size = new Size(40, 28);
            // 
            // splitAllFiles
            // 
            splitAllFiles.Name = "splitAllFiles";
            splitAllFiles.Size = new Size(138, 22);
            splitAllFiles.Text = "All files";
            splitAllFiles.Click += splitAllFiles_Click;
            // 
            // splitMoviesOnly
            // 
            splitMoviesOnly.Name = "splitMoviesOnly";
            splitMoviesOnly.Size = new Size(138, 22);
            splitMoviesOnly.Text = "Movies only";
            splitMoviesOnly.Click += splitMoviesOnly_Click;
            // 
            // btnMakePoster
            // 
            btnMakePoster.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnMakePoster.Enabled = false;
            btnMakePoster.ImageTransparentColor = Color.Magenta;
            btnMakePoster.Name = "btnMakePoster";
            btnMakePoster.Size = new Size(23, 28);
            btnMakePoster.ToolTipText = "Create a poster file";
            btnMakePoster.Click += btnMakePoster_Click;
            // 
            // txtSearch
            // 
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(200, 31);
            // 
            // btnSplitSearch
            // 
            btnSplitSearch.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSplitSearch.DropDownItems.AddRange(new ToolStripItem[] { searchDoSearch, searchClearSearch });
            btnSplitSearch.Image = (Image)resources.GetObject("btnSplitSearch.Image");
            btnSplitSearch.ImageTransparentColor = Color.Magenta;
            btnSplitSearch.Name = "btnSplitSearch";
            btnSplitSearch.Size = new Size(40, 28);
            btnSplitSearch.ButtonClick += btnSplitSearch_ButtonClick;
            // 
            // searchDoSearch
            // 
            searchDoSearch.Name = "searchDoSearch";
            searchDoSearch.Size = new Size(109, 22);
            searchDoSearch.Text = "Search";
            searchDoSearch.Click += searchDoSearch_Click;
            // 
            // searchClearSearch
            // 
            searchClearSearch.Name = "searchClearSearch";
            searchClearSearch.Size = new Size(109, 22);
            searchClearSearch.Text = "Clear";
            searchClearSearch.Click += searchClearSearch_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 31);
            // 
            // lvwFiles
            // 
            lvwFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lvwFiles.Columns.AddRange(new ColumnHeader[] { colFile, colSize, colPath });
            lvwFiles.FullRowSelect = true;
            lvwFiles.Location = new Point(0, 17);
            lvwFiles.Margin = new Padding(4);
            lvwFiles.MultiSelect = false;
            lvwFiles.Name = "lvwFiles";
            lvwFiles.Size = new Size(756, 237);
            lvwFiles.TabIndex = 0;
            lvwFiles.UseCompatibleStateImageBehavior = false;
            lvwFiles.View = View.Details;
            lvwFiles.SelectedIndexChanged += lvwFiles_SelectedIndexChanged;
            lvwFiles.MouseDoubleClick += lvwFiles_MouseDoubleClick;
            // 
            // colFile
            // 
            colFile.Text = "File";
            // 
            // colSize
            // 
            colSize.Text = "Size";
            // 
            // colPath
            // 
            colPath.Text = "Path";
            // 
            // MovieBrowser
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 750);
            Controls.Add(SPLIT);
            Controls.Add(STB);
            Controls.Add(MNU);
            Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            KeyPreview = true;
            MainMenuStrip = MNU;
            Margin = new Padding(4);
            Name = "MovieBrowser";
            StartPosition = FormStartPosition.Manual;
            FormClosing += MovieBrowser_FormClosing;
            Load += MovieBrowser_Load;
            KeyUp += MovieBrowser_KeyUp;
            MNU.ResumeLayout(false);
            MNU.PerformLayout();
            STB.ResumeLayout(false);
            STB.PerformLayout();
            SPLIT.Panel1.ResumeLayout(false);
            SPLIT.Panel2.ResumeLayout(false);
            SPLIT.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SPLIT).EndInit();
            SPLIT.ResumeLayout(false);
            CTX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picBackdrop).EndInit();
            ((System.ComponentModel.ISupportInitialize)PIC).EndInit();
            TOOLS.ResumeLayout(false);
            TOOLS.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem foldersWithXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldersWithSplitMoviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox txtMovieScore;
        private System.Windows.Forms.ToolStripMenuItem mnuClean;
        private System.Windows.Forms.ToolStripMenuItem mniCleanDeleteFolder;
    }
}


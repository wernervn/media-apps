
namespace EpisodeScraper
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MNU = new System.Windows.Forms.MenuStrip();
            this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTVDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTvdbSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mniTvdbGetSeriesMetadata = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mniTvdbGetAllMetadata = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTvdbGetMetadata = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTvdbRenameEpisodes = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTvdbRenameEpisodesUI = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTvdbClearMetadata = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMede8er = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMede8erSetWatched = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMede8erSetFolderWatched = new System.Windows.Forms.ToolStripMenuItem();
            this.STB = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tvwFolder = new System.Windows.Forms.TreeView();
            this.CTX = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxExplore = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IMG = new System.Windows.Forms.ImageList(this.components);
            this.MNU.SuspendLayout();
            this.STB.SuspendLayout();
            this.CTX.SuspendLayout();
            this.SuspendLayout();
            //
            // MNU
            //
            this.MNU.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MNU.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MNU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFile,
            this.viewToolStripMenuItem,
            this.mniTVDB,
            this.mniMede8er});
            this.MNU.Location = new System.Drawing.Point(0, 0);
            this.MNU.Name = "MNU";
            this.MNU.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.MNU.Size = new System.Drawing.Size(1378, 31);
            this.MNU.TabIndex = 0;
            this.MNU.Text = "menuStrip1";
            //
            // mniFile
            //
            this.mniFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFileExit});
            this.mniFile.Name = "mniFile";
            this.mniFile.Size = new System.Drawing.Size(54, 29);
            this.mniFile.Text = "&File";
            //
            // mniFileExit
            //
            this.mniFileExit.Name = "mniFileExit";
            this.mniFileExit.Size = new System.Drawing.Size(141, 34);
            this.mniFileExit.Text = "E&xit";
            this.mniFileExit.Click += new System.EventHandler(this.MniFileExit_Click);
            //
            // viewToolStripMenuItem
            //
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectFolderToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.viewToolStripMenuItem.Text = "&View";
            //
            // selectFolderToolStripMenuItem
            //
            this.selectFolderToolStripMenuItem.Name = "selectFolderToolStripMenuItem";
            this.selectFolderToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.selectFolderToolStripMenuItem.Text = "&Select folder...";
            this.selectFolderToolStripMenuItem.Click += new System.EventHandler(this.SelectFolderToolStripMenuItem_Click);
            //
            // refreshToolStripMenuItem
            //
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(224, 34);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.MniViewRefresh_Click);
            //
            // mniTVDB
            //
            this.mniTVDB.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniTvdbSearch,
            this.toolStripMenuItem1,
            this.mniTvdbGetSeriesMetadata,
            this.toolStripMenuItem2,
            this.mniTvdbGetAllMetadata,
            this.mniTvdbGetMetadata,
            this.mniTvdbRenameEpisodes,
            this.mniTvdbRenameEpisodesUI,
            this.mniTvdbClearMetadata});
            this.mniTVDB.Name = "mniTVDB";
            this.mniTVDB.Size = new System.Drawing.Size(71, 29);
            this.mniTVDB.Text = "&TVDB";
            //
            // mniTvdbSearch
            //
            this.mniTvdbSearch.Name = "mniTvdbSearch";
            this.mniTvdbSearch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mniTvdbSearch.Size = new System.Drawing.Size(379, 34);
            this.mniTvdbSearch.Text = "&Search...";
            this.mniTvdbSearch.Click += new System.EventHandler(this.MniTvdbSearch_Click);
            //
            // toolStripMenuItem1
            //
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(376, 6);
            //
            // mniTvdbGetSeriesMetadata
            //
            this.mniTvdbGetSeriesMetadata.Name = "mniTvdbGetSeriesMetadata";
            this.mniTvdbGetSeriesMetadata.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.S)));
            this.mniTvdbGetSeriesMetadata.Size = new System.Drawing.Size(379, 34);
            this.mniTvdbGetSeriesMetadata.Text = "Get series metadata";
            this.mniTvdbGetSeriesMetadata.Click += new System.EventHandler(this.MniTvdbGetSeriesMetadata_Click);
            //
            // toolStripMenuItem2
            //
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(376, 6);
            //
            // mniTvdbGetAllMetadata
            //
            this.mniTvdbGetAllMetadata.Name = "mniTvdbGetAllMetadata";
            this.mniTvdbGetAllMetadata.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mniTvdbGetAllMetadata.Size = new System.Drawing.Size(379, 34);
            this.mniTvdbGetAllMetadata.Text = "Get &all seasons metadata";
            this.mniTvdbGetAllMetadata.Click += new System.EventHandler(this.MniTvdbGetAllMetadata_Click);
            //
            // mniTvdbGetMetadata
            //
            this.mniTvdbGetMetadata.Name = "mniTvdbGetMetadata";
            this.mniTvdbGetMetadata.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.mniTvdbGetMetadata.Size = new System.Drawing.Size(379, 34);
            this.mniTvdbGetMetadata.Text = "Get &season metadata";
            this.mniTvdbGetMetadata.Click += new System.EventHandler(this.MniTvdbGetMetadata_Click);
            //
            // mniTvdbRenameEpisodes
            //
            this.mniTvdbRenameEpisodes.Name = "mniTvdbRenameEpisodes";
            this.mniTvdbRenameEpisodes.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mniTvdbRenameEpisodes.Size = new System.Drawing.Size(379, 34);
            this.mniTvdbRenameEpisodes.Text = "Rename episodes";
            this.mniTvdbRenameEpisodes.Click += new System.EventHandler(this.MniTvdbRenameEpisodes_Click);
            //
            // mniTvdbRenameEpisodesUI
            //
            this.mniTvdbRenameEpisodesUI.Name = "mniTvdbRenameEpisodesUI";
            this.mniTvdbRenameEpisodesUI.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.mniTvdbRenameEpisodesUI.Size = new System.Drawing.Size(379, 34);
            this.mniTvdbRenameEpisodesUI.Text = "Rename episode (UI)";
            this.mniTvdbRenameEpisodesUI.Click += new System.EventHandler(this.MniTvdbRenameEpisodesUI_Click);
            //
            // mniTvdbClearMetadata
            //
            this.mniTvdbClearMetadata.Name = "mniTvdbClearMetadata";
            this.mniTvdbClearMetadata.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mniTvdbClearMetadata.Size = new System.Drawing.Size(379, 34);
            this.mniTvdbClearMetadata.Text = "Clear Season metadata";
            this.mniTvdbClearMetadata.Click += new System.EventHandler(this.MniTvdbClearMetadata_Click);
            //
            // mniMede8er
            //
            this.mniMede8er.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniMede8erSetWatched,
            this.mniMede8erSetFolderWatched});
            this.mniMede8er.Name = "mniMede8er";
            this.mniMede8er.Size = new System.Drawing.Size(98, 29);
            this.mniMede8er.Text = "&Mede8er";
            //
            // mniMede8erSetWatched
            //
            this.mniMede8erSetWatched.Name = "mniMede8erSetWatched";
            this.mniMede8erSetWatched.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mniMede8erSetWatched.Size = new System.Drawing.Size(378, 34);
            this.mniMede8erSetWatched.Text = "Set &watched";
            this.mniMede8erSetWatched.Click += new System.EventHandler(this.MniMede8erSetWatched_Click);
            //
            // mniMede8erSetFolderWatched
            //
            this.mniMede8erSetFolderWatched.Enabled = false;
            this.mniMede8erSetFolderWatched.Name = "mniMede8erSetFolderWatched";
            this.mniMede8erSetFolderWatched.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.W)));
            this.mniMede8erSetFolderWatched.Size = new System.Drawing.Size(378, 34);
            this.mniMede8erSetFolderWatched.Text = "Set folder watched";
            this.mniMede8erSetFolderWatched.Click += new System.EventHandler(this.MniMede8erSetFolderWatched_Click);
            //
            // STB
            //
            this.STB.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.STB.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.STB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.STB.Location = new System.Drawing.Point(0, 818);
            this.STB.Name = "STB";
            this.STB.Size = new System.Drawing.Size(1378, 22);
            this.STB.TabIndex = 1;
            //
            // lblStatus
            //
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(1363, 15);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // tvwFolder
            //
            this.tvwFolder.BackColor = System.Drawing.Color.Black;
            this.tvwFolder.ContextMenuStrip = this.CTX;
            this.tvwFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwFolder.ForeColor = System.Drawing.Color.White;
            this.tvwFolder.Location = new System.Drawing.Point(0, 31);
            this.tvwFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tvwFolder.Name = "tvwFolder";
            this.tvwFolder.Size = new System.Drawing.Size(504, 787);
            this.tvwFolder.TabIndex = 2;
            this.tvwFolder.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TvwFolder_BeforeExpand);
            this.tvwFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvwFolder_AfterSelect);
            //
            // CTX
            //
            this.CTX.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.CTX.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxExplore});
            this.CTX.Name = "CTX";
            this.CTX.Size = new System.Drawing.Size(182, 36);
            //
            // ctxExplore
            //
            this.ctxExplore.Name = "ctxExplore";
            this.ctxExplore.Size = new System.Drawing.Size(181, 32);
            this.ctxExplore.Text = "Explore here";
            this.ctxExplore.Click += new System.EventHandler(this.CtxExplore_Click);
            //
            // splitter1
            //
            this.splitter1.Location = new System.Drawing.Point(504, 31);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 787);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            //
            // lvwFiles
            //
            this.lvwFiles.BackColor = System.Drawing.Color.Black;
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPath,
            this.colSize,
            this.colModified});
            this.lvwFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwFiles.ForeColor = System.Drawing.Color.White;
            this.lvwFiles.HideSelection = false;
            this.lvwFiles.Location = new System.Drawing.Point(507, 31);
            this.lvwFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(871, 787);
            this.lvwFiles.TabIndex = 4;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            this.lvwFiles.SelectedIndexChanged += new System.EventHandler(this.lvwFiles_SelectedIndexChanged);
            //
            // colPath
            //
            this.colPath.Text = "Path";
            //
            // colSize
            //
            this.colSize.Text = "Size";
            //
            // colModified
            //
            this.colModified.Text = "Modified";
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
            this.IMG.Images.SetKeyName(5, "hasId");
            this.IMG.Images.SetKeyName(6, "poster");
            this.IMG.Images.SetKeyName(7, "Xml");
            this.IMG.Images.SetKeyName(8, "SplitMovie");
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 840);
            this.Controls.Add(this.lvwFiles);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tvwFolder);
            this.Controls.Add(this.STB);
            this.Controls.Add(this.MNU);
            this.MainMenuStrip = this.MNU;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "The TVDB episode scraper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MNU.ResumeLayout(false);
            this.MNU.PerformLayout();
            this.STB.ResumeLayout(false);
            this.STB.PerformLayout();
            this.CTX.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.MenuStrip MNU;
        private System.Windows.Forms.StatusStrip STB;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripMenuItem mniFile;
        private System.Windows.Forms.ToolStripMenuItem mniFileExit;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectFolderToolStripMenuItem;
        private System.Windows.Forms.TreeView tvwFolder;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.ImageList IMG;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ToolStripMenuItem mniTVDB;
        private System.Windows.Forms.ToolStripMenuItem mniTvdbGetMetadata;
        private System.Windows.Forms.ToolStripMenuItem mniTvdbSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mniTvdbGetSeriesMetadata;
        private System.Windows.Forms.ToolStripMenuItem mniTvdbGetAllMetadata;
        private System.Windows.Forms.ColumnHeader colModified;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mniMede8er;
        private System.Windows.Forms.ToolStripMenuItem mniMede8erSetWatched;
        private System.Windows.Forms.ToolStripMenuItem mniMede8erSetFolderWatched;
        private System.Windows.Forms.ContextMenuStrip CTX;
        private System.Windows.Forms.ToolStripMenuItem ctxExplore;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mniTvdbRenameEpisodes;
        private System.Windows.Forms.ToolStripMenuItem mniTvdbRenameEpisodesUI;
        private System.Windows.Forms.ToolStripMenuItem mniTvdbClearMetadata;
    }
}


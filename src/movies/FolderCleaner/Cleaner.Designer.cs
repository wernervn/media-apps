using System.Resources;

namespace FolderCleaner;

partial class Cleaner
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
        components = new System.ComponentModel.Container();
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(Cleaner));
        MNU = new MenuStrip();
        mnuFile = new ToolStripMenuItem();
        mniFileExit = new ToolStripMenuItem();
        mnuSettings = new ToolStripMenuItem();
        mniSettingsUpdate = new ToolStripMenuItem();
        mniSettingsFolder = new ToolStripMenuItem();
        mnuView = new ToolStripMenuItem();
        mniViewReload = new ToolStripMenuItem();
        STB = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        SPLIT = new SplitContainer();
        tvwFolder = new TreeView();
        CTX = new ContextMenuStrip(components);
        ctxExplore = new ToolStripMenuItem();
        IMG = new ImageList(components);
        splitFiles = new SplitContainer();
        lvwFilesRename = new ListView();
        colFile = new ColumnHeader();
        colPath = new ColumnHeader();
        colNewPath = new ColumnHeader();
        lvwDeleteFolders = new ListView();
        colFolders = new ColumnHeader();
        TLB = new ToolStrip();
        btnCleanFolder = new ToolStripButton();
        MNU.SuspendLayout();
        STB.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)SPLIT).BeginInit();
        SPLIT.Panel1.SuspendLayout();
        SPLIT.Panel2.SuspendLayout();
        SPLIT.SuspendLayout();
        CTX.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)splitFiles).BeginInit();
        splitFiles.Panel1.SuspendLayout();
        splitFiles.Panel2.SuspendLayout();
        splitFiles.SuspendLayout();
        TLB.SuspendLayout();
        SuspendLayout();
        // 
        // MNU
        // 
        MNU.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        MNU.ImageScalingSize = new Size(20, 20);
        MNU.Items.AddRange(new ToolStripItem[] { mnuFile, mnuSettings, mnuView });
        MNU.Location = new Point(0, 0);
        MNU.Name = "MNU";
        MNU.Padding = new Padding(8, 2, 0, 2);
        MNU.Size = new Size(993, 24);
        MNU.TabIndex = 0;
        MNU.Text = "menuStrip1";
        // 
        // mnuFile
        // 
        mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mniFileExit });
        mnuFile.Name = "mnuFile";
        mnuFile.Size = new Size(41, 20);
        mnuFile.Text = "&File";
        // 
        // mniFileExit
        // 
        mniFileExit.Name = "mniFileExit";
        mniFileExit.Size = new Size(95, 22);
        mniFileExit.Text = "E&xit";
        // 
        // mnuSettings
        // 
        mnuSettings.DropDownItems.AddRange(new ToolStripItem[] { mniSettingsUpdate, mniSettingsFolder });
        mnuSettings.Name = "mnuSettings";
        mnuSettings.Size = new Size(67, 20);
        mnuSettings.Text = "&Settings";
        // 
        // mniSettingsUpdate
        // 
        mniSettingsUpdate.Name = "mniSettingsUpdate";
        mniSettingsUpdate.Size = new Size(149, 22);
        mniSettingsUpdate.Text = "&Update";
        mniSettingsUpdate.Click += mniSettingsUpdate_Click;
        // 
        // mniSettingsFolder
        // 
        mniSettingsFolder.Name = "mniSettingsFolder";
        mniSettingsFolder.Size = new Size(149, 22);
        mniSettingsFolder.Text = "Select &folder";
        mniSettingsFolder.Click += mniSettingsFolder_Click;
        // 
        // mnuView
        // 
        mnuView.DropDownItems.AddRange(new ToolStripItem[] { mniViewReload });
        mnuView.Name = "mnuView";
        mnuView.Size = new Size(48, 20);
        mnuView.Text = "&View";
        // 
        // mniViewReload
        // 
        mniViewReload.Name = "mniViewReload";
        mniViewReload.ShortcutKeys = Keys.F5;
        mniViewReload.Size = new Size(141, 22);
        mniViewReload.Text = "&Reload";
        mniViewReload.Click += mniViewReload_Click;
        // 
        // STB
        // 
        STB.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        STB.ImageScalingSize = new Size(20, 20);
        STB.Items.AddRange(new ToolStripItem[] { lblStatus });
        STB.Location = new Point(0, 670);
        STB.Name = "STB";
        STB.Padding = new Padding(1, 0, 19, 0);
        STB.Size = new Size(993, 27);
        STB.TabIndex = 1;
        STB.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = false;
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(973, 22);
        lblStatus.Spring = true;
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // SPLIT
        // 
        SPLIT.Dock = DockStyle.Fill;
        SPLIT.FixedPanel = FixedPanel.Panel1;
        SPLIT.Location = new Point(0, 24);
        SPLIT.Margin = new Padding(4);
        SPLIT.Name = "SPLIT";
        // 
        // SPLIT.Panel1
        // 
        SPLIT.Panel1.Controls.Add(tvwFolder);
        // 
        // SPLIT.Panel2
        // 
        SPLIT.Panel2.Controls.Add(splitFiles);
        SPLIT.Panel2.Controls.Add(TLB);
        SPLIT.Size = new Size(993, 646);
        SPLIT.SplitterDistance = 319;
        SPLIT.SplitterWidth = 5;
        SPLIT.TabIndex = 2;
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
        tvwFolder.Margin = new Padding(5);
        tvwFolder.Name = "tvwFolder";
        tvwFolder.SelectedImageIndex = 0;
        tvwFolder.Size = new Size(319, 646);
        tvwFolder.TabIndex = 1;
        tvwFolder.BeforeExpand += tvwFolder_BeforeExpand;
        tvwFolder.AfterSelect += tvwFolder_AfterSelect;
        // 
        // CTX
        // 
        CTX.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        CTX.ImageScalingSize = new Size(20, 20);
        CTX.Items.AddRange(new ToolStripItem[] { ctxExplore });
        CTX.Name = "CTX";
        CTX.Size = new Size(151, 26);
        // 
        // ctxExplore
        // 
        ctxExplore.Name = "ctxExplore";
        ctxExplore.Size = new Size(150, 22);
        ctxExplore.Text = "Explore here";
        ctxExplore.Click += ctxExplore_Click;
        // 
        // IMG
        // 
        IMG.ColorDepth = ColorDepth.Depth8Bit;
        IMG.ImageStream = (ImageListStreamer)resources.GetObject("IMG.ImageStream");
        IMG.TransparentColor = Color.White;
        IMG.Images.SetKeyName(0, "Folder");
        IMG.Images.SetKeyName(1, "Folder2");
        IMG.Images.SetKeyName(2, "Movie");
        IMG.Images.SetKeyName(3, "Info");
        IMG.Images.SetKeyName(4, "Eyes");
        IMG.Images.SetKeyName(5, "Watched");
        IMG.Images.SetKeyName(6, "Poster");
        IMG.Images.SetKeyName(7, "AllFiles");
        // 
        // splitFiles
        // 
        splitFiles.Dock = DockStyle.Fill;
        splitFiles.FixedPanel = FixedPanel.Panel2;
        splitFiles.Location = new Point(0, 25);
        splitFiles.Margin = new Padding(4);
        splitFiles.Name = "splitFiles";
        splitFiles.Orientation = Orientation.Horizontal;
        // 
        // splitFiles.Panel1
        // 
        splitFiles.Panel1.Controls.Add(lvwFilesRename);
        // 
        // splitFiles.Panel2
        // 
        splitFiles.Panel2.Controls.Add(lvwDeleteFolders);
        splitFiles.Size = new Size(669, 621);
        splitFiles.SplitterDistance = 462;
        splitFiles.SplitterWidth = 5;
        splitFiles.TabIndex = 1;
        // 
        // lvwFilesRename
        // 
        lvwFilesRename.CheckBoxes = true;
        lvwFilesRename.Columns.AddRange(new ColumnHeader[] { colFile, colPath, colNewPath });
        lvwFilesRename.Dock = DockStyle.Fill;
        lvwFilesRename.FullRowSelect = true;
        lvwFilesRename.Location = new Point(0, 0);
        lvwFilesRename.Margin = new Padding(5);
        lvwFilesRename.MultiSelect = false;
        lvwFilesRename.Name = "lvwFilesRename";
        lvwFilesRename.Size = new Size(669, 462);
        lvwFilesRename.SmallImageList = IMG;
        lvwFilesRename.TabIndex = 2;
        lvwFilesRename.UseCompatibleStateImageBehavior = false;
        lvwFilesRename.View = View.Details;
        // 
        // colFile
        // 
        colFile.Text = "File";
        // 
        // colPath
        // 
        colPath.Text = "Path";
        // 
        // colNewPath
        // 
        colNewPath.Text = "New path";
        // 
        // lvwDeleteFolders
        // 
        lvwDeleteFolders.CheckBoxes = true;
        lvwDeleteFolders.Columns.AddRange(new ColumnHeader[] { colFolders });
        lvwDeleteFolders.Dock = DockStyle.Fill;
        lvwDeleteFolders.Location = new Point(0, 0);
        lvwDeleteFolders.Margin = new Padding(4);
        lvwDeleteFolders.Name = "lvwDeleteFolders";
        lvwDeleteFolders.Size = new Size(669, 154);
        lvwDeleteFolders.SmallImageList = IMG;
        lvwDeleteFolders.TabIndex = 1;
        lvwDeleteFolders.UseCompatibleStateImageBehavior = false;
        lvwDeleteFolders.View = View.Details;
        // 
        // colFolders
        // 
        colFolders.Text = "Folders and files to delete";
        colFolders.Width = 205;
        // 
        // TLB
        // 
        TLB.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        TLB.ImageScalingSize = new Size(20, 20);
        TLB.Items.AddRange(new ToolStripItem[] { btnCleanFolder });
        TLB.Location = new Point(0, 0);
        TLB.Name = "TLB";
        TLB.Size = new Size(669, 25);
        TLB.TabIndex = 0;
        // 
        // btnCleanFolder
        // 
        btnCleanFolder.DisplayStyle = ToolStripItemDisplayStyle.Image;
        btnCleanFolder.ImageTransparentColor = Color.Magenta;
        btnCleanFolder.Name = "btnCleanFolder";
        btnCleanFolder.Size = new Size(23, 22);
        btnCleanFolder.Text = "Clean Folder";
        btnCleanFolder.ToolTipText = "Show files";
        btnCleanFolder.Click += btnCleanFolder_Click;
        // 
        // Cleaner
        // 
        AutoScaleDimensions = new SizeF(8F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(993, 697);
        Controls.Add(SPLIT);
        Controls.Add(STB);
        Controls.Add(MNU);
        Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        KeyPreview = true;
        MainMenuStrip = MNU;
        Margin = new Padding(4);
        Name = "Cleaner";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Movie folder cleaner";
        FormClosing += frmMain_FormClosing;
        Load += frmMain_Load;
        KeyUp += frmMain_KeyUp;
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
        splitFiles.Panel1.ResumeLayout(false);
        splitFiles.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitFiles).EndInit();
        splitFiles.ResumeLayout(false);
        TLB.ResumeLayout(false);
        TLB.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.MenuStrip MNU;
    private System.Windows.Forms.StatusStrip STB;
    private System.Windows.Forms.SplitContainer SPLIT;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mniFileExit;
    private System.Windows.Forms.ToolStripMenuItem mnuSettings;
    private System.Windows.Forms.ToolStripMenuItem mniSettingsUpdate;
    private System.Windows.Forms.ToolStripMenuItem mniSettingsFolder;
    private System.Windows.Forms.TreeView tvwFolder;
    private System.Windows.Forms.ImageList IMG;
    private System.Windows.Forms.ToolStrip TLB;
    private System.Windows.Forms.ToolStripButton btnCleanFolder;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    private System.Windows.Forms.SplitContainer splitFiles;
    private System.Windows.Forms.ListView lvwFilesRename;
    private System.Windows.Forms.ColumnHeader colFile;
    private System.Windows.Forms.ColumnHeader colPath;
    private System.Windows.Forms.ColumnHeader colNewPath;
    private System.Windows.Forms.ListView lvwDeleteFolders;
    private System.Windows.Forms.ColumnHeader colFolders;
    private System.Windows.Forms.ContextMenuStrip CTX;
    private System.Windows.Forms.ToolStripMenuItem ctxExplore;
    private System.Windows.Forms.ToolStripMenuItem mnuView;
    private System.Windows.Forms.ToolStripMenuItem mniViewReload;
}

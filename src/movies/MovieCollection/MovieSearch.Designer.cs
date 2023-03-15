namespace MovieCollection;

partial class MovieSearch
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
        MNU = new MenuStrip();
        mnuFile = new ToolStripMenuItem();
        mniFileExit = new ToolStripMenuItem();
        mnuNavigate = new ToolStripMenuItem();
        mniNavigatePrevious = new ToolStripMenuItem();
        mniNavigateNext = new ToolStripMenuItem();
        STB = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();
        btnSearch = new Button();
        txtMovie = new TextBox();
        label1 = new Label();
        SPLIT = new SplitContainer();
        lvwMovies = new ListView();
        columnHeader1 = new ColumnHeader();
        columnHeader2 = new ColumnHeader();
        info = new Common.Winforms.MovieInfo();
        btnAccept = new Button();
        MNU.SuspendLayout();
        STB.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)SPLIT).BeginInit();
        SPLIT.Panel1.SuspendLayout();
        SPLIT.Panel2.SuspendLayout();
        SPLIT.SuspendLayout();
        SuspendLayout();
        // 
        // MNU
        // 
        MNU.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        MNU.ImageScalingSize = new Size(24, 24);
        MNU.Items.AddRange(new ToolStripItem[] { mnuFile, mnuNavigate });
        MNU.Location = new Point(0, 0);
        MNU.Name = "MNU";
        MNU.Padding = new Padding(7, 2, 0, 2);
        MNU.Size = new Size(1149, 36);
        MNU.TabIndex = 1;
        MNU.Text = "menuStrip1";
        // 
        // mnuFile
        // 
        mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mniFileExit });
        mnuFile.Name = "mnuFile";
        mnuFile.Size = new Size(58, 32);
        mnuFile.Text = "&File";
        // 
        // mniFileExit
        // 
        mniFileExit.Name = "mniFileExit";
        mniFileExit.Size = new Size(145, 36);
        mniFileExit.Text = "E&xit";
        // 
        // mnuNavigate
        // 
        mnuNavigate.DropDownItems.AddRange(new ToolStripItem[] { mniNavigatePrevious, mniNavigateNext });
        mnuNavigate.Name = "mnuNavigate";
        mnuNavigate.Size = new Size(107, 32);
        mnuNavigate.Text = "&Navigate";
        // 
        // mniNavigatePrevious
        // 
        mniNavigatePrevious.Name = "mniNavigatePrevious";
        mniNavigatePrevious.ShortcutKeys = Keys.Control | Keys.P;
        mniNavigatePrevious.Size = new Size(256, 36);
        mniNavigatePrevious.Text = "&Previous";
        // 
        // mniNavigateNext
        // 
        mniNavigateNext.Name = "mniNavigateNext";
        mniNavigateNext.ShortcutKeys = Keys.Control | Keys.N;
        mniNavigateNext.Size = new Size(256, 36);
        mniNavigateNext.Text = "&Next";
        // 
        // STB
        // 
        STB.ImageScalingSize = new Size(24, 24);
        STB.Items.AddRange(new ToolStripItem[] { lblStatus });
        STB.Location = new Point(0, 901);
        STB.Name = "STB";
        STB.Padding = new Padding(1, 0, 16, 0);
        STB.Size = new Size(1149, 22);
        STB.TabIndex = 2;
        STB.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(1132, 15);
        lblStatus.Spring = true;
        lblStatus.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnSearch
        // 
        btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSearch.Location = new Point(1065, 34);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(83, 20);
        btnSearch.TabIndex = 7;
        btnSearch.Text = "&Search";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // txtMovie
        // 
        txtMovie.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtMovie.Location = new Point(74, 34);
        txtMovie.Name = "txtMovie";
        txtMovie.Size = new Size(983, 27);
        txtMovie.TabIndex = 6;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(0, 34);
        label1.Name = "label1";
        label1.Size = new Size(101, 18);
        label1.TabIndex = 5;
        label1.Text = "Search text";
        // 
        // SPLIT
        // 
        SPLIT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        SPLIT.FixedPanel = FixedPanel.Panel1;
        SPLIT.Location = new Point(3, 57);
        SPLIT.Name = "SPLIT";
        // 
        // SPLIT.Panel1
        // 
        SPLIT.Panel1.Controls.Add(lvwMovies);
        // 
        // SPLIT.Panel2
        // 
        SPLIT.Panel2.Controls.Add(info);
        SPLIT.Size = new Size(1145, 817);
        SPLIT.SplitterDistance = 219;
        SPLIT.TabIndex = 8;
        // 
        // lvwMovies
        // 
        lvwMovies.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
        lvwMovies.Dock = DockStyle.Fill;
        lvwMovies.FullRowSelect = true;
        lvwMovies.Location = new Point(0, 0);
        lvwMovies.MultiSelect = false;
        lvwMovies.Name = "lvwMovies";
        lvwMovies.Size = new Size(219, 817);
        lvwMovies.TabIndex = 0;
        lvwMovies.UseCompatibleStateImageBehavior = false;
        lvwMovies.View = View.Details;
        lvwMovies.SelectedIndexChanged += lvwMovies_SelectedIndexChanged;
        // 
        // columnHeader1
        // 
        columnHeader1.Text = "Title";
        // 
        // columnHeader2
        // 
        columnHeader2.Text = "Year";
        // 
        // info
        // 
        info.AutoScroll = true;
        info.Dock = DockStyle.Fill;
        info.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        info.Location = new Point(0, 0);
        info.Margin = new Padding(4);
        info.MovieDetails = null;
        info.Name = "info";
        info.Size = new Size(922, 817);
        info.TabIndex = 0;
        info.ImageResized += info_ImageResized;
        // 
        // btnAccept
        // 
        btnAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        btnAccept.Enabled = false;
        btnAccept.Location = new Point(3, 880);
        btnAccept.Name = "btnAccept";
        btnAccept.Size = new Size(83, 20);
        btnAccept.TabIndex = 9;
        btnAccept.Text = "&Accept";
        btnAccept.UseVisualStyleBackColor = true;
        btnAccept.Click += btnAccept_Click;
        // 
        // MovieSearch
        // 
        AutoScaleDimensions = new SizeF(10F, 18F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        ClientSize = new Size(1149, 923);
        Controls.Add(btnAccept);
        Controls.Add(SPLIT);
        Controls.Add(btnSearch);
        Controls.Add(txtMovie);
        Controls.Add(label1);
        Controls.Add(STB);
        Controls.Add(MNU);
        Font = new Font("Verdana", 8F, FontStyle.Regular, GraphicsUnit.Point);
        KeyPreview = true;
        MaximizeBox = false;
        Name = "MovieSearch";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Movie Data";
        FormClosing += MovieData_FormClosing;
        Load += MovieData_Load;
        KeyDown += MovieData_KeyDown;
        MNU.ResumeLayout(false);
        MNU.PerformLayout();
        STB.ResumeLayout(false);
        STB.PerformLayout();
        SPLIT.Panel1.ResumeLayout(false);
        SPLIT.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)SPLIT).EndInit();
        SPLIT.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.MenuStrip MNU;
    private System.Windows.Forms.ToolStripMenuItem mnuFile;
    private System.Windows.Forms.ToolStripMenuItem mniFileExit;
    private System.Windows.Forms.ToolStripMenuItem mnuNavigate;
    private System.Windows.Forms.ToolStripMenuItem mniNavigatePrevious;
    private System.Windows.Forms.ToolStripMenuItem mniNavigateNext;
    private System.Windows.Forms.StatusStrip STB;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.TextBox txtMovie;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.SplitContainer SPLIT;
    private System.Windows.Forms.ListView lvwMovies;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.Button btnAccept;
    private MovieCollection.Common.Winforms.MovieInfo info;
}
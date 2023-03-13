namespace MovieCollection;

partial class MovieData
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

        this.MNU = new System.Windows.Forms.MenuStrip();
        this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
        this.mniFileExit = new System.Windows.Forms.ToolStripMenuItem();
        this.mnuNavigate = new System.Windows.Forms.ToolStripMenuItem();
        this.mniNavigatePrevious = new System.Windows.Forms.ToolStripMenuItem();
        this.mniNavigateNext = new System.Windows.Forms.ToolStripMenuItem();
        this.STB = new System.Windows.Forms.StatusStrip();
        this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
        this.btnSearch = new System.Windows.Forms.Button();
        this.txtMovie = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.SPLIT = new System.Windows.Forms.SplitContainer();
        this.lvwMovies = new System.Windows.Forms.ListView();
        this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.info = new MovieCollection.Common.Winforms.MovieInfo();
        this.btnAccept = new System.Windows.Forms.Button();
        this.MNU.SuspendLayout();
        this.STB.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.SPLIT)).BeginInit();
        this.SPLIT.Panel1.SuspendLayout();
        this.SPLIT.Panel2.SuspendLayout();
        this.SPLIT.SuspendLayout();
        this.SuspendLayout();
        // 
        // MNU
        // 
        this.MNU.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.MNU.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuNavigate});
        this.MNU.Location = new System.Drawing.Point(0, 0);
        this.MNU.Name = "MNU";
        this.MNU.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
        this.MNU.Size = new System.Drawing.Size(1029, 25);
        this.MNU.TabIndex = 1;
        this.MNU.Text = "menuStrip1";
        // 
        // mnuFile
        // 
        this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFileExit});
        this.mnuFile.Name = "mnuFile";
        this.mnuFile.Size = new System.Drawing.Size(39, 21);
        this.mnuFile.Text = "&File";
        // 
        // mniFileExit
        // 
        this.mniFileExit.Name = "mniFileExit";
        this.mniFileExit.Size = new System.Drawing.Size(96, 22);
        this.mniFileExit.Text = "E&xit";
        // 
        // mnuNavigate
        // 
        this.mnuNavigate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniNavigatePrevious,
            this.mniNavigateNext});
        this.mnuNavigate.Name = "mnuNavigate";
        this.mnuNavigate.Size = new System.Drawing.Size(72, 21);
        this.mnuNavigate.Text = "&Navigate";
        // 
        // mniNavigatePrevious
        // 
        this.mniNavigatePrevious.Name = "mniNavigatePrevious";
        this.mniNavigatePrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
        this.mniNavigatePrevious.Size = new System.Drawing.Size(169, 22);
        this.mniNavigatePrevious.Text = "&Previous";
        // 
        // mniNavigateNext
        // 
        this.mniNavigateNext.Name = "mniNavigateNext";
        this.mniNavigateNext.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
        this.mniNavigateNext.Size = new System.Drawing.Size(169, 22);
        this.mniNavigateNext.Text = "&Next";
        // 
        // STB
        // 
        this.STB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
        this.STB.Location = new System.Drawing.Point(0, 872);
        this.STB.Name = "STB";
        this.STB.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
        this.STB.Size = new System.Drawing.Size(1029, 22);
        this.STB.TabIndex = 2;
        this.STB.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(1009, 17);
        this.lblStatus.Spring = true;
        this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnSearch
        // 
        this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSearch.Location = new System.Drawing.Point(927, 48);
        this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
        this.btnSearch.Name = "btnSearch";
        this.btnSearch.Size = new System.Drawing.Size(100, 28);
        this.btnSearch.TabIndex = 7;
        this.btnSearch.Text = "&Search";
        this.btnSearch.UseVisualStyleBackColor = true;
        this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
        // 
        // txtMovie
        // 
        this.txtMovie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
              | System.Windows.Forms.AnchorStyles.Right)));
        this.txtMovie.Location = new System.Drawing.Point(89, 48);
        this.txtMovie.Margin = new System.Windows.Forms.Padding(4);
        this.txtMovie.Name = "txtMovie";
        this.txtMovie.Size = new System.Drawing.Size(829, 22);
        this.txtMovie.TabIndex = 6;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(0, 48);
        this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(74, 16);
        this.label1.TabIndex = 5;
        this.label1.Text = "Search text";
        // 
        // SPLIT
        // 
        this.SPLIT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
              | System.Windows.Forms.AnchorStyles.Left)
              | System.Windows.Forms.AnchorStyles.Right)));
        this.SPLIT.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SPLIT.Location = new System.Drawing.Point(4, 80);
        this.SPLIT.Margin = new System.Windows.Forms.Padding(4);
        this.SPLIT.Name = "SPLIT";
        // 
        // SPLIT.Panel1
        // 
        this.SPLIT.Panel1.Controls.Add(this.lvwMovies);
        // 
        // SPLIT.Panel2
        // 
        this.SPLIT.Panel2.Controls.Add(this.info);
        this.SPLIT.Size = new System.Drawing.Size(1023, 747);
        this.SPLIT.SplitterDistance = 219;
        this.SPLIT.SplitterWidth = 5;
        this.SPLIT.TabIndex = 8;
        // 
        // lvwMovies
        // 
        this.lvwMovies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
        this.lvwMovies.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvwMovies.FullRowSelect = true;
        this.lvwMovies.HideSelection = false;
        this.lvwMovies.Location = new System.Drawing.Point(0, 0);
        this.lvwMovies.Margin = new System.Windows.Forms.Padding(4);
        this.lvwMovies.MultiSelect = false;
        this.lvwMovies.Name = "lvwMovies";
        this.lvwMovies.Size = new System.Drawing.Size(219, 747);
        this.lvwMovies.TabIndex = 0;
        this.lvwMovies.UseCompatibleStateImageBehavior = false;
        this.lvwMovies.View = System.Windows.Forms.View.Details;
        this.lvwMovies.SelectedIndexChanged += new System.EventHandler(this.lvwMovies_SelectedIndexChanged);
        // 
        // columnHeader1
        // 
        this.columnHeader1.Text = "Title";
        // 
        // columnHeader2
        // 
        this.columnHeader2.Text = "Year";
        // 
        // info
        // 
        this.info.AutoScroll = true;
        this.info.Dock = System.Windows.Forms.DockStyle.Fill;
        this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.info.ImageInfo = null;
        this.info.Location = new System.Drawing.Point(0, 0);
        this.info.Margin = new System.Windows.Forms.Padding(4);
        this.info.MovieDetails = null;
        this.info.Name = "info";
        this.info.Size = new System.Drawing.Size(799, 747);
        this.info.TabIndex = 0;
        this.info.ImageResized += new System.EventHandler<MovieCollection.Common.ImageResizedEventArgs>(this.info_ImageResized);
        // 
        // btnAccept
        // 
        this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnAccept.Enabled = false;
        this.btnAccept.Location = new System.Drawing.Point(4, 835);
        this.btnAccept.Margin = new System.Windows.Forms.Padding(4);
        this.btnAccept.Name = "btnAccept";
        this.btnAccept.Size = new System.Drawing.Size(100, 28);
        this.btnAccept.TabIndex = 9;
        this.btnAccept.Text = "&Accept";
        this.btnAccept.UseVisualStyleBackColor = true;
        this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
        // 
        // MovieData
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoScroll = true;
        this.ClientSize = new System.Drawing.Size(1029, 894);
        this.Controls.Add(this.btnAccept);
        this.Controls.Add(this.SPLIT);
        this.Controls.Add(this.btnSearch);
        this.Controls.Add(this.txtMovie);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.STB);
        this.Controls.Add(this.MNU);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.KeyPreview = true;
        this.Margin = new System.Windows.Forms.Padding(4);
        this.MaximizeBox = false;
        this.Name = "MovieData";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Movie Data";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MovieData_FormClosing);
        this.Load += new System.EventHandler(this.MovieData_Load);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MovieData_KeyDown);
        this.MNU.ResumeLayout(false);
        this.MNU.PerformLayout();
        this.STB.ResumeLayout(false);
        this.STB.PerformLayout();
        this.SPLIT.Panel1.ResumeLayout(false);
        this.SPLIT.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.SPLIT)).EndInit();
        this.SPLIT.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
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
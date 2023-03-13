namespace MovieCollection;

partial class MovieDetailsView
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

        this.movieInfo = new MovieCollection.Common.Winforms.MovieInfo();
        this.SuspendLayout();
        // 
        // movieInfo
        // 
        this.movieInfo.AutoScroll = true;
        this.movieInfo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.movieInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.movieInfo.ImageInfo = null;
        this.movieInfo.Location = new System.Drawing.Point(0, 0);
        this.movieInfo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
        this.movieInfo.MovieDetails = null;
        this.movieInfo.Name = "movieInfo";
        this.movieInfo.Size = new System.Drawing.Size(782, 748);
        this.movieInfo.TabIndex = 0;
        // 
        // MovieDetailsView
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(782, 748);
        this.Controls.Add(this.movieInfo);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        this.Name = "MovieDetailsView";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "MovieDetailsView";
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MovieDetailsView_FormClosing);
        this.Load += new System.EventHandler(this.MovieDetailsView_Load);
        this.ResumeLayout(false);
    }

    #endregion

    private MovieCollection.Common.Winforms.MovieInfo movieInfo;
}
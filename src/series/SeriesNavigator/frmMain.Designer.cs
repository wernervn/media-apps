
namespace SeriesNavigator
{
    partial class frmMain
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.thumbsSeries = new SeriesNavigator.Thumbs.ThumbContainer();
            this.thumbsSeasons = new SeriesNavigator.Thumbs.ThumbContainer();
            this.thumbsEpisodes = new SeriesNavigator.Thumbs.ThumbContainer();
            this.SuspendLayout();
            //
            // lblHeader
            //
            this.lblHeader.BackColor = System.Drawing.Color.Black;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Candara", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1920, 39);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblDescription
            //
            this.lblDescription.BackColor = System.Drawing.Color.Black;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblDescription.Font = new System.Drawing.Font("Candara", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(0, 932);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(1920, 148);
            this.lblDescription.TabIndex = 1;
            //
            // thumbsSeries
            //
            this.thumbsSeries.AutoScroll = true;
            this.thumbsSeries.BackColor = System.Drawing.Color.Black;
            this.thumbsSeries.Location = new System.Drawing.Point(7, 39);
            this.thumbsSeries.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.thumbsSeries.Name = "thumbsSeries";
            this.thumbsSeries.Size = new System.Drawing.Size(200, 706);
            this.thumbsSeries.TabIndex = 3;
            this.thumbsSeries.ThumbClick += new System.EventHandler<SeriesNavigator.Thumbs.ThumbClickEventArgs>(this.ThumbSelected);
            this.thumbsSeries.ThumbEnter += new System.EventHandler<SeriesNavigator.Thumbs.ThumbEnterEventArgs>(this.thumbsSeries_ThumbEnter);
            //
            // thumbsSeasons
            //
            this.thumbsSeasons.AutoScroll = true;
            this.thumbsSeasons.BackColor = System.Drawing.Color.Black;
            this.thumbsSeasons.Location = new System.Drawing.Point(298, 56);
            this.thumbsSeasons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.thumbsSeasons.Name = "thumbsSeasons";
            this.thumbsSeasons.Size = new System.Drawing.Size(175, 662);
            this.thumbsSeasons.TabIndex = 4;
            this.thumbsSeasons.ThumbClick += new System.EventHandler<SeriesNavigator.Thumbs.ThumbClickEventArgs>(this.ThumbSelected);
            this.thumbsSeasons.ThumbEnter += new System.EventHandler<SeriesNavigator.Thumbs.ThumbEnterEventArgs>(this.thumbsSeasons_ThumbEnter);
            //
            // thumbsEpisodes
            //
            this.thumbsEpisodes.AutoScroll = true;
            this.thumbsEpisodes.BackColor = System.Drawing.Color.Black;
            this.thumbsEpisodes.Location = new System.Drawing.Point(568, 77);
            this.thumbsEpisodes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.thumbsEpisodes.Name = "thumbsEpisodes";
            this.thumbsEpisodes.Size = new System.Drawing.Size(153, 621);
            this.thumbsEpisodes.TabIndex = 5;
            this.thumbsEpisodes.ThumbClick += new System.EventHandler<SeriesNavigator.Thumbs.ThumbClickEventArgs>(this.ThumbSelected);
            this.thumbsEpisodes.ThumbEnter += new System.EventHandler<SeriesNavigator.Thumbs.ThumbEnterEventArgs>(this.thumbsEpisodes_ThumbEnter);
            //
            // frmMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.thumbsSeries);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.thumbsSeasons);
            this.Controls.Add(this.thumbsEpisodes);
            this.Font = new System.Drawing.Font("Candara", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblDescription;
        private Thumbs.ThumbContainer thumbsSeries;
        private Thumbs.ThumbContainer thumbsSeasons;
        private Thumbs.ThumbContainer thumbsEpisodes;
    }
}
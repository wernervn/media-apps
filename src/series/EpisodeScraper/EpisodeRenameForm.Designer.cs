
namespace EpisodeScraper
{
    partial class EpisodeRenameForm
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
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.chkGetSeasonData = new System.Windows.Forms.CheckBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.lvwEpisodes = new System.Windows.Forms.ListView();
            this.colEpisode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNew = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.chkGetSeasonData);
            this.grpActions.Controls.Add(this.btnRename);
            this.grpActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpActions.Location = new System.Drawing.Point(0, 915);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(2019, 100);
            this.grpActions.TabIndex = 0;
            this.grpActions.TabStop = false;
            // 
            // chkGetSeasonData
            // 
            this.chkGetSeasonData.AutoSize = true;
            this.chkGetSeasonData.Location = new System.Drawing.Point(267, 50);
            this.chkGetSeasonData.Name = "chkGetSeasonData";
            this.chkGetSeasonData.Size = new System.Drawing.Size(291, 24);
            this.chkGetSeasonData.TabIndex = 3;
            this.chkGetSeasonData.Text = "Get season data when dialog closes";
            this.chkGetSeasonData.UseVisualStyleBackColor = true;
            this.chkGetSeasonData.CheckedChanged += new System.EventHandler(this.chkGetSeasonData_CheckedChanged);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(12, 44);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(166, 31);
            this.btnRename.TabIndex = 2;
            this.btnRename.Text = "Rename episodes";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // lvwEpisodes
            // 
            this.lvwEpisodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEpisode,
            this.colAired,
            this.colFound,
            this.colNew});
            this.lvwEpisodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwEpisodes.FullRowSelect = true;
            this.lvwEpisodes.GridLines = true;
            this.lvwEpisodes.HideSelection = false;
            this.lvwEpisodes.Location = new System.Drawing.Point(0, 0);
            this.lvwEpisodes.Name = "lvwEpisodes";
            this.lvwEpisodes.Size = new System.Drawing.Size(2019, 915);
            this.lvwEpisodes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwEpisodes.TabIndex = 1;
            this.lvwEpisodes.UseCompatibleStateImageBehavior = false;
            this.lvwEpisodes.View = System.Windows.Forms.View.Details;
            // 
            // colEpisode
            // 
            this.colEpisode.Text = "Episode";
            this.colEpisode.Width = 480;
            // 
            // colAired
            // 
            this.colAired.Text = "First aired";
            this.colAired.Width = 80;
            // 
            // colFound
            // 
            this.colFound.Text = "Found";
            this.colFound.Width = 480;
            // 
            // colNew
            // 
            this.colNew.Text = "New";
            this.colNew.Width = 480;
            // 
            // EpisodeRenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2019, 1015);
            this.Controls.Add(this.lvwEpisodes);
            this.Controls.Add(this.grpActions);
            this.Name = "EpisodeRenameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EpisodeRenameForm";
            this.grpActions.ResumeLayout(false);
            this.grpActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.ListView lvwEpisodes;
        private System.Windows.Forms.ColumnHeader colFound;
        private System.Windows.Forms.ColumnHeader colEpisode;
        private System.Windows.Forms.ColumnHeader colNew;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.CheckBox chkGetSeasonData;
        private System.Windows.Forms.ColumnHeader colAired;
    }
}
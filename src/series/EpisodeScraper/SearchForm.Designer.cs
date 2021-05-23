namespace EpisodeScraper
{
    partial class SearchForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwResult = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.TAB = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblPlot = new System.Windows.Forms.Label();
            this.lblPosterIndex = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.picPoster = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblFanArtIndex = new System.Windows.Forms.Label();
            this.btnNextArt = new System.Windows.Forms.Button();
            this.btnPrevArt = new System.Windows.Forms.Button();
            this.picFanArt = new System.Windows.Forms.PictureBox();
            this.TAB.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFanArt)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Series name";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.Black;
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(118, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(782, 26);
            this.txtName.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(922, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(48, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Search);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Results:";
            // 
            // lvwResult
            // 
            this.lvwResult.BackColor = System.Drawing.Color.Black;
            this.lvwResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colId});
            this.lvwResult.ForeColor = System.Drawing.Color.White;
            this.lvwResult.FullRowSelect = true;
            this.lvwResult.HideSelection = false;
            this.lvwResult.Location = new System.Drawing.Point(16, 103);
            this.lvwResult.Name = "lvwResult";
            this.lvwResult.Size = new System.Drawing.Size(481, 382);
            this.lvwResult.TabIndex = 4;
            this.lvwResult.UseCompatibleStateImageBehavior = false;
            this.lvwResult.View = System.Windows.Forms.View.Details;
            this.lvwResult.SelectedIndexChanged += new System.EventHandler(this.LvwResult_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 305;
            // 
            // colId
            // 
            this.colId.Text = "Id";
            this.colId.Width = 160;
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(14, 503);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 32);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(896, 506);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // TAB
            // 
            this.TAB.Controls.Add(this.tabPage1);
            this.TAB.Controls.Add(this.tabPage2);
            this.TAB.Location = new System.Drawing.Point(506, 74);
            this.TAB.Name = "TAB";
            this.TAB.SelectedIndex = 0;
            this.TAB.Size = new System.Drawing.Size(465, 426);
            this.TAB.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblPlot);
            this.tabPage1.Controls.Add(this.lblPosterIndex);
            this.tabPage1.Controls.Add(this.btnNext);
            this.tabPage1.Controls.Add(this.btnPrev);
            this.tabPage1.Controls.Add(this.picPoster);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(457, 393);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cover";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblPlot
            // 
            this.lblPlot.Location = new System.Drawing.Point(226, 9);
            this.lblPlot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlot.Name = "lblPlot";
            this.lblPlot.Size = new System.Drawing.Size(219, 371);
            this.lblPlot.TabIndex = 19;
            // 
            // lblPosterIndex
            // 
            this.lblPosterIndex.Location = new System.Drawing.Point(42, 22);
            this.lblPosterIndex.Name = "lblPosterIndex";
            this.lblPosterIndex.Size = new System.Drawing.Size(140, 23);
            this.lblPosterIndex.TabIndex = 18;
            this.lblPosterIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(186, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 52);
            this.btnNext.TabIndex = 13;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(3, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(32, 52);
            this.btnPrev.TabIndex = 12;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // picPoster
            // 
            this.picPoster.Location = new System.Drawing.Point(3, 63);
            this.picPoster.Name = "picPoster";
            this.picPoster.Size = new System.Drawing.Size(214, 318);
            this.picPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPoster.TabIndex = 11;
            this.picPoster.TabStop = false;
            this.picPoster.DoubleClick += new System.EventHandler(this.picPoster_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblFanArtIndex);
            this.tabPage2.Controls.Add(this.btnNextArt);
            this.tabPage2.Controls.Add(this.btnPrevArt);
            this.tabPage2.Controls.Add(this.picFanArt);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(457, 393);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fan art";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblFanArtIndex
            // 
            this.lblFanArtIndex.Location = new System.Drawing.Point(40, 20);
            this.lblFanArtIndex.Name = "lblFanArtIndex";
            this.lblFanArtIndex.Size = new System.Drawing.Size(140, 23);
            this.lblFanArtIndex.TabIndex = 20;
            this.lblFanArtIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextArt
            // 
            this.btnNextArt.Location = new System.Drawing.Point(186, 5);
            this.btnNextArt.Name = "btnNextArt";
            this.btnNextArt.Size = new System.Drawing.Size(32, 52);
            this.btnNextArt.TabIndex = 16;
            this.btnNextArt.Text = ">";
            this.btnNextArt.UseVisualStyleBackColor = true;
            this.btnNextArt.Click += new System.EventHandler(this.btnNextArt_Click);
            // 
            // btnPrevArt
            // 
            this.btnPrevArt.Location = new System.Drawing.Point(3, 5);
            this.btnPrevArt.Name = "btnPrevArt";
            this.btnPrevArt.Size = new System.Drawing.Size(32, 52);
            this.btnPrevArt.TabIndex = 15;
            this.btnPrevArt.Text = "<";
            this.btnPrevArt.UseVisualStyleBackColor = true;
            this.btnPrevArt.Click += new System.EventHandler(this.btnPrevArt_Click);
            // 
            // picFanArt
            // 
            this.picFanArt.Location = new System.Drawing.Point(3, 83);
            this.picFanArt.Name = "picFanArt";
            this.picFanArt.Size = new System.Drawing.Size(450, 282);
            this.picFanArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFanArt.TabIndex = 14;
            this.picFanArt.TabStop = false;
            // 
            // SearchForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(978, 542);
            this.Controls.Add(this.TAB);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.lvwResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.TAB.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPoster)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFanArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwResult;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl TAB;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.PictureBox picPoster;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnNextArt;
        private System.Windows.Forms.Button btnPrevArt;
        private System.Windows.Forms.PictureBox picFanArt;
        private System.Windows.Forms.Label lblPosterIndex;
        private System.Windows.Forms.Label lblFanArtIndex;
        private System.Windows.Forms.Label lblPlot;
    }
}
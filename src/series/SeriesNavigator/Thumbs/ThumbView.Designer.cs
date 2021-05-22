namespace SeriesNavigator.Thumbs
{
    partial class ThumbView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TIPS = new System.Windows.Forms.ToolTip(this.components);
            this.LBL = new System.Windows.Forms.Label();
            this.PIC = new System.Windows.Forms.PictureBox();
            this.CTX = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxSetWatched = new System.Windows.Forms.ToolStripMenuItem();
            this.picViewed = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PIC)).BeginInit();
            this.CTX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picViewed)).BeginInit();
            this.SuspendLayout();
            // 
            // LBL
            // 
            this.LBL.AutoEllipsis = true;
            this.LBL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LBL.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL.ForeColor = System.Drawing.Color.White;
            this.LBL.Location = new System.Drawing.Point(0, 206);
            this.LBL.Name = "LBL";
            this.LBL.Size = new System.Drawing.Size(168, 29);
            this.LBL.TabIndex = 0;
            this.LBL.Text = "label1";
            this.LBL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PIC
            // 
            this.PIC.BackColor = System.Drawing.Color.Transparent;
            this.PIC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PIC.ContextMenuStrip = this.CTX;
            this.PIC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PIC.Location = new System.Drawing.Point(0, 0);
            this.PIC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PIC.Name = "PIC";
            this.PIC.Size = new System.Drawing.Size(168, 206);
            this.PIC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PIC.TabIndex = 2;
            this.PIC.TabStop = false;
            this.PIC.Click += new System.EventHandler(this.PIC_Click);
            this.PIC.DoubleClick += new System.EventHandler(this.PIC_DoubleClick);
            // 
            // CTX
            // 
            this.CTX.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CTX.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxSetWatched});
            this.CTX.Name = "CTX";
            this.CTX.Size = new System.Drawing.Size(193, 34);
            // 
            // ctxSetWatched
            // 
            this.ctxSetWatched.Name = "ctxSetWatched";
            this.ctxSetWatched.Size = new System.Drawing.Size(192, 30);
            this.ctxSetWatched.Text = "Set watched...";
            this.ctxSetWatched.Click += new System.EventHandler(this.ctxSetWatched_Click);
            // 
            // picViewed
            // 
            this.picViewed.BackColor = System.Drawing.Color.Transparent;
            this.picViewed.Location = new System.Drawing.Point(0, 0);
            this.picViewed.Name = "picViewed";
            this.picViewed.Size = new System.Drawing.Size(63, 43);
            this.picViewed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picViewed.TabIndex = 4;
            this.picViewed.TabStop = false;
            // 
            // ThumbView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.picViewed);
            this.Controls.Add(this.PIC);
            this.Controls.Add(this.LBL);
            this.Name = "ThumbView";
            this.Size = new System.Drawing.Size(168, 235);
            ((System.ComponentModel.ISupportInitialize)(this.PIC)).EndInit();
            this.CTX.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picViewed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip TIPS;
        private System.Windows.Forms.Label LBL;
        private System.Windows.Forms.PictureBox PIC;
        private System.Windows.Forms.PictureBox picViewed;
        private System.Windows.Forms.ContextMenuStrip CTX;
        private System.Windows.Forms.ToolStripMenuItem ctxSetWatched;
    }
}

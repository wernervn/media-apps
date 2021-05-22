
namespace SeriesNavigator
{
    partial class frmSettings
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
            this.txtSeriesFolder = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.btnForeColour = new System.Windows.Forms.Button();
            this.btnBackColour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Series folder";
            // 
            // txtSeriesFolder
            // 
            this.txtSeriesFolder.Location = new System.Drawing.Point(91, 11);
            this.txtSeriesFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtSeriesFolder.Name = "txtSeriesFolder";
            this.txtSeriesFolder.Size = new System.Drawing.Size(501, 20);
            this.txtSeriesFolder.TabIndex = 1;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(464, 116);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(2);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(56, 19);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(537, 116);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Selected lable";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblSelected.Location = new System.Drawing.Point(88, 44);
            this.lblSelected.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(81, 17);
            this.lblSelected.TabIndex = 5;
            this.lblSelected.Text = "Sample Text";
            // 
            // btnForeColour
            // 
            this.btnForeColour.Location = new System.Drawing.Point(191, 42);
            this.btnForeColour.Margin = new System.Windows.Forms.Padding(2);
            this.btnForeColour.Name = "btnForeColour";
            this.btnForeColour.Size = new System.Drawing.Size(85, 19);
            this.btnForeColour.TabIndex = 6;
            this.btnForeColour.Text = "Fore colour...";
            this.btnForeColour.UseVisualStyleBackColor = true;
            this.btnForeColour.Click += new System.EventHandler(this.btnForeColour_Click);
            // 
            // btnBackColour
            // 
            this.btnBackColour.Location = new System.Drawing.Point(291, 42);
            this.btnBackColour.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackColour.Name = "btnBackColour";
            this.btnBackColour.Size = new System.Drawing.Size(85, 19);
            this.btnBackColour.TabIndex = 7;
            this.btnBackColour.Text = "Back colour...";
            this.btnBackColour.UseVisualStyleBackColor = true;
            this.btnBackColour.Click += new System.EventHandler(this.btnBackColour_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 146);
            this.Controls.Add(this.btnBackColour);
            this.Controls.Add(this.btnForeColour);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtSeriesFolder);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeriesFolder;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Button btnForeColour;
        private System.Windows.Forms.Button btnBackColour;
    }
}
namespace FolderCleaner;

partial class SettingsForm
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
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.txtIgnoreFiles = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.btnUpdate = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.groupBox1.SuspendLayout();
        this.SuspendLayout();
        // 
        // groupBox1
        // 
        this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.groupBox1.Controls.Add(this.txtIgnoreFiles);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Location = new System.Drawing.Point(1, 0);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(603, 215);
        this.groupBox1.TabIndex = 0;
        this.groupBox1.TabStop = false;
        this.groupBox1.Text = "Settings";
        // 
        // txtIgnoreFiles
        // 
        this.txtIgnoreFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
        | System.Windows.Forms.AnchorStyles.Left)
        | System.Windows.Forms.AnchorStyles.Right)));
        this.txtIgnoreFiles.Location = new System.Drawing.Point(65, 20);
        this.txtIgnoreFiles.Multiline = true;
        this.txtIgnoreFiles.Name = "txtIgnoreFiles";
        this.txtIgnoreFiles.Size = new System.Drawing.Size(527, 178);
        this.txtIgnoreFiles.TabIndex = 1;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(7, 20);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(52, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "Ignore list";
        // 
        // btnUpdate
        // 
        this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnUpdate.Location = new System.Drawing.Point(1, 400);
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Size = new System.Drawing.Size(75, 23);
        this.btnUpdate.TabIndex = 1;
        this.btnUpdate.Text = "Update";
        this.btnUpdate.UseVisualStyleBackColor = true;
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(529, 400);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 2;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        // 
        // frmSettings
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(605, 437);
        this.ControlBox = false;
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnUpdate);
        this.Controls.Add(this.groupBox1);
        this.Name = "frmSettings";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Settings";
        this.Load += new System.EventHandler(this.frmSettings_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtIgnoreFiles;
}
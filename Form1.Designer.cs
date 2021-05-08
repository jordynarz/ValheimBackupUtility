
namespace ValheimBackup
{
    partial class ValheimBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValheimBackup));
            this.lblTitle = new System.Windows.Forms.Label();
            this.BtnOpenDest = new System.Windows.Forms.Button();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.BtnBackup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAppInfo = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.LblBrowse = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Papyrus", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(165, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(454, 64);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Valheim Backup Utility";
            // 
            // BtnOpenDest
            // 
            this.BtnOpenDest.Location = new System.Drawing.Point(346, 82);
            this.BtnOpenDest.Name = "BtnOpenDest";
            this.BtnOpenDest.Size = new System.Drawing.Size(126, 37);
            this.BtnOpenDest.TabIndex = 3;
            this.BtnOpenDest.Text = "Open Folder";
            this.BtnOpenDest.UseVisualStyleBackColor = true;
            this.BtnOpenDest.Click += new System.EventHandler(this.BtnOpenDest_Click);
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(478, 30);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(89, 37);
            this.BtnBrowse.TabIndex = 1;
            this.BtnBrowse.Text = "Browse...";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // BtnBackup
            // 
            this.BtnBackup.Location = new System.Drawing.Point(632, 309);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Size = new System.Drawing.Size(156, 89);
            this.BtnBackup.TabIndex = 2;
            this.BtnBackup.Text = "Backup";
            this.BtnBackup.UseVisualStyleBackColor = true;
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAppInfo);
            this.groupBox1.Controls.Add(this.BtnClear);
            this.groupBox1.Controls.Add(this.LblBrowse);
            this.groupBox1.Controls.Add(this.BtnBrowse);
            this.groupBox1.Controls.Add(this.BtnOpenDest);
            this.groupBox1.Location = new System.Drawing.Point(12, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 142);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destination";
            // 
            // btnAppInfo
            // 
            this.btnAppInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAppInfo.Location = new System.Drawing.Point(15, 82);
            this.btnAppInfo.Name = "btnAppInfo";
            this.btnAppInfo.Size = new System.Drawing.Size(108, 36);
            this.btnAppInfo.TabIndex = 5;
            this.btnAppInfo.Text = "App INFO";
            this.btnAppInfo.UseVisualStyleBackColor = true;
            this.btnAppInfo.Click += new System.EventHandler(this.btnAppInfo_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(478, 82);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(89, 37);
            this.BtnClear.TabIndex = 4;
            this.BtnClear.Text = "Clear";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // LblBrowse
            // 
            this.LblBrowse.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblBrowse.Location = new System.Drawing.Point(15, 30);
            this.LblBrowse.Name = "LblBrowse";
            this.LblBrowse.Size = new System.Drawing.Size(457, 37);
            this.LblBrowse.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(632, 404);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(156, 34);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Value = 4;
            this.progressBar1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(48, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(710, 202);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // ValheimBackup
            // 
            this.AcceptButton = this.BtnBackup;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnBackup);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ValheimBackup";
            this.Text = "Valheim Backup Utility";
            this.Load += new System.EventHandler(this.ValheimBackup_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button BtnOpenDest;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.Button BtnBackup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblBrowse;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAppInfo;
    }
}


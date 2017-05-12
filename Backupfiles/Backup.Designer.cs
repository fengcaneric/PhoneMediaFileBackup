namespace Backupfiles
{
    partial class Backup
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
            this.cmbDriverList = new System.Windows.Forms.ComboBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.prbLoadNCopy = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbAllFolders = new System.Windows.Forms.RadioButton();
            this.rdbMediaFolder = new System.Windows.Forms.RadioButton();
            this.btnCollect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDriverList
            // 
            this.cmbDriverList.BackColor = System.Drawing.Color.White;
            this.cmbDriverList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriverList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbDriverList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDriverList.FormattingEnabled = true;
            this.cmbDriverList.Location = new System.Drawing.Point(91, 22);
            this.cmbDriverList.Name = "cmbDriverList";
            this.cmbDriverList.Size = new System.Drawing.Size(477, 37);
            this.cmbDriverList.TabIndex = 0;
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCopy.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Location = new System.Drawing.Point(10, 76);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(0);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(560, 63);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "备份文件";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // prbLoadNCopy
            // 
            this.prbLoadNCopy.Location = new System.Drawing.Point(70, 76);
            this.prbLoadNCopy.Name = "prbLoadNCopy";
            this.prbLoadNCopy.Size = new System.Drawing.Size(500, 63);
            this.prbLoadNCopy.TabIndex = 3;
            this.prbLoadNCopy.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProgress.Location = new System.Drawing.Point(12, 98);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(41, 25);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "0%";
            this.lblProgress.Visible = false;
            // 
            // txtSavePath
            // 
            this.txtSavePath.BackColor = System.Drawing.Color.White;
            this.txtSavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSavePath.Location = new System.Drawing.Point(12, 316);
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.ReadOnly = true;
            this.txtSavePath.Size = new System.Drawing.Size(555, 30);
            this.txtSavePath.TabIndex = 5;
            this.txtSavePath.Click += new System.EventHandler(this.txtSavePath_Click);
            // 
            // fbdPath
            // 
            this.fbdPath.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.fbdPath.SelectedPath = "D:\\我的图片";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbAllFolders);
            this.groupBox1.Controls.Add(this.rdbMediaFolder);
            this.groupBox1.Location = new System.Drawing.Point(12, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(558, 106);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // rdbAllFolders
            // 
            this.rdbAllFolders.AutoSize = true;
            this.rdbAllFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbAllFolders.Location = new System.Drawing.Point(16, 68);
            this.rdbAllFolders.Name = "rdbAllFolders";
            this.rdbAllFolders.Size = new System.Drawing.Size(130, 29);
            this.rdbAllFolders.TabIndex = 0;
            this.rdbAllFolders.Text = "所有文件夹";
            this.rdbAllFolders.UseVisualStyleBackColor = true;
            // 
            // rdbMediaFolder
            // 
            this.rdbMediaFolder.AutoSize = true;
            this.rdbMediaFolder.Checked = true;
            this.rdbMediaFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdbMediaFolder.Location = new System.Drawing.Point(16, 21);
            this.rdbMediaFolder.Name = "rdbMediaFolder";
            this.rdbMediaFolder.Size = new System.Drawing.Size(170, 29);
            this.rdbMediaFolder.TabIndex = 0;
            this.rdbMediaFolder.TabStop = true;
            this.rdbMediaFolder.Text = "仅常用照片目录";
            this.rdbMediaFolder.UseVisualStyleBackColor = true;
            // 
            // btnCollect
            // 
            this.btnCollect.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCollect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollect.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCollect.Location = new System.Drawing.Point(10, 149);
            this.btnCollect.Margin = new System.Windows.Forms.Padding(0);
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(27, 32);
            this.btnCollect.TabIndex = 7;
            this.btnCollect.Text = "︾";
            this.btnCollect.UseVisualStyleBackColor = true;
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Image = global::Backupfiles.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(10, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(43, 37);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(581, 191);
            this.Controls.Add(this.btnCollect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbDriverList);
            this.Controls.Add(this.prbLoadNCopy);
            this.Controls.Add(this.lblProgress);
            this.MaximizeBox = false;
            this.Name = "Backup";
            this.ShowIcon = false;
            this.Text = "备份文件";
            this.Load += new System.EventHandler(this.Backup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDriverList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.ProgressBar prbLoadNCopy;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.FolderBrowserDialog fbdPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbAllFolders;
        private System.Windows.Forms.RadioButton rdbMediaFolder;
        private System.Windows.Forms.Button btnCollect;
    }
}


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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.prbLoadNCopy = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.fbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // cmbDriverList
            // 
            this.cmbDriverList.BackColor = System.Drawing.Color.White;
            this.cmbDriverList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriverList.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDriverList.FormattingEnabled = true;
            this.cmbDriverList.Location = new System.Drawing.Point(119, 22);
            this.cmbDriverList.Name = "cmbDriverList";
            this.cmbDriverList.Size = new System.Drawing.Size(449, 37);
            this.cmbDriverList.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(10, 22);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 37);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新列表";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCopy.Location = new System.Drawing.Point(10, 120);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(558, 63);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "备份文件";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // prbLoadNCopy
            // 
            this.prbLoadNCopy.Location = new System.Drawing.Point(10, 120);
            this.prbLoadNCopy.Name = "prbLoadNCopy";
            this.prbLoadNCopy.Size = new System.Drawing.Size(558, 63);
            this.prbLoadNCopy.TabIndex = 3;
            this.prbLoadNCopy.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProgress.Location = new System.Drawing.Point(12, 186);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(30, 25);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "%";
            this.lblProgress.Visible = false;
            // 
            // txtSavePath
            // 
            this.txtSavePath.BackColor = System.Drawing.Color.White;
            this.txtSavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSavePath.Location = new System.Drawing.Point(10, 75);
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
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(581, 215);
            this.Controls.Add(this.txtSavePath);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbDriverList);
            this.Controls.Add(this.prbLoadNCopy);
            this.MaximizeBox = false;
            this.Name = "Backup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "备份文件";
            this.Load += new System.EventHandler(this.Backup_Load);
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
    }
}


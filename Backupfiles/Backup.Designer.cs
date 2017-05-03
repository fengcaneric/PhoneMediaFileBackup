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
            this.SuspendLayout();
            // 
            // cmbDriverList
            // 
            this.cmbDriverList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDriverList.FormattingEnabled = true;
            this.cmbDriverList.Location = new System.Drawing.Point(91, 43);
            this.cmbDriverList.Name = "cmbDriverList";
            this.cmbDriverList.Size = new System.Drawing.Size(273, 21);
            this.cmbDriverList.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(10, 43);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新列表";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(12, 88);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(352, 63);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "备份文件";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 187);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbDriverList);
            this.Name = "Backup";
            this.Text = "备份文件";
            this.Load += new System.EventHandler(this.Backup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDriverList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCopy;
    }
}


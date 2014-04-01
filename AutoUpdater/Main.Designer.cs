namespace AutoUpdater
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbOldVersion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNewVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnDrop = new System.Windows.Forms.Button();
            this.lbDownInfo = new System.Windows.Forms.Label();
            this.prog = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUpdate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::AutoUpdater.Properties.Resources.App;
            this.pictureBox1.Location = new System.Drawing.Point(12, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "版本号：";
            // 
            // lbOldVersion
            // 
            this.lbOldVersion.AutoSize = true;
            this.lbOldVersion.Location = new System.Drawing.Point(176, 24);
            this.lbOldVersion.Name = "lbOldVersion";
            this.lbOldVersion.Size = new System.Drawing.Size(53, 12);
            this.lbOldVersion.TabIndex = 4;
            this.lbOldVersion.Text = "版本号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(249, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "最新版本：";
            // 
            // lbNewVersion
            // 
            this.lbNewVersion.AutoSize = true;
            this.lbNewVersion.Location = new System.Drawing.Point(307, 24);
            this.lbNewVersion.Name = "lbNewVersion";
            this.lbNewVersion.Size = new System.Drawing.Size(65, 12);
            this.lbNewVersion.TabIndex = 6;
            this.lbNewVersion.Text = "最新版本：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "您必须更新到最新版本才能继续使用";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(263, 170);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnDrop
            // 
            this.btnDrop.Location = new System.Drawing.Point(344, 170);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(75, 23);
            this.btnDrop.TabIndex = 9;
            this.btnDrop.Text = "放弃(&D)";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // lbDownInfo
            // 
            this.lbDownInfo.AutoSize = true;
            this.lbDownInfo.Location = new System.Drawing.Point(12, 199);
            this.lbDownInfo.Name = "lbDownInfo";
            this.lbDownInfo.Size = new System.Drawing.Size(0, 12);
            this.lbDownInfo.TabIndex = 10;
            // 
            // prog
            // 
            this.prog.Location = new System.Drawing.Point(14, 218);
            this.prog.Name = "prog";
            this.prog.Size = new System.Drawing.Size(400, 23);
            this.prog.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "更新内容：";
            // 
            // txtUpdate
            // 
            this.txtUpdate.Location = new System.Drawing.Point(131, 60);
            this.txtUpdate.Multiline = true;
            this.txtUpdate.Name = "txtUpdate";
            this.txtUpdate.Size = new System.Drawing.Size(288, 104);
            this.txtUpdate.TabIndex = 13;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 199);
            this.Controls.Add(this.txtUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prog);
            this.Controls.Add(this.lbDownInfo);
            this.Controls.Add(this.btnDrop);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNewVersion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbOldVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbOldVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbNewVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnDrop;
        private System.Windows.Forms.Label lbDownInfo;
        private System.Windows.Forms.ProgressBar prog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUpdate;
    }
}


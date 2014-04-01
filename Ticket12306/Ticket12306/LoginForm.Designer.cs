namespace Ticket12306
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.ckRememerUser = new System.Windows.Forms.CheckBox();
            this.lkDel = new System.Windows.Forms.LinkLabel();
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.txtVc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.chkUserOcr = new System.Windows.Forms.CheckBox();
            this.imgVc = new System.Windows.Forms.PictureBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgVc)).BeginInit();
            this.SuspendLayout();
            // 
            // ckRememerUser
            // 
            this.ckRememerUser.AutoSize = true;
            this.ckRememerUser.BackColor = System.Drawing.Color.Transparent;
            this.ckRememerUser.Checked = true;
            this.ckRememerUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckRememerUser.Location = new System.Drawing.Point(38, 126);
            this.ckRememerUser.Name = "ckRememerUser";
            this.ckRememerUser.Size = new System.Drawing.Size(72, 16);
            this.ckRememerUser.TabIndex = 36;
            this.ckRememerUser.Text = "记住账号";
            this.ckRememerUser.UseVisualStyleBackColor = false;
            // 
            // lkDel
            // 
            this.lkDel.AutoSize = true;
            this.lkDel.BackColor = System.Drawing.Color.Transparent;
            this.lkDel.Location = new System.Drawing.Point(274, 21);
            this.lkDel.Name = "lkDel";
            this.lkDel.Size = new System.Drawing.Size(65, 12);
            this.lkDel.TabIndex = 35;
            this.lkDel.TabStop = true;
            this.lkDel.Text = "删除此账号";
            this.lkDel.Visible = false;
            this.lkDel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkDel_LinkClicked);
            // 
            // cbUserName
            // 
            this.cbUserName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cbUserName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.Location = new System.Drawing.Point(88, 18);
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(179, 20);
            this.cbUserName.TabIndex = 29;
            this.cbUserName.SelectedIndexChanged += new System.EventHandler(this.cbUserName_SelectedIndexChanged);
            this.cbUserName.Leave += new System.EventHandler(this.cbUserName_Leave);
            // 
            // txtVc
            // 
            this.txtVc.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVc.Location = new System.Drawing.Point(88, 77);
            this.txtVc.MaxLength = 4;
            this.txtVc.Name = "txtVc";
            this.txtVc.Size = new System.Drawing.Size(57, 23);
            this.txtVc.TabIndex = 34;
            this.txtVc.TextChanged += new System.EventHandler(this.txtVc_TextChanged);
            this.txtVc.Validated += new System.EventHandler(this.txtVc_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(36, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "验证码：";
            // 
            // txtPwd
            // 
            this.txtPwd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPwd.Location = new System.Drawing.Point(88, 47);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '●';
            this.txtPwd.Size = new System.Drawing.Size(179, 21);
            this.txtPwd.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(36, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "密  码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(36, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "登录名：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMsg});
            this.statusStrip1.Location = new System.Drawing.Point(0, 152);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(403, 22);
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripMsg
            // 
            this.toolStripMsg.Name = "toolStripMsg";
            this.toolStripMsg.Size = new System.Drawing.Size(17, 17);
            this.toolStripMsg.Text = "...";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(116, 122);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 38;
            this.btnLogin.Text = "登录(&L)";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(197, 122);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 39;
            this.btnCancle.Text = "取消(&C)";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // chkUserOcr
            // 
            this.chkUserOcr.AutoSize = true;
            this.chkUserOcr.Checked = true;
            this.chkUserOcr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserOcr.ForeColor = System.Drawing.Color.Red;
            this.chkUserOcr.Location = new System.Drawing.Point(38, 104);
            this.chkUserOcr.Name = "chkUserOcr";
            this.chkUserOcr.Size = new System.Drawing.Size(240, 16);
            this.chkUserOcr.TabIndex = 40;
            this.chkUserOcr.Text = "尝试自动输入验证码（购票高峰时慎用）";
            this.chkUserOcr.UseVisualStyleBackColor = true;
            this.chkUserOcr.CheckedChanged += new System.EventHandler(this.chkUserOcr_CheckedChanged);
            // 
            // imgVc
            // 
            this.imgVc.BackColor = System.Drawing.Color.Transparent;
            this.imgVc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgVc.Location = new System.Drawing.Point(151, 77);
            this.imgVc.Name = "imgVc";
            this.imgVc.Size = new System.Drawing.Size(20, 21);
            this.imgVc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVc.TabIndex = 32;
            this.imgVc.TabStop = false;
            this.imgVc.Click += new System.EventHandler(this.imgVc_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 174);
            this.Controls.Add(this.chkUserOcr);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ckRememerUser);
            this.Controls.Add(this.lkDel);
            this.Controls.Add(this.cbUserName);
            this.Controls.Add(this.imgVc);
            this.Controls.Add(this.txtVc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆到12306";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgVc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckRememerUser;
        private System.Windows.Forms.LinkLabel lkDel;
        private System.Windows.Forms.ComboBox cbUserName;
        private System.Windows.Forms.PictureBox imgVc;
        private System.Windows.Forms.TextBox txtVc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMsg;
        private System.Windows.Forms.Button btnCancle;
        public System.Windows.Forms.CheckBox chkUserOcr;

    }
}
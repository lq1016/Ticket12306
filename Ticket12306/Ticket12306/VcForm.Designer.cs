namespace Ticket12306
{
    partial class VcForm
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
            this.lbMsg = new System.Windows.Forms.Label();
            this.imgVc = new System.Windows.Forms.PictureBox();
            this.txtVc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgVc)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(15, 68);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(0, 12);
            this.lbMsg.TabIndex = 35;
            // 
            // imgVc
            // 
            this.imgVc.BackColor = System.Drawing.Color.Transparent;
            this.imgVc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgVc.Image = global::Ticket12306.Properties.Resources.loading1;
            this.imgVc.Location = new System.Drawing.Point(107, 23);
            this.imgVc.Name = "imgVc";
            this.imgVc.Size = new System.Drawing.Size(150, 60);
            this.imgVc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVc.TabIndex = 33;
            this.imgVc.TabStop = false;
            this.imgVc.Click += new System.EventHandler(this.imgVc_Click);
            // 
            // txtVc
            // 
            this.txtVc.BackColor = System.Drawing.Color.White;
            this.txtVc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.txtVc.Location = new System.Drawing.Point(12, 23);
            this.txtVc.MaxLength = 4;
            this.txtVc.Name = "txtVc";
            this.txtVc.Size = new System.Drawing.Size(89, 38);
            this.txtVc.TabIndex = 37;
            this.txtVc.TextChanged += new System.EventHandler(this.txtVc_TextChanged);
            // 
            // VcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 118);
            this.Controls.Add(this.txtVc);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.imgVc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VcForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "输入验证码";
            ((System.ComponentModel.ISupportInitialize)(this.imgVc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgVc;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.TextBox txtVc;
    }
}
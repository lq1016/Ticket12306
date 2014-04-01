namespace Ticket12306
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.chkListPassenger = new System.Windows.Forms.CheckedListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.colTicketType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.colSeatType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.imgVc = new System.Windows.Forms.PictureBox();
            this.txtVc = new System.Windows.Forms.TextBox();
            this.colxm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkRefresh = new System.Windows.Forms.LinkLabel();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colzjlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colzjhm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStationInfo = new System.Windows.Forms.Label();
            this.plSeatType = new System.Windows.Forms.Panel();
            this.colsjhm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPassenger = new System.Windows.Forms.DataGridView();
            this.btnOrder = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgVc)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPassenger)).BeginInit();
            this.SuspendLayout();
            // 
            // chkListPassenger
            // 
            this.chkListPassenger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkListPassenger.CheckOnClick = true;
            this.chkListPassenger.ColumnWidth = 75;
            this.chkListPassenger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListPassenger.FormattingEnabled = true;
            this.chkListPassenger.Location = new System.Drawing.Point(0, 0);
            this.chkListPassenger.Margin = new System.Windows.Forms.Padding(2);
            this.chkListPassenger.MultiColumn = true;
            this.chkListPassenger.Name = "chkListPassenger";
            this.chkListPassenger.Size = new System.Drawing.Size(792, 87);
            this.chkListPassenger.TabIndex = 0;
            this.chkListPassenger.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListPassenger_ItemCheck);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.chkListPassenger);
            this.panel3.Location = new System.Drawing.Point(3, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 87);
            this.panel3.TabIndex = 40;
            // 
            // colTicketType
            // 
            this.colTicketType.FillWeight = 81.13367F;
            this.colTicketType.HeaderText = "票种";
            this.colTicketType.Name = "colTicketType";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(0, 335);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(626, 102);
            this.txtLog.TabIndex = 38;
            // 
            // colSeatType
            // 
            this.colSeatType.FillWeight = 81.13367F;
            this.colSeatType.HeaderText = "席别";
            this.colSeatType.Name = "colSeatType";
            // 
            // imgVc
            // 
            this.imgVc.Image = ((System.Drawing.Image)(resources.GetObject("imgVc.Image")));
            this.imgVc.Location = new System.Drawing.Point(712, 340);
            this.imgVc.Name = "imgVc";
            this.imgVc.Size = new System.Drawing.Size(20, 21);
            this.imgVc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgVc.TabIndex = 37;
            this.imgVc.TabStop = false;
            this.imgVc.Click += new System.EventHandler(this.imgVc_Click);
            // 
            // txtVc
            // 
            this.txtVc.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVc.Location = new System.Drawing.Point(634, 338);
            this.txtVc.MaxLength = 4;
            this.txtVc.Name = "txtVc";
            this.txtVc.Size = new System.Drawing.Size(75, 29);
            this.txtVc.TabIndex = 36;
            this.txtVc.TextChanged += new System.EventHandler(this.txtVc_TextChanged);
            // 
            // colxm
            // 
            this.colxm.DataPropertyName = "xm";
            this.colxm.FillWeight = 81.13367F;
            this.colxm.HeaderText = "姓名";
            this.colxm.Name = "colxm";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.linkRefresh);
            this.panel2.Controls.Add(this.txtKey);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(2, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(793, 26);
            this.panel2.TabIndex = 34;
            // 
            // linkRefresh
            // 
            this.linkRefresh.AutoSize = true;
            this.linkRefresh.Location = new System.Drawing.Point(203, 6);
            this.linkRefresh.Name = "linkRefresh";
            this.linkRefresh.Size = new System.Drawing.Size(53, 12);
            this.linkRefresh.TabIndex = 44;
            this.linkRefresh.TabStop = true;
            this.linkRefresh.Text = "重新加载";
            this.linkRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRefresh_LinkClicked);
            // 
            // txtKey
            // 
            this.txtKey.ForeColor = System.Drawing.Color.Black;
            this.txtKey.Location = new System.Drawing.Point(92, 2);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(100, 21);
            this.txtKey.TabIndex = 43;
            this.txtKey.TextChanged += new System.EventHandler(this.txtKey_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 42;
            this.label2.Text = "快速检索乘客：";
            // 
            // colzjlx
            // 
            this.colzjlx.DataPropertyName = "zjlx";
            this.colzjlx.FillWeight = 81.13367F;
            this.colzjlx.HeaderText = "证件类型";
            this.colzjlx.Name = "colzjlx";
            this.colzjlx.Width = 120;
            // 
            // colSno
            // 
            this.colSno.DataPropertyName = "xh";
            this.colSno.FillWeight = 213.198F;
            this.colSno.HeaderText = "序号";
            this.colSno.Name = "colSno";
            this.colSno.Width = 66;
            // 
            // colzjhm
            // 
            this.colzjhm.DataPropertyName = "zjhm";
            this.colzjhm.FillWeight = 81.13367F;
            this.colzjhm.HeaderText = "证件号码";
            this.colzjhm.Name = "colzjhm";
            this.colzjhm.Width = 150;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbStationInfo);
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 43);
            this.panel1.TabIndex = 33;
            // 
            // lbStationInfo
            // 
            this.lbStationInfo.AutoSize = true;
            this.lbStationInfo.Font = new System.Drawing.Font("微软雅黑", 17F, System.Drawing.FontStyle.Bold);
            this.lbStationInfo.ForeColor = System.Drawing.Color.Black;
            this.lbStationInfo.Location = new System.Drawing.Point(7, 5);
            this.lbStationInfo.Name = "lbStationInfo";
            this.lbStationInfo.Size = new System.Drawing.Size(0, 31);
            this.lbStationInfo.TabIndex = 2;
            this.lbStationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plSeatType
            // 
            this.plSeatType.BackColor = System.Drawing.Color.White;
            this.plSeatType.Location = new System.Drawing.Point(2, 47);
            this.plSeatType.Name = "plSeatType";
            this.plSeatType.Size = new System.Drawing.Size(793, 26);
            this.plSeatType.TabIndex = 39;
            // 
            // colsjhm
            // 
            this.colsjhm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colsjhm.DataPropertyName = "sjhm";
            this.colsjhm.FillWeight = 81.13367F;
            this.colsjhm.HeaderText = "手机号码";
            this.colsjhm.Name = "colsjhm";
            // 
            // dgPassenger
            // 
            this.dgPassenger.AllowUserToAddRows = false;
            this.dgPassenger.AllowUserToDeleteRows = false;
            this.dgPassenger.AllowUserToResizeColumns = false;
            this.dgPassenger.AllowUserToResizeRows = false;
            this.dgPassenger.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgPassenger.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgPassenger.ColumnHeadersHeight = 25;
            this.dgPassenger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPassenger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSno,
            this.colSeatType,
            this.colTicketType,
            this.colxm,
            this.colzjlx,
            this.colzjhm,
            this.colsjhm});
            this.dgPassenger.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgPassenger.Location = new System.Drawing.Point(2, 190);
            this.dgPassenger.Name = "dgPassenger";
            this.dgPassenger.RowHeadersVisible = false;
            this.dgPassenger.RowTemplate.Height = 23;
            this.dgPassenger.Size = new System.Drawing.Size(793, 142);
            this.dgPassenger.TabIndex = 35;
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("微软雅黑", 15.75F);
            this.btnOrder.Location = new System.Drawing.Point(634, 377);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(135, 51);
            this.btnOrder.TabIndex = 41;
            this.btnOrder.Text = "提交订单(&S)";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 440);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.imgVc);
            this.Controls.Add(this.txtVc);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.plSeatType);
            this.Controls.Add(this.dgPassenger);
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提交订单";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgVc)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPassenger)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkListPassenger;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewComboBoxColumn colTicketType;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.DataGridViewComboBoxColumn colSeatType;
        private System.Windows.Forms.PictureBox imgVc;
        private System.Windows.Forms.TextBox txtVc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colxm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colzjlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colzjhm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbStationInfo;
        private System.Windows.Forms.Panel plSeatType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colsjhm;
        private System.Windows.Forms.DataGridView dgPassenger;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkRefresh;
    }
}
namespace Ticket12306
{
    partial class MainForm
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
            System.Windows.Forms.Timer timer1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.startTime1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSeatType = new System.Windows.Forms.CheckBox();
            this.plSeatType = new System.Windows.Forms.Panel();
            this.chkWuZuo = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.plTrainType = new System.Windows.Forms.Panel();
            this.chkTrainClassQT = new System.Windows.Forms.CheckBox();
            this.chkTrainClassK = new System.Windows.Forms.CheckBox();
            this.chkTrainClassT = new System.Windows.Forms.CheckBox();
            this.chkTrainClassZ = new System.Windows.Forms.CheckBox();
            this.chkTrainClassD = new System.Windows.Forms.CheckBox();
            this.chkTrainClassQB = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.chkAutoQuery = new System.Windows.Forms.CheckBox();
            this.chkAutoOrder = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.plTrainClass = new System.Windows.Forms.Panel();
            this.pbAddTrainClass = new System.Windows.Forms.PictureBox();
            this.plSelectDates = new System.Windows.Forms.Panel();
            this.pbSelectDates = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.plPassenger = new System.Windows.Forms.Panel();
            this.pbAddPassenger = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbQueryInfo = new System.Windows.Forms.Label();
            this.plQueryInfo = new System.Windows.Forms.Panel();
            this.dgTrainDetails = new System.Windows.Forms.DataGridView();
            this.colSno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArriveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStopOver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsEnabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plNoTicket = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbLoding = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.dgTicket = new System.Windows.Forms.DataGridView();
            this.colTrainCode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colTrainCodeKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAimStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTakeTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShangWu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeDeng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYiDeng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colErDeng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGaoJiRuanWo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRuanWo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYingWo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRuanZuo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYingZuo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWuZuo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQiTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCanOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrder = new System.Windows.Forms.DataGridViewImageColumn();
            this.colFirst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStatusBarUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatusBarMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatusBarSys = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStatusBarTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pbSub = new System.Windows.Forms.PictureBox();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.pbChange = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnOpenInIE = new System.Windows.Forms.ToolStripMenuItem();
            this.切换账号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.chkUserOcr = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.startTime2 = new System.Windows.Forms.ComboBox();
            timer1 = new System.Windows.Forms.Timer(this.components);
            this.plSeatType.SuspendLayout();
            this.plTrainType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddTrainClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectDates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddPassenger)).BeginInit();
            this.plQueryInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgTrainDetails)).BeginInit();
            this.plNoTicket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.lbLoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTicket)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChange)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // startTime1
            // 
            this.startTime1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startTime1.FormattingEnabled = true;
            this.startTime1.Location = new System.Drawing.Point(521, 29);
            this.startTime1.Name = "startTime1";
            this.startTime1.Size = new System.Drawing.Size(62, 20);
            this.startTime1.TabIndex = 33;
            this.startTime1.SelectedIndexChanged += new System.EventHandler(this.startTime_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(486, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "时间：";
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(352, 28);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(106, 21);
            this.startDate.TabIndex = 31;
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(292, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "日期：";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(211, 29);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(75, 21);
            this.txtTo.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(161, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "目的地：";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(61, 29);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(75, 21);
            this.txtFrom.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "出发地：";
            // 
            // chkSeatType
            // 
            this.chkSeatType.AutoSize = true;
            this.chkSeatType.Checked = true;
            this.chkSeatType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeatType.Location = new System.Drawing.Point(614, 78);
            this.chkSeatType.Name = "chkSeatType";
            this.chkSeatType.Size = new System.Drawing.Size(48, 16);
            this.chkSeatType.TabIndex = 43;
            this.chkSeatType.Text = "全选";
            this.chkSeatType.UseVisualStyleBackColor = true;
            this.chkSeatType.CheckedChanged += new System.EventHandler(this.chkSeatType_CheckedChanged);
            // 
            // plSeatType
            // 
            this.plSeatType.BackColor = System.Drawing.Color.Transparent;
            this.plSeatType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plSeatType.Controls.Add(this.chkWuZuo);
            this.plSeatType.Controls.Add(this.checkBox9);
            this.plSeatType.Controls.Add(this.checkBox8);
            this.plSeatType.Controls.Add(this.checkBox7);
            this.plSeatType.Controls.Add(this.checkBox6);
            this.plSeatType.Controls.Add(this.checkBox5);
            this.plSeatType.Controls.Add(this.checkBox4);
            this.plSeatType.Controls.Add(this.checkBox3);
            this.plSeatType.Controls.Add(this.checkBox2);
            this.plSeatType.Controls.Add(this.checkBox1);
            this.plSeatType.Location = new System.Drawing.Point(61, 76);
            this.plSeatType.Name = "plSeatType";
            this.plSeatType.Size = new System.Drawing.Size(549, 20);
            this.plSeatType.TabIndex = 42;
            // 
            // chkWuZuo
            // 
            this.chkWuZuo.AutoSize = true;
            this.chkWuZuo.Checked = true;
            this.chkWuZuo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWuZuo.Location = new System.Drawing.Point(500, 2);
            this.chkWuZuo.Name = "chkWuZuo";
            this.chkWuZuo.Size = new System.Drawing.Size(48, 16);
            this.chkWuZuo.TabIndex = 10;
            this.chkWuZuo.Tag = "WuZuo";
            this.chkWuZuo.Text = "无座";
            this.chkWuZuo.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Checked = true;
            this.checkBox9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox9.Location = new System.Drawing.Point(452, 2);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(48, 16);
            this.checkBox9.TabIndex = 9;
            this.checkBox9.Tag = "YingZuo";
            this.checkBox9.Text = "硬座";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.BackColor = System.Drawing.Color.Transparent;
            this.checkBox8.Checked = true;
            this.checkBox8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox8.Location = new System.Drawing.Point(405, 2);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(48, 16);
            this.checkBox8.TabIndex = 8;
            this.checkBox8.Tag = "RuanZuo";
            this.checkBox8.Text = "软座";
            this.checkBox8.UseVisualStyleBackColor = false;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Checked = true;
            this.checkBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox7.Location = new System.Drawing.Point(359, 2);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(48, 16);
            this.checkBox7.TabIndex = 7;
            this.checkBox7.Tag = "YingWo";
            this.checkBox7.Text = "硬卧";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(312, 2);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(48, 16);
            this.checkBox6.TabIndex = 6;
            this.checkBox6.Tag = "RuanWo";
            this.checkBox6.Text = "软卧";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(241, 2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 16);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Tag = "GaoJiRuanWo";
            this.checkBox5.Text = "高级软卧";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(181, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(60, 16);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Tag = "ErDeng";
            this.checkBox4.Text = "二等座";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(121, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(60, 16);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Tag = "YiDeng";
            this.checkBox3.Text = "一等座";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(62, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(60, 16);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Tag = "TeDeng";
            this.checkBox2.Text = "特等座";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Tag = "ShangWu";
            this.checkBox1.Text = "商务座";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(9, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "席  别：";
            // 
            // plTrainType
            // 
            this.plTrainType.BackColor = System.Drawing.Color.Transparent;
            this.plTrainType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plTrainType.Controls.Add(this.chkTrainClassQT);
            this.plTrainType.Controls.Add(this.chkTrainClassK);
            this.plTrainType.Controls.Add(this.chkTrainClassT);
            this.plTrainType.Controls.Add(this.chkTrainClassZ);
            this.plTrainType.Controls.Add(this.chkTrainClassD);
            this.plTrainType.Controls.Add(this.chkTrainClassQB);
            this.plTrainType.Location = new System.Drawing.Point(61, 53);
            this.plTrainType.Name = "plTrainType";
            this.plTrainType.Size = new System.Drawing.Size(353, 20);
            this.plTrainType.TabIndex = 40;
            // 
            // chkTrainClassQT
            // 
            this.chkTrainClassQT.AutoSize = true;
            this.chkTrainClassQT.Checked = true;
            this.chkTrainClassQT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrainClassQT.Location = new System.Drawing.Point(300, 1);
            this.chkTrainClassQT.Name = "chkTrainClassQT";
            this.chkTrainClassQT.Size = new System.Drawing.Size(48, 16);
            this.chkTrainClassQT.TabIndex = 5;
            this.chkTrainClassQT.Tag = "QT";
            this.chkTrainClassQT.Text = "其他";
            this.chkTrainClassQT.UseVisualStyleBackColor = true;
            // 
            // chkTrainClassK
            // 
            this.chkTrainClassK.AutoSize = true;
            this.chkTrainClassK.Checked = true;
            this.chkTrainClassK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrainClassK.Location = new System.Drawing.Point(238, 1);
            this.chkTrainClassK.Name = "chkTrainClassK";
            this.chkTrainClassK.Size = new System.Drawing.Size(54, 16);
            this.chkTrainClassK.TabIndex = 4;
            this.chkTrainClassK.Tag = "K";
            this.chkTrainClassK.Text = "K字头";
            this.chkTrainClassK.UseVisualStyleBackColor = true;
            // 
            // chkTrainClassT
            // 
            this.chkTrainClassT.AutoSize = true;
            this.chkTrainClassT.Checked = true;
            this.chkTrainClassT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrainClassT.Location = new System.Drawing.Point(176, 1);
            this.chkTrainClassT.Name = "chkTrainClassT";
            this.chkTrainClassT.Size = new System.Drawing.Size(54, 16);
            this.chkTrainClassT.TabIndex = 3;
            this.chkTrainClassT.Tag = "T";
            this.chkTrainClassT.Text = "T字头";
            this.chkTrainClassT.UseVisualStyleBackColor = true;
            // 
            // chkTrainClassZ
            // 
            this.chkTrainClassZ.AutoSize = true;
            this.chkTrainClassZ.Checked = true;
            this.chkTrainClassZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrainClassZ.Location = new System.Drawing.Point(114, 1);
            this.chkTrainClassZ.Name = "chkTrainClassZ";
            this.chkTrainClassZ.Size = new System.Drawing.Size(54, 16);
            this.chkTrainClassZ.TabIndex = 2;
            this.chkTrainClassZ.Tag = "Z";
            this.chkTrainClassZ.Text = "Z字头";
            this.chkTrainClassZ.UseVisualStyleBackColor = true;
            // 
            // chkTrainClassD
            // 
            this.chkTrainClassD.AutoSize = true;
            this.chkTrainClassD.Checked = true;
            this.chkTrainClassD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrainClassD.Location = new System.Drawing.Point(58, 1);
            this.chkTrainClassD.Name = "chkTrainClassD";
            this.chkTrainClassD.Size = new System.Drawing.Size(48, 16);
            this.chkTrainClassD.TabIndex = 1;
            this.chkTrainClassD.Tag = "G#C#D";
            this.chkTrainClassD.Text = "动车";
            this.chkTrainClassD.UseVisualStyleBackColor = true;
            // 
            // chkTrainClassQB
            // 
            this.chkTrainClassQB.AutoSize = true;
            this.chkTrainClassQB.Checked = true;
            this.chkTrainClassQB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrainClassQB.Location = new System.Drawing.Point(2, 1);
            this.chkTrainClassQB.Name = "chkTrainClassQB";
            this.chkTrainClassQB.Size = new System.Drawing.Size(48, 16);
            this.chkTrainClassQB.TabIndex = 0;
            this.chkTrainClassQB.Tag = "QB";
            this.chkTrainClassQB.Text = "全部";
            this.chkTrainClassQB.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 12);
            this.label5.TabIndex = 39;
            this.label5.Text = "车  型：";
            // 
            // btnQuery
            // 
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(829, 32);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(105, 40);
            this.btnQuery.TabIndex = 45;
            this.btnQuery.Text = "查 询(&Q)";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // chkAutoQuery
            // 
            this.chkAutoQuery.AutoSize = true;
            this.chkAutoQuery.Location = new System.Drawing.Point(831, 76);
            this.chkAutoQuery.Name = "chkAutoQuery";
            this.chkAutoQuery.Size = new System.Drawing.Size(96, 16);
            this.chkAutoQuery.TabIndex = 46;
            this.chkAutoQuery.Text = "开启自动查询";
            this.chkAutoQuery.UseVisualStyleBackColor = true;
            this.chkAutoQuery.CheckedChanged += new System.EventHandler(this.chkAutoQuery_CheckedChanged);
            // 
            // chkAutoOrder
            // 
            this.chkAutoOrder.AutoSize = true;
            this.chkAutoOrder.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkAutoOrder.Location = new System.Drawing.Point(10, 101);
            this.chkAutoOrder.Name = "chkAutoOrder";
            this.chkAutoOrder.Size = new System.Drawing.Size(102, 16);
            this.chkAutoOrder.TabIndex = 47;
            this.chkAutoOrder.Text = "开启自动提交";
            this.chkAutoOrder.UseVisualStyleBackColor = true;
            this.chkAutoOrder.CheckedChanged += new System.EventHandler(this.chkAutoOrder_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.plTrainClass);
            this.groupBox1.Controls.Add(this.pbAddTrainClass);
            this.groupBox1.Controls.Add(this.plSelectDates);
            this.groupBox1.Controls.Add(this.pbSelectDates);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.plPassenger);
            this.groupBox1.Controls.Add(this.pbAddPassenger);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(8, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(926, 101);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // plTrainClass
            // 
            this.plTrainClass.Location = new System.Drawing.Point(95, 43);
            this.plTrainClass.Name = "plTrainClass";
            this.plTrainClass.Size = new System.Drawing.Size(825, 19);
            this.plTrainClass.TabIndex = 42;
            // 
            // pbAddTrainClass
            // 
            this.pbAddTrainClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddTrainClass.Image = global::Ticket12306.Properties.Resources.IconAdd;
            this.pbAddTrainClass.Location = new System.Drawing.Point(71, 44);
            this.pbAddTrainClass.Name = "pbAddTrainClass";
            this.pbAddTrainClass.Size = new System.Drawing.Size(16, 16);
            this.pbAddTrainClass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAddTrainClass.TabIndex = 41;
            this.pbAddTrainClass.TabStop = false;
            this.pbAddTrainClass.Click += new System.EventHandler(this.pbAddTrainClass_Click);
            // 
            // plSelectDates
            // 
            this.plSelectDates.Location = new System.Drawing.Point(95, 68);
            this.plSelectDates.Name = "plSelectDates";
            this.plSelectDates.Size = new System.Drawing.Size(523, 19);
            this.plSelectDates.TabIndex = 40;
            // 
            // pbSelectDates
            // 
            this.pbSelectDates.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSelectDates.Image = global::Ticket12306.Properties.Resources.IconAdd;
            this.pbSelectDates.Location = new System.Drawing.Point(71, 69);
            this.pbSelectDates.Name = "pbSelectDates";
            this.pbSelectDates.Size = new System.Drawing.Size(16, 16);
            this.pbSelectDates.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSelectDates.TabIndex = 39;
            this.pbSelectDates.TabStop = false;
            this.pbSelectDates.Click += new System.EventHandler(this.pbSelectDates_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(6, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 12);
            this.label9.TabIndex = 36;
            this.label9.Text = "备选日期：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "优先车次：";
            // 
            // plPassenger
            // 
            this.plPassenger.Location = new System.Drawing.Point(95, 20);
            this.plPassenger.Name = "plPassenger";
            this.plPassenger.Size = new System.Drawing.Size(523, 19);
            this.plPassenger.TabIndex = 27;
            // 
            // pbAddPassenger
            // 
            this.pbAddPassenger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAddPassenger.Image = global::Ticket12306.Properties.Resources.IconAdd;
            this.pbAddPassenger.Location = new System.Drawing.Point(71, 20);
            this.pbAddPassenger.Name = "pbAddPassenger";
            this.pbAddPassenger.Size = new System.Drawing.Size(16, 16);
            this.pbAddPassenger.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAddPassenger.TabIndex = 26;
            this.pbAddPassenger.TabStop = false;
            this.pbAddPassenger.Click += new System.EventHandler(this.pbAddPassenger_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "乘客人：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbQueryInfo
            // 
            this.lbQueryInfo.AutoSize = true;
            this.lbQueryInfo.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbQueryInfo.ForeColor = System.Drawing.Color.Black;
            this.lbQueryInfo.Location = new System.Drawing.Point(138, 102);
            this.lbQueryInfo.Name = "lbQueryInfo";
            this.lbQueryInfo.Size = new System.Drawing.Size(0, 12);
            this.lbQueryInfo.TabIndex = 53;
            // 
            // plQueryInfo
            // 
            this.plQueryInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.plQueryInfo.Controls.Add(this.dgTrainDetails);
            this.plQueryInfo.Controls.Add(this.plNoTicket);
            this.plQueryInfo.Controls.Add(this.lbLoding);
            this.plQueryInfo.Controls.Add(this.dgTicket);
            this.plQueryInfo.Location = new System.Drawing.Point(9, 222);
            this.plQueryInfo.Name = "plQueryInfo";
            this.plQueryInfo.Size = new System.Drawing.Size(925, 407);
            this.plQueryInfo.TabIndex = 49;
            // 
            // dgTrainDetails
            // 
            this.dgTrainDetails.AllowUserToAddRows = false;
            this.dgTrainDetails.AllowUserToDeleteRows = false;
            this.dgTrainDetails.AllowUserToResizeColumns = false;
            this.dgTrainDetails.AllowUserToResizeRows = false;
            this.dgTrainDetails.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgTrainDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgTrainDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgTrainDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgTrainDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSno,
            this.colStationName,
            this.colArriveTime,
            this.colStartTime,
            this.colStopOver,
            this.colIsEnabled});
            this.dgTrainDetails.Location = new System.Drawing.Point(229, 29);
            this.dgTrainDetails.MultiSelect = false;
            this.dgTrainDetails.Name = "dgTrainDetails";
            this.dgTrainDetails.RowHeadersVisible = false;
            this.dgTrainDetails.RowTemplate.Height = 23;
            this.dgTrainDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTrainDetails.Size = new System.Drawing.Size(502, 187);
            this.dgTrainDetails.TabIndex = 59;
            this.dgTrainDetails.Visible = false;
            this.dgTrainDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgTrainDetails_CellFormatting);
            this.dgTrainDetails.Leave += new System.EventHandler(this.dgTrainDetails_Leave);
            // 
            // colSno
            // 
            this.colSno.DataPropertyName = "station_no";
            this.colSno.HeaderText = "序号";
            this.colSno.Name = "colSno";
            this.colSno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSno.Width = 50;
            // 
            // colStationName
            // 
            this.colStationName.DataPropertyName = "station_name";
            this.colStationName.HeaderText = "站名";
            this.colStationName.Name = "colStationName";
            this.colStationName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colArriveTime
            // 
            this.colArriveTime.DataPropertyName = "arrive_time";
            this.colArriveTime.HeaderText = "到达时间";
            this.colArriveTime.Name = "colArriveTime";
            this.colArriveTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colArriveTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colArriveTime.Width = 120;
            // 
            // colStartTime
            // 
            this.colStartTime.DataPropertyName = "start_time";
            this.colStartTime.HeaderText = "出发时间";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStartTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStartTime.Width = 120;
            // 
            // colStopOver
            // 
            this.colStopOver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStopOver.DataPropertyName = "stopover_time";
            this.colStopOver.HeaderText = "停留时间";
            this.colStopOver.Name = "colStopOver";
            this.colStopOver.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStopOver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colIsEnabled
            // 
            this.colIsEnabled.DataPropertyName = "isEnabled";
            this.colIsEnabled.HeaderText = "isEnabled";
            this.colIsEnabled.Name = "colIsEnabled";
            this.colIsEnabled.Visible = false;
            // 
            // plNoTicket
            // 
            this.plNoTicket.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.plNoTicket.BackColor = System.Drawing.Color.White;
            this.plNoTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plNoTicket.Controls.Add(this.pictureBox3);
            this.plNoTicket.Controls.Add(this.label11);
            this.plNoTicket.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plNoTicket.ForeColor = System.Drawing.Color.Transparent;
            this.plNoTicket.Location = new System.Drawing.Point(324, 215);
            this.plNoTicket.Name = "plNoTicket";
            this.plNoTicket.Size = new System.Drawing.Size(276, 53);
            this.plNoTicket.TabIndex = 58;
            this.plNoTicket.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Ticket12306.Properties.Resources.Sorry;
            this.pictureBox3.Location = new System.Drawing.Point(11, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(51, 13);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(198, 26);
            this.label11.TabIndex = 1;
            this.label11.Text = "暂时无票....真是郁闷~";
            // 
            // lbLoding
            // 
            this.lbLoding.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLoding.BackColor = System.Drawing.Color.White;
            this.lbLoding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbLoding.Controls.Add(this.label10);
            this.lbLoding.Controls.Add(this.pbLoading);
            this.lbLoding.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbLoding.ForeColor = System.Drawing.Color.Transparent;
            this.lbLoding.Location = new System.Drawing.Point(324, 177);
            this.lbLoding.Name = "lbLoding";
            this.lbLoding.Size = new System.Drawing.Size(276, 53);
            this.lbLoding.TabIndex = 57;
            this.lbLoding.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(51, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(199, 26);
            this.label10.TabIndex = 1;
            this.label10.Text = "数据查询中,请稍候......";
            // 
            // pbLoading
            // 
            this.pbLoading.BackColor = System.Drawing.Color.Transparent;
            this.pbLoading.Image = global::Ticket12306.Properties.Resources.loading2;
            this.pbLoading.Location = new System.Drawing.Point(12, 11);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(32, 32);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLoading.TabIndex = 0;
            this.pbLoading.TabStop = false;
            // 
            // dgTicket
            // 
            this.dgTicket.AllowUserToAddRows = false;
            this.dgTicket.AllowUserToDeleteRows = false;
            this.dgTicket.AllowUserToResizeColumns = false;
            this.dgTicket.AllowUserToResizeRows = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgTicket.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgTicket.BackgroundColor = System.Drawing.Color.White;
            this.dgTicket.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTicket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgTicket.ColumnHeadersHeight = 25;
            this.dgTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgTicket.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTrainCode,
            this.colTrainCodeKey,
            this.colStartStation,
            this.colAimStation,
            this.colTakeTime,
            this.colShangWu,
            this.colTeDeng,
            this.colYiDeng,
            this.colErDeng,
            this.colGaoJiRuanWo,
            this.colRuanWo,
            this.colYingWo,
            this.colRuanZuo,
            this.colYingZuo,
            this.colWuZuo,
            this.colQiTa,
            this.OrderKey,
            this.colCanOrder,
            this.colOrder,
            this.colFirst,
            this.colLast});
            this.dgTicket.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.Ivory;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgTicket.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTicket.GridColor = System.Drawing.Color.Silver;
            this.dgTicket.Location = new System.Drawing.Point(0, 0);
            this.dgTicket.MultiSelect = false;
            this.dgTicket.Name = "dgTicket";
            this.dgTicket.ReadOnly = true;
            this.dgTicket.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgTicket.RowHeadersVisible = false;
            this.dgTicket.RowHeadersWidth = 32;
            this.dgTicket.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgTicket.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgTicket.RowTemplate.Height = 35;
            this.dgTicket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgTicket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTicket.ShowCellErrors = false;
            this.dgTicket.ShowEditingIcon = false;
            this.dgTicket.ShowRowErrors = false;
            this.dgTicket.Size = new System.Drawing.Size(925, 407);
            this.dgTicket.TabIndex = 56;
            this.dgTicket.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTicket_CellClick);
            this.dgTicket.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgTicket_CellFormatting);
            this.dgTicket.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgTicket_MouseDoubleClick);
            // 
            // colTrainCode
            // 
            this.colTrainCode.ActiveLinkColor = System.Drawing.Color.Blue;
            this.colTrainCode.DataPropertyName = "TrainCode";
            this.colTrainCode.HeaderText = "车次";
            this.colTrainCode.Name = "colTrainCode";
            this.colTrainCode.ReadOnly = true;
            this.colTrainCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTrainCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colTrainCode.VisitedLinkColor = System.Drawing.Color.Blue;
            this.colTrainCode.Width = 55;
            // 
            // colTrainCodeKey
            // 
            this.colTrainCodeKey.DataPropertyName = "TrainCodeKey";
            this.colTrainCodeKey.HeaderText = "TrainCodeKey";
            this.colTrainCodeKey.Name = "colTrainCodeKey";
            this.colTrainCodeKey.ReadOnly = true;
            this.colTrainCodeKey.Visible = false;
            // 
            // colStartStation
            // 
            this.colStartStation.DataPropertyName = "StartStation";
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colStartStation.DefaultCellStyle = dataGridViewCellStyle17;
            this.colStartStation.HeaderText = "发站";
            this.colStartStation.Name = "colStartStation";
            this.colStartStation.ReadOnly = true;
            this.colStartStation.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStartStation.Width = 118;
            // 
            // colAimStation
            // 
            this.colAimStation.DataPropertyName = "AimStation";
            this.colAimStation.HeaderText = "到站";
            this.colAimStation.Name = "colAimStation";
            this.colAimStation.ReadOnly = true;
            this.colAimStation.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAimStation.Width = 113;
            // 
            // colTakeTime
            // 
            this.colTakeTime.DataPropertyName = "TakeTime";
            this.colTakeTime.HeaderText = "用时";
            this.colTakeTime.Name = "colTakeTime";
            this.colTakeTime.ReadOnly = true;
            this.colTakeTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTakeTime.Width = 42;
            // 
            // colShangWu
            // 
            this.colShangWu.DataPropertyName = "ShangWu";
            this.colShangWu.HeaderText = "商务座";
            this.colShangWu.Name = "colShangWu";
            this.colShangWu.ReadOnly = true;
            this.colShangWu.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colShangWu.Width = 53;
            // 
            // colTeDeng
            // 
            this.colTeDeng.DataPropertyName = "TeDeng";
            this.colTeDeng.HeaderText = "特等座";
            this.colTeDeng.Name = "colTeDeng";
            this.colTeDeng.ReadOnly = true;
            this.colTeDeng.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTeDeng.Width = 53;
            // 
            // colYiDeng
            // 
            this.colYiDeng.DataPropertyName = "YiDeng";
            this.colYiDeng.HeaderText = "一等座";
            this.colYiDeng.Name = "colYiDeng";
            this.colYiDeng.ReadOnly = true;
            this.colYiDeng.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colYiDeng.Width = 53;
            // 
            // colErDeng
            // 
            this.colErDeng.DataPropertyName = "ErDeng";
            this.colErDeng.HeaderText = "二等座";
            this.colErDeng.Name = "colErDeng";
            this.colErDeng.ReadOnly = true;
            this.colErDeng.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colErDeng.Width = 53;
            // 
            // colGaoJiRuanWo
            // 
            this.colGaoJiRuanWo.DataPropertyName = "GaoJiRuanWo";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colGaoJiRuanWo.DefaultCellStyle = dataGridViewCellStyle18;
            this.colGaoJiRuanWo.HeaderText = "高级软卧";
            this.colGaoJiRuanWo.Name = "colGaoJiRuanWo";
            this.colGaoJiRuanWo.ReadOnly = true;
            this.colGaoJiRuanWo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colGaoJiRuanWo.Width = 65;
            // 
            // colRuanWo
            // 
            this.colRuanWo.DataPropertyName = "RuanWo";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colRuanWo.DefaultCellStyle = dataGridViewCellStyle19;
            this.colRuanWo.HeaderText = "软卧";
            this.colRuanWo.Name = "colRuanWo";
            this.colRuanWo.ReadOnly = true;
            this.colRuanWo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRuanWo.Width = 42;
            // 
            // colYingWo
            // 
            this.colYingWo.DataPropertyName = "YingWo";
            this.colYingWo.HeaderText = "硬卧";
            this.colYingWo.Name = "colYingWo";
            this.colYingWo.ReadOnly = true;
            this.colYingWo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colYingWo.Width = 42;
            // 
            // colRuanZuo
            // 
            this.colRuanZuo.DataPropertyName = "RuanZuo";
            this.colRuanZuo.HeaderText = "软座";
            this.colRuanZuo.Name = "colRuanZuo";
            this.colRuanZuo.ReadOnly = true;
            this.colRuanZuo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colRuanZuo.Width = 42;
            // 
            // colYingZuo
            // 
            this.colYingZuo.DataPropertyName = "YingZuo";
            this.colYingZuo.HeaderText = "硬座";
            this.colYingZuo.Name = "colYingZuo";
            this.colYingZuo.ReadOnly = true;
            this.colYingZuo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colYingZuo.Width = 42;
            // 
            // colWuZuo
            // 
            this.colWuZuo.DataPropertyName = "WuZuo";
            this.colWuZuo.HeaderText = "无座";
            this.colWuZuo.Name = "colWuZuo";
            this.colWuZuo.ReadOnly = true;
            this.colWuZuo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colWuZuo.Width = 42;
            // 
            // colQiTa
            // 
            this.colQiTa.DataPropertyName = "QiTa";
            this.colQiTa.HeaderText = "其他";
            this.colQiTa.Name = "colQiTa";
            this.colQiTa.ReadOnly = true;
            this.colQiTa.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colQiTa.Visible = false;
            this.colQiTa.Width = 42;
            // 
            // OrderKey
            // 
            this.OrderKey.DataPropertyName = "OrderKey";
            this.OrderKey.HeaderText = "OrderKey";
            this.OrderKey.Name = "OrderKey";
            this.OrderKey.ReadOnly = true;
            this.OrderKey.Visible = false;
            // 
            // colCanOrder
            // 
            this.colCanOrder.DataPropertyName = "CanOrder";
            this.colCanOrder.HeaderText = "colCanOrder";
            this.colCanOrder.Name = "colCanOrder";
            this.colCanOrder.ReadOnly = true;
            this.colCanOrder.Visible = false;
            // 
            // colOrder
            // 
            this.colOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colOrder.DataPropertyName = "Order";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle20.NullValue")));
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colOrder.DefaultCellStyle = dataGridViewCellStyle20;
            this.colOrder.HeaderText = "预订";
            this.colOrder.Name = "colOrder";
            this.colOrder.ReadOnly = true;
            this.colOrder.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colFirst
            // 
            this.colFirst.DataPropertyName = "First";
            this.colFirst.HeaderText = "colFirst";
            this.colFirst.Name = "colFirst";
            this.colFirst.ReadOnly = true;
            this.colFirst.Visible = false;
            // 
            // colLast
            // 
            this.colLast.DataPropertyName = "Last";
            this.colLast.HeaderText = "colLast";
            this.colLast.Name = "colLast";
            this.colLast.ReadOnly = true;
            this.colLast.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStatusBarUser,
            this.toolStatusBarMsg,
            this.toolStatusBarSys,
            this.toolStatusBarTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 632);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(940, 22);
            this.statusStrip1.TabIndex = 50;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStatusBarUser
            // 
            this.toolStatusBarUser.AutoSize = false;
            this.toolStatusBarUser.AutoToolTip = true;
            this.toolStatusBarUser.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStatusBarUser.Image = global::Ticket12306.Properties.Resources.user;
            this.toolStatusBarUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStatusBarUser.Name = "toolStatusBarUser";
            this.toolStatusBarUser.Size = new System.Drawing.Size(63, 17);
            this.toolStatusBarUser.Text = "刘强";
            this.toolStatusBarUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStatusBarUser.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStatusBarUser.ToolTipText = "刘强   ";
            // 
            // toolStatusBarMsg
            // 
            this.toolStatusBarMsg.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStatusBarMsg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStatusBarMsg.Image = global::Ticket12306.Properties.Resources.message;
            this.toolStatusBarMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStatusBarMsg.Name = "toolStatusBarMsg";
            this.toolStatusBarMsg.Size = new System.Drawing.Size(706, 17);
            this.toolStatusBarMsg.Spring = true;
            this.toolStatusBarMsg.Text = "今天可以购买。。。";
            // 
            // toolStatusBarSys
            // 
            this.toolStatusBarSys.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStatusBarSys.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStatusBarSys.Image = global::Ticket12306.Properties.Resources.Sys;
            this.toolStatusBarSys.Name = "toolStatusBarSys";
            this.toolStatusBarSys.Size = new System.Drawing.Size(117, 17);
            this.toolStatusBarSys.Text = "登陆状态：已登陆";
            // 
            // toolStatusBarTime
            // 
            this.toolStatusBarTime.Font = new System.Drawing.Font("新宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStatusBarTime.Image = global::Ticket12306.Properties.Resources.time;
            this.toolStatusBarTime.Name = "toolStatusBarTime";
            this.toolStatusBarTime.Size = new System.Drawing.Size(39, 17);
            this.toolStatusBarTime.Text = "200";
            // 
            // pbSub
            // 
            this.pbSub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSub.Image = global::Ticket12306.Properties.Resources.Sub1;
            this.pbSub.Location = new System.Drawing.Point(331, 30);
            this.pbSub.Name = "pbSub";
            this.pbSub.Size = new System.Drawing.Size(16, 16);
            this.pbSub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSub.TabIndex = 34;
            this.pbSub.TabStop = false;
            this.pbSub.Click += new System.EventHandler(this.pbSub_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbAdd.Image = global::Ticket12306.Properties.Resources.Add;
            this.pbAdd.Location = new System.Drawing.Point(462, 30);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(16, 16);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAdd.TabIndex = 30;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // pbChange
            // 
            this.pbChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbChange.Image = ((System.Drawing.Image)(resources.GetObject("pbChange.Image")));
            this.pbChange.Location = new System.Drawing.Point(140, 33);
            this.pbChange.Name = "pbChange";
            this.pbChange.Size = new System.Drawing.Size(18, 13);
            this.pbChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbChange.TabIndex = 26;
            this.pbChange.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(170)))), ((int)(((byte)(193)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenInIE,
            this.切换账号ToolStripMenuItem,
            this.btnExit,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 25);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnOpenInIE
            // 
            this.btnOpenInIE.Name = "btnOpenInIE";
            this.btnOpenInIE.Size = new System.Drawing.Size(114, 21);
            this.btnOpenInIE.Text = "IE中打开12306(&I)";
            this.btnOpenInIE.Click += new System.EventHandler(this.btnOpenInIE_Click);
            // 
            // 切换账号ToolStripMenuItem
            // 
            this.切换账号ToolStripMenuItem.Name = "切换账号ToolStripMenuItem";
            this.切换账号ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.切换账号ToolStripMenuItem.Text = "切换账号(&C)";
            this.切换账号ToolStripMenuItem.Click += new System.EventHandler(this.切换账号ToolStripMenuItem_Click);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(59, 21);
            this.btnExit.Text = "退出(&E)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(421, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 54;
            this.label13.Text = "预售期：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(467, 53);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown1.TabIndex = 55;
            this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(516, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 56;
            this.label14.Text = "(天)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(550, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "自动刷新间隔：";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(633, 52);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(38, 21);
            this.numericUpDown2.TabIndex = 58;
            this.numericUpDown2.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(677, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 59;
            this.label16.Text = "(秒)";
            // 
            // chkUserOcr
            // 
            this.chkUserOcr.AutoSize = true;
            this.chkUserOcr.Checked = true;
            this.chkUserOcr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserOcr.ForeColor = System.Drawing.Color.Red;
            this.chkUserOcr.Location = new System.Drawing.Point(705, 93);
            this.chkUserOcr.Name = "chkUserOcr";
            this.chkUserOcr.Size = new System.Drawing.Size(240, 16);
            this.chkUserOcr.TabIndex = 61;
            this.chkUserOcr.Text = "尝试自动输入验证码（购票高峰时慎用）";
            this.chkUserOcr.UseVisualStyleBackColor = true;
            this.chkUserOcr.CheckedChanged += new System.EventHandler(this.chkUserOcr_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(590, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 62;
            this.label12.Text = "--";
            // 
            // startTime2
            // 
            this.startTime2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startTime2.FormattingEnabled = true;
            this.startTime2.Items.AddRange(new object[] {
            "00:00--24:00",
            "00:00--06:00",
            "06:00--12:00",
            "12:00--18:00",
            "18:00--24:00"});
            this.startTime2.Location = new System.Drawing.Point(614, 28);
            this.startTime2.Name = "startTime2";
            this.startTime2.Size = new System.Drawing.Size(62, 20);
            this.startTime2.TabIndex = 63;
            this.startTime2.SelectedIndexChanged += new System.EventHandler(this.startTime2_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 654);
            this.Controls.Add(this.startTime2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chkUserOcr);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.plQueryInfo);
            this.Controls.Add(this.lbQueryInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkAutoOrder);
            this.Controls.Add(this.chkAutoQuery);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.chkSeatType);
            this.Controls.Add(this.plSeatType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.plTrainType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pbSub);
            this.Controls.Add(this.startTime1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.pbAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbChange);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.plSeatType.ResumeLayout(false);
            this.plSeatType.PerformLayout();
            this.plTrainType.ResumeLayout(false);
            this.plTrainType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddTrainClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectDates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAddPassenger)).EndInit();
            this.plQueryInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgTrainDetails)).EndInit();
            this.plNoTicket.ResumeLayout(false);
            this.plNoTicket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.lbLoding.ResumeLayout(false);
            this.lbLoding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgTicket)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbChange)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSub;
        private System.Windows.Forms.ComboBox startTime1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.PictureBox pbAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbChange;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSeatType;
        private System.Windows.Forms.Panel plSeatType;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel plTrainType;
        internal System.Windows.Forms.CheckBox chkTrainClassQT;
        internal System.Windows.Forms.CheckBox chkTrainClassK;
        internal System.Windows.Forms.CheckBox chkTrainClassT;
        internal System.Windows.Forms.CheckBox chkTrainClassZ;
        internal System.Windows.Forms.CheckBox chkTrainClassD;
        internal System.Windows.Forms.CheckBox chkTrainClassQB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.CheckBox chkAutoQuery;
        private System.Windows.Forms.CheckBox chkAutoOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbAddPassenger;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel plPassenger;
        private System.Windows.Forms.Label lbQueryInfo;
        private System.Windows.Forms.Panel plQueryInfo;
        private System.Windows.Forms.DataGridView dgTicket;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusBarUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusBarMsg;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusBarSys;
        private System.Windows.Forms.ToolStripStatusLabel toolStatusBarTime;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel lbLoding;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Panel plNoTicket;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem 切换账号ToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgTrainDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArriveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStopOver;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsEnabled;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel plSelectDates;
        private System.Windows.Forms.PictureBox pbSelectDates;
        private System.Windows.Forms.ToolStripMenuItem btnOpenInIE;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkWuZuo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel plTrainClass;
        private System.Windows.Forms.PictureBox pbAddTrainClass;
        public System.Windows.Forms.CheckBox chkUserOcr;
        private System.Windows.Forms.DataGridViewLinkColumn colTrainCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrainCodeKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAimStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTakeTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShangWu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeDeng;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYiDeng;
        private System.Windows.Forms.DataGridViewTextBoxColumn colErDeng;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGaoJiRuanWo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuanWo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYingWo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuanZuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYingZuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWuZuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQiTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCanOrder;
        private System.Windows.Forms.DataGridViewImageColumn colOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirst;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLast;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox startTime2;
    }
}
namespace Ticket12306
{
    partial class SelectTrainClassForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colTrainClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRunTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colTrainClass,
            this.colTimeSpan,
            this.colRunTime});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(448, 241);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "select";
            this.colCheck.FalseValue = "0";
            this.colCheck.HeaderText = "";
            this.colCheck.IndeterminateValue = "0";
            this.colCheck.Name = "colCheck";
            this.colCheck.TrueValue = "1";
            this.colCheck.Width = 20;
            // 
            // colTrainClass
            // 
            this.colTrainClass.DataPropertyName = "TrainClass";
            this.colTrainClass.HeaderText = "车次";
            this.colTrainClass.Name = "colTrainClass";
            // 
            // colTimeSpan
            // 
            this.colTimeSpan.DataPropertyName = "TimeSpan";
            this.colTimeSpan.HeaderText = "发车－到站时间";
            this.colTimeSpan.Name = "colTimeSpan";
            this.colTimeSpan.Width = 200;
            // 
            // colRunTime
            // 
            this.colRunTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRunTime.DataPropertyName = "RunTime";
            this.colRunTime.HeaderText = "运行时间";
            this.colRunTime.Name = "colRunTime";
            // 
            // SelectTrainClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 241);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectTrainClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择优先车次";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrainClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRunTime;
    }
}
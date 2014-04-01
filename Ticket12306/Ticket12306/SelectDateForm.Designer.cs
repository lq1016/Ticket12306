namespace Ticket12306
{
    partial class SelectDateForm
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
            this.chkListDates = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // chkListDates
            // 
            this.chkListDates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chkListDates.CheckOnClick = true;
            this.chkListDates.ColumnWidth = 130;
            this.chkListDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListDates.FormattingEnabled = true;
            this.chkListDates.Location = new System.Drawing.Point(0, 0);
            this.chkListDates.Margin = new System.Windows.Forms.Padding(2);
            this.chkListDates.MultiColumn = true;
            this.chkListDates.Name = "chkListDates";
            this.chkListDates.Size = new System.Drawing.Size(375, 175);
            this.chkListDates.TabIndex = 23;
            this.chkListDates.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListDates_ItemCheck);
            // 
            // SelectDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 175);
            this.Controls.Add(this.chkListDates);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择备选日期(最多5个)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkListDates;
    }
}
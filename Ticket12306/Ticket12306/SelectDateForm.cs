using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ticket12306
{
    public partial class SelectDateForm : Form
    {
        MainForm mf = new MainForm();
        public SelectDateForm(MainForm mf)
        {
            InitializeComponent();
            this.mf = mf;
            LoadDates();
            chkListDates.ItemCheck -= new ItemCheckEventHandler(chkListDates_ItemCheck);
            myDateList = mf.myDateList;
            for (int j = 0; j < chkListDates.Items.Count; j++)
            {
                string date = chkListDates.Items[j].ToString();
                if (myDateList.Contains(date))
                {
                    chkListDates.SetItemCheckState(j, CheckState.Checked);
                }
                else
                {
                    chkListDates.SetItemCheckState(j, CheckState.Unchecked);
                }
            }
            chkListDates.ItemCheck += new ItemCheckEventHandler(chkListDates_ItemCheck);
        }
        public void LoadDates()
        {
            this.chkListDates.Items.Clear();
            for (int i = 0; i < 20; i++)
            {
                string date=DateTime.Now.AddDays(i).ToString("yyyy-MM-dd");
                this.chkListDates.Items.Add(date);
            }
        }
        List<string> myDateList = new List<string>();
        private void chkListDates_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string date = this.chkListDates.Items[e.Index].ToString();
            if (e.NewValue == CheckState.Checked)
            {
                if (myDateList.Count == 5)
                {
                    e.NewValue = CheckState.Unchecked;
                    MessageBox.Show("对不起，你最多只能选择5个备选日期！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!myDateList.Contains(date))
                    {
                        myDateList.Add(date);
                    }
                }
            }
            else
            {
                myDateList.Remove(date);
            }
            mf.myDateList = myDateList;
            mf.LoadDates();

        }
    }
}

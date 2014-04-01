using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ticket12306.Utility;

namespace Ticket12306
{
    public partial class SelectPassengerForm : Form
    {
        MainForm mf = new MainForm();
        public SelectPassengerForm(MainForm mf)
        {
            InitializeComponent();
            this.mf = mf;
            LoadPassenger(StaticValues.PassengerList);
            chkListPassenger.ItemCheck -= new ItemCheckEventHandler(chkListPassenger_ItemCheck);
            myList = mf.myList;
            for (int j = 0; j < chkListPassenger.Items.Count; j++)
            {
                PassengerDTOs p = (PassengerDTOs)chkListPassenger.Items[j];
                if (myList.Exists(p1 => p1.passenger_name == p.passenger_name))
                {
                    chkListPassenger.SetItemCheckState(j, CheckState.Checked);
                }
                else
                {
                    chkListPassenger.SetItemCheckState(j, CheckState.Unchecked);
                }
            }
            chkListPassenger.ItemCheck += new ItemCheckEventHandler(chkListPassenger_ItemCheck);
            
        }
        List<PassengerDTOs> myList = new List<PassengerDTOs>();
        private void linkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtKey.Text = "";
            myList.Clear();
            TicketHelper.GetPassengers();
            LoadPassenger(StaticValues.PassengerList);

        }
        private void LoadPassenger(List<PassengerDTOs> list)
        {
            this.chkListPassenger.DataSource = list;
            this.chkListPassenger.DisplayMember = "passenger_name";
            this.chkListPassenger.ValueMember = "passenger_id_no";
            this.chkListPassenger.SelectedIndex = -1;
            chkListPassenger.ItemCheck -= new ItemCheckEventHandler(chkListPassenger_ItemCheck);
            for (int i = 0; i < chkListPassenger.Items.Count; i++)
            {
                PassengerDTOs p = ((PassengerDTOs)this.chkListPassenger.Items[i]);
                if (myList.Contains(p))
                {
                    this.chkListPassenger.SetItemChecked(i, true);
                }
                else
                {
                    this.chkListPassenger.SetItemChecked(i, false);
                }
            }
            chkListPassenger.ItemCheck += new ItemCheckEventHandler(chkListPassenger_ItemCheck);
        }

        private void chkListPassenger_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            PassengerDTOs p = ((PassengerDTOs)this.chkListPassenger.Items[e.Index]);
            if (e.NewValue == CheckState.Checked)
            {
                if (myList.Count == 5)
                {
                    e.NewValue = CheckState.Unchecked;
                    MessageBox.Show("对不起，你最多只能选择5位联系人！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!myList.Contains(p))
                    {
                        myList.Add(p);
                    }
                }
            }
            else
            {
                myList.Remove(p);
            }
            mf.myList = myList;
            mf.LoadPassenger();
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            string key = txtKey.Text.Trim().ToUpper();
            List<PassengerDTOs> list = StaticValues.PassengerList;
            List<PassengerDTOs> listFilter = list.FindAll(p => p.passenger_name.Contains(key) || p.first_letter.ToUpper().Contains(key));
            LoadPassenger(listFilter);
        }
    }
}

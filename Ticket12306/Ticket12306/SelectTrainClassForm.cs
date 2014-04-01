using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ticket12306.Service;
using Ticket12306.Utility;

namespace Ticket12306
{
    public partial class SelectTrainClassForm : Form
    {
        MainForm mf = new MainForm();
        public SelectTrainClassForm(MainForm mf, QueryEntity qe)
        {
            InitializeComponent();
            this.mf = mf;
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("trainClass");
            dtResult.Columns.Add("timeSpan");
            dtResult.Columns.Add("runTime");
            dtResult.Columns.Add("select");
            TicketService service = new TicketService(StaticValues.MyCookies);
            QueryTicketResponseInfo rspInfo = service.QueryLeftTicketDTO(qe.train_date, qe.from_station_telecode, qe.to_station_telecode);
            if (rspInfo != null && rspInfo.status)
            {
                if (rspInfo.data != null && rspInfo.data.Count > 0)
                {
                    foreach (QueryLeftNewDTOData q in rspInfo.data)
                    {
                        bool flag = CheckTrainClass(q, qe);
                        if (flag)
                        {
                            DataRow row = dtResult.NewRow();
                            row["trainClass"] = q.queryLeftNewDTO.station_train_code;
                            if (mf.trainNoList.Contains(q.queryLeftNewDTO.station_train_code))
                            {
                                row["select"] = 1;
                            }
                            else
                                row["select"] = 0;
                            row["timeSpan"] = q.queryLeftNewDTO.start_time + " - " + q.queryLeftNewDTO.arrive_time;
                            row["runTime"] = q.queryLeftNewDTO.lishi;

                            dtResult.Rows.Add(row);
                        }
                    }
                    dataGridView1.DataSource = dtResult;
                }
            }
           
        }
        public static bool CheckTrainClass(QueryLeftNewDTOData q, QueryEntity qe)
        {
            bool flag = false;
            if (qe.trainClass.Contains("QB"))
            {
                flag = true;
            }
            else
            {
                List<string> trainClasslist = qe.trainClass.Split("#".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                string trainCode = q.queryLeftNewDTO.station_train_code.Substring(0, 1).ToUpper();
                trainClasslist.ForEach(t =>
                {
                    if (t.Contains(trainCode))
                    {
                        flag = true;
                    }
                });

            }
            return flag;
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                string trainClass = this.dataGridView1[0, e.RowIndex].Value.ToString();
                DataGridViewCheckBoxCell dch = this.dataGridView1.Rows[e.RowIndex].Cells[3] as DataGridViewCheckBoxCell;
                if (!(bool)dch.EditedFormattedValue)
                {

                    if (!mf.trainNoList.Contains(trainClass))
                    {
                        mf.trainNoList.Add(trainClass);
                    }
                }
                else
                {
                    if (mf.trainNoList.Contains(trainClass))
                    {
                        mf.trainNoList.Remove(trainClass);
                    }
                }
                mf.LoadTrainClass();

            }
        }
        
    }
}

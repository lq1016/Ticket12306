using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Ticket12306.Service;
using Ticket12306.Utility;
using System.Net;
using Waner8.Common;

namespace Ticket12306
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            plQueryInfo.Location = new Point(9, 120);
            plQueryInfo.Height = 509;
            KeyLoginState();
        }
        #region 变量
        private int buyDays = 20;
        private int timeSpan = 5;
        private bool autoBuyFlag = false;//自动购票
        private QueryEntity qe = new QueryEntity();//查询购票的条件
        private Mp3Helper mp3 = null;//MP3播放类
        private ListBox lboxCity = null;//地区选择的列表框
        private bool change = false;//是否触发TextChange事件
        private List<string> seatTypeList = new List<string>() { "ShangWu", "TeDeng", "YiDeng", "ErDeng", "GaoJiRuanWo", "RuanWo", "YingWo", "RuanZuo", "YingZuo", "WuZuo" };
        private bool autoFlag = false;//自动查询
        private string orderId = string.Empty;//orderId
        private string orderToken = string.Empty;//order token
        public List<string> trainNoList = new List<string>();//车次过滤
        public List<PassengerDTOs> myList = new List<PassengerDTOs>();//自动购票选择的联系人
        public List<string> myDateList = new List<string>();//自动购票选择的备选日期
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        private void chkAutoOrder_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = chkAutoOrder.Checked;
            if (!chkAutoOrder.Checked)
            {
                plQueryInfo.Location = new Point(9, 120);
                plQueryInfo.Height = 509;
            }
            else
            {
                plQueryInfo.Location = new Point(9, 220);
                plQueryInfo.Height = 409;
            }
            autoBuyFlag = chkAutoOrder.Checked;
        }

        #region 初始化控件信息
        private void InitControl()
        {
            qe.optionDates = new List<string>();
            //获取系统版本信息
            FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.ExecutablePath);
            string title = myFileVersion.FileDescription + "(" + myFileVersion.FileVersion + ")";
            this.Text = title;
            //状态栏
            toolStatusBarUser.Text = StaticValues.UserName;
            toolStatusBarMsg.Text = "今天可以售[" + DateTime.Now.AddDays(buyDays-1).ToString("yyyy-MM-dd") + "]日车票";
            toolStatusBarTime.Text = DateTime.Now.ToString();
          
            //出发日期
            this.startDate.MinDate = DateTime.Now;
            this.startDate.Value = DateTime.Now.AddDays(buyDays-1);
            this.startDate.MaxDate = DateTime.Now.AddDays(buyDays-1);
            //地区选择文本框事件
            txtFrom.TextChanged += new EventHandler(TextChangeEvent);
            txtFrom.Leave += new EventHandler(TextLeaveEvent);
            txtFrom.KeyUp += new KeyEventHandler(KeyUpEvent);
            txtTo.TextChanged += new EventHandler(TextChangeEvent);
            txtTo.Leave += new EventHandler(TextLeaveEvent);
            txtTo.KeyUp += new KeyEventHandler(KeyUpEvent);
            //车型复选框事件
            chkTrainClassQB.CheckedChanged += new EventHandler(chkTrainClassQB_CheckedChanged);
            for (int i = 0; i < chkTrainClassQB.Parent.Controls.Count; i++)
            {
                CheckBox cbox = chkTrainClassQB.Parent.Controls[i] as CheckBox;
                if (cbox.Tag.ToString() != "QB")
                {
                    cbox.CheckedChanged += new EventHandler(TrainClassCheckdEvent);
                }
            }
            //席别复选框事件
            for (int i = 0; i < plSeatType.Controls.Count; i++)
            {
                CheckBox cbox = plSeatType.Controls[i] as CheckBox;
                cbox.CheckedChanged += new EventHandler(SeatTypeCheckdEvent);
            }
            //加载用户上一次查询的出发地和目的地
            if (!string.IsNullOrEmpty(StaticValues.MyUser.LastQueryFromStation) && !string.IsNullOrEmpty(StaticValues.MyUser.LastQueryToStation))
            {
                change = true;
                List<Station> stationList = StaticValues.StationList;
                Station fromStation = stationList.Find(s => s.Name == StaticValues.MyUser.LastQueryFromStation);
                txtFrom.Tag = fromStation.Code;
                txtFrom.Text = fromStation.Name;
                Station toStation = stationList.Find(s => s.Name == StaticValues.MyUser.LastQueryToStation);
                txtTo.Tag = toStation.Code;
                txtTo.Text = toStation.Name;
                change = false;
                qe.from_station_telecode = fromStation.Code;
                qe.from_station_telecode_name = fromStation.Name;
                qe.to_station_telecode_name = toStation.Name;
                qe.to_station_telecode = toStation.Code;
            }
            startTime1.Items.Clear();
            startTime2.Items.Clear();
            for (int i = 0; i <= 24; i++)
            {
                string t=i<10?"0"+i+":00":i+":00";
                startTime1.Items.Add(t);
                startTime2.Items.Add(t);
            }
            //出发时间
            this.startTime1.SelectedIndex = 0;
            this.startTime2.SelectedIndex = this.startTime2.Items.Count - 1;
            chkUserOcr.Checked = StaticValues.UserOcr;
            //初始化qe
            qe.train_date = startDate.Value.ToString("yyyy-MM-dd");
            qe.start_time_str = "00:00--24:00";
            qe.trainClass = "QB#D#Z#T#K#QT#";
            qe.seatTypeList = seatTypeList;
        }
        #endregion

        #region 地区输入框文本改变的事件
        private void TextChangeEvent(object sender, EventArgs e)
        {
            TextBox tbox = sender as TextBox;
            if (!tbox.Parent.Controls.Contains(lboxCity))
            {
                lboxCity = new ListBox();
                lboxCity.Visible = false;
                lboxCity.Click += new EventHandler(lboxCity_Click);
                tbox.Parent.Controls.Add(lboxCity);
            }
            if (!change)
            {
                tbox.Tag = null;
                string key = tbox.Text.Trim().ToLower();
                if (key != "")
                {
                    List<Station> stationList = StaticValues.StationList;
                    List<Station> filterList = stationList.FindAll(p => p.ShortName.Contains(key) || p.ShortName1.Contains(key) || p.FullName.Contains(key) || p.Name.Contains(key));
                    if (filterList.Count > 0)
                    {
                        lboxCity.DisplayMember = "Name";
                        lboxCity.ValueMember = "Code";
                        lboxCity.DataSource = filterList;
                        Point p1 = tbox.Location;
                        lboxCity.Location = new Point(p1.X, p1.Y + tbox.Height + 4);
                        lboxCity.Width = tbox.Width + 12;
                        lboxCity.Show();
                        lboxCity.Tag = sender;
                        lboxCity.BringToFront();
                    }

                }
            }
        }
        #endregion

        #region  地区输入框离开的事件
        private void TextLeaveEvent(object sender, EventArgs e)
        {
            if (this.ActiveControl.GetType().Name != "ListBox")
            {
                if (this.lboxCity != null)
                {
                    this.lboxCity.Hide();
                }
            }
            TextBox tb = sender as TextBox;
            if (tb.Tag == null)
            {
                tb.Text = "";
            }
        }
        #endregion

        #region 选择城市
        void DoCitySelect(object sender)
        {
            TextBox tbox = sender as TextBox;
            string name = lboxCity.Text;
            string value = lboxCity.SelectedValue.ToString();
            tbox.Text = name;
            tbox.Tag = value;
            if (tbox.Name == txtFrom.Name)//出发地
            {
                qe.from_station_telecode = value;
                qe.from_station_telecode_name = name;
                txtTo.Focus();

            }
            else
            {
                qe.to_station_telecode = value;
                qe.to_station_telecode_name = name;
                startDate.Focus();

            }
            this.lboxCity.Visible = false;
        }
        #endregion

        #region 地区选择列表框点击选择城市
        private void lboxCity_Click(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            DoCitySelect(listBox.Tag);
        }
        #endregion

        #region 地区输入框按键释放的事件
        private void KeyUpEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (lboxCity.SelectedIndex > 0)
                {
                    lboxCity.SelectedIndex -= 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (lboxCity.SelectedIndex < lboxCity.Items.Count - 1)
                {
                    lboxCity.SelectedIndex += 1;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                DoCitySelect(sender);
            }
        }
        #endregion

        #region 获取系统时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStatusBarTime.Text = DateTime.Now.ToString();
        }
        #endregion

        #region 座位全选事件
        private void chkSeatType_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.plSeatType.Controls.Count; i++)
            {
                CheckBox chkBox = this.plSeatType.Controls[i] as CheckBox;
                chkBox.Checked = chkSeatType.Checked;
            }
        }
        #endregion

        #region 席别选择的事件
        private void SeatTypeCheckdEvent(object sender, EventArgs e)
        {
            seatTypeList.Clear();
            for (int i = 0; i < plSeatType.Controls.Count; i++)
            {
                CheckBox cbox = plSeatType.Controls[i] as CheckBox;
                if (cbox.Checked)
                {
                    seatTypeList.Add(cbox.Tag.ToString());
                }
            }
            //当选择硬座的时候加上无座
            //if (seatTypeList.Contains("YingZuo"))
            //{
            //    seatTypeList.Add("WuZuo");
            //}
            qe.seatTypeList = seatTypeList;

        }
        #endregion

        #region 车型选择的事件
        private void chkTrainClassQB_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkBox = sender as CheckBox;
            for (int i = 0; i < chkBox.Parent.Controls.Count; i++)
            {
                CheckBox cbox = chkBox.Parent.Controls[i] as CheckBox;
                if (cbox.Tag.ToString() != "QB")
                {
                    cbox.CheckedChanged -= new EventHandler(TrainClassCheckdEvent);
                    cbox.Checked = chkBox.Checked;
                    cbox.CheckedChanged += new EventHandler(TrainClassCheckdEvent);
                }
            }
            qe.trainClass = chkBox.Checked ? "QB#D#Z#T#K#QT#" : "";
        }
        private void TrainClassCheckdEvent(object sender, EventArgs e)
        {
            CheckBox _cbox = sender as CheckBox;
            CheckBox _cboxQB = null;
            int checkedCnt = 0;
            for (int i = 0; i < _cbox.Parent.Controls.Count; i++)
            {
                CheckBox cbox = _cbox.Parent.Controls[i] as CheckBox;
                if (cbox.Tag.ToString() == "QB")
                {
                    _cboxQB = cbox;
                }
                else
                {
                    if (cbox.Tag.ToString() != "QB" && cbox.Checked)
                    {
                        checkedCnt++;
                    }
                }
            }
            if (_cbox.Checked && checkedCnt == _cbox.Parent.Controls.Count - 1)
            {
                _cboxQB.CheckedChanged -= new EventHandler(chkTrainClassQB_CheckedChanged);
                _cboxQB.Checked = true;
                _cboxQB.CheckedChanged += new EventHandler(chkTrainClassQB_CheckedChanged);
            }
            else if (!_cbox.Checked)
            {
                _cboxQB.CheckedChanged -= new EventHandler(chkTrainClassQB_CheckedChanged);
                _cboxQB.Checked = false;
                _cboxQB.CheckedChanged += new EventHandler(chkTrainClassQB_CheckedChanged);
            }
            string trainClass = string.Empty;
            for (int i = _cbox.Parent.Controls.Count - 1; i >= 0; i--)
            {
                CheckBox cbox = _cbox.Parent.Controls[i] as CheckBox;
                if (cbox.Checked)
                {
                    trainClass = trainClass + cbox.Tag + "#";
                }
            }
            qe.trainClass = trainClass;
        }
        #endregion

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (txtTo.Tag != null && txtFrom.Tag != null)
            {
                if (mp3 != null)
                    mp3.Stop();
                if (autoBuyFlag)
                {
                    //string cheCi = txtCheCi.Text.Trim();
                    if (myList.Count > 0)
                    {
                        Thread t = new Thread(() => DoQuery());
                        t.IsBackground = true;
                        t.Start();
                    }
                    else
                    {
                        MessageBox.Show("你必须选择至少一名乘客才能开启自动提交！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Thread t = new Thread(() => DoQuery());
                    t.IsBackground = true;
                    t.Start();
                }
            }
            else
            {
                if (txtFrom.Tag == null)
                {
                    this.toolTip1.ToolTipIcon = ToolTipIcon.Error;
                    this.toolTip1.Show("请输入正确的出发地！", txtFrom, txtFrom.Location.X - 65, txtFrom.Location.Y + 15, 1500);
                    txtFrom.Clear();
                    txtFrom.Focus();
                }
                else
                {
                    this.toolTip1.ToolTipIcon = ToolTipIcon.Error;
                    this.toolTip1.Show("请输入正确的目的地！", txtTo, txtTo.Location.X - 240, txtTo.Location.Y + 15, 1500);
                    txtTo.Clear();
                    txtTo.Focus();
                }
            }
        }

        #region 开始查询
        private void DoQuery()
        {
            qe.optionDates.Clear();
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                for (int i = 0; i < this.plSelectDates.Controls.Count; i++)
                {
                    LinkLabel ll = this.plSelectDates.Controls[i] as LinkLabel;
                    string date = ll.Text;
                    if (!qe.optionDates.Contains(date))
                    {
                        qe.optionDates.Add(date);
                    }
                }

            }));
            DataTable dt = null;
            do
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new MethodInvoker(delegate()
                    {
                        this.btnQuery.Enabled = false;
                        this.lbLoding.BringToFront();
                        this.lbLoding.Visible = true;
                        this.plNoTicket.Hide();

                    }));
                }
                dt = TicketHelper.GetLeftTicket(ref qe);
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    this.lbLoding.Visible = false;
                    dgTicket.DataSource = dt;
                    dgTicket.ClearSelection();
                    lbQueryInfo.Text =qe.from_station_telecode_name+"-->"+qe.to_station_telecode_name+"（"+qe.train_date+"  "+Common.GetWeekDay(Convert.ToDateTime(qe.train_date))+"）共计"+dt.Rows.Count+"个车次";          
                    if (dt.Rows.Count == 0)
                    {
                        this.plNoTicket.Show();
                        this.plNoTicket.Location = this.lbLoding.Location;
                    }
                }));
                if (dt.Rows.Count > 0)
                {
                    if (!autoBuyFlag)
                    {
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke(new MethodInvoker(delegate()
                            {
                                //保存
                                UserManager.SaveUserInfo(StaticValues.MyUser.UserName, StaticValues.MyUser.Pwd, qe.from_station_telecode_name, qe.to_station_telecode_name);
                                mp3 = new Mp3Helper();
                                mp3.FileName = "succes.mp3";
                                mp3.Play();
                                TipForm tf = new TipForm("恭喜你，有票了，赶快去预订吧！", "有票了");
                                tf.Show();
                            }));
                        }
                    }
                    else
                    {
                        
                        AutoBuyTipForm atf = new AutoBuyTipForm(dt,qe,myList);
                        atf.ShowDialog();
                    }
                }
                ControlQueryRate(timeSpan);
            }
            while (autoFlag&&dt.Rows.Count==0);
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                btnQuery.Enabled = true;
            }));
        }
        #endregion


        #region 控制查询频率
        private void ControlQueryRate(int second)
        {
            float time = 0;
            while (true)
            {
                Thread.Sleep(100);
                time = time + 0.1f;
                if (time >= second)
                {
                    if (this.InvokeRequired)
                    {
                        this.BeginInvoke(new MethodInvoker(delegate()
                        {
                            btnQuery.Text = "查 询(&Q)";
                            btnQuery.Enabled = true;
                        }));
                    }
                    break;
                }
                else
                {
                    if (this.InvokeRequired)
                    {
                        string leftSecond = (second - time).ToString("0.0");
                        this.BeginInvoke(new MethodInvoker(delegate() { btnQuery.Text = leftSecond + "秒"; }));
                    }
                }
            }
        }
        #endregion

        #region 日期增加减少事件
        private void pbSub_Click(object sender, EventArgs e)
        {
            if (this.startDate.Value > this.startDate.MinDate)
            {
                this.startDate.Value = this.startDate.Value.AddDays(-1);
            }
        }
        private void pbAdd_Click(object sender, EventArgs e)
        {
            if (this.startDate.Value.ToString("yyyyMMdd") != this.startDate.MaxDate.ToString("yyyyMMdd"))
            {
                this.startDate.Value = this.startDate.Value.AddDays(1);
            }
        }
        #endregion

        #region 出发日期和时间事件
        private void startDate_ValueChanged(object sender, EventArgs e)
        {
           string date = startDate.Value.ToString("yyyy-MM-dd");
           qe.train_date=date;
        }
        private void startTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startTime1.SelectedIndex > -1)
            {
                qe.start_time_str = startTime1.Text+"--"+startTime2.Text;
            }
        }
        #endregion

        #region 格式化查询表格
        private void dgTicket_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewCell cellFirst = dgTicket.Rows[rowIndex].Cells["colFirst"];
            DataGridViewCell cellLast = dgTicket.Rows[rowIndex].Cells["colLast"];
            DataGridViewCell cellOrderKey = dgTicket.Rows[e.RowIndex].Cells["OrderKey"];
            string orderKey = cellOrderKey.Value.ToString();
            if (orderKey == "")
            {
                DataGridViewLinkCell cellOrder = dgTicket.Rows[e.RowIndex].Cells["colOrder"] as DataGridViewLinkCell;
                cellOrder.LinkColor = Color.Black;
                cellOrder.ActiveLinkColor = Color.Black;
                cellOrder.LinkBehavior = LinkBehavior.NeverUnderline;
            }
            if (cellFirst.Value.ToString() == "True")
            {
                dgTicket.Rows[rowIndex].Cells["colStartStation"].Style.ForeColor = Color.Red;
                if (!dgTicket.Rows[rowIndex].Cells["colStartStation"].Value.ToString().Contains("[始]"))
                {
                    dgTicket.Rows[rowIndex].Cells["colStartStation"].Value = "[始]" + dgTicket.Rows[rowIndex].Cells["colStartStation"].Value;
                }
            }
            if (cellLast.Value.ToString() == "True")
            {
                dgTicket.Rows[rowIndex].Cells["colAimStation"].Style.ForeColor = Color.Red;
                if (!dgTicket.Rows[rowIndex].Cells["colAimStation"].Value.ToString().Contains("[终]"))
                {
                    dgTicket.Rows[rowIndex].Cells["colAimStation"].Value = "[终]" + dgTicket.Rows[rowIndex].Cells["colAimStation"].Value;
                }
            }
            for (int j = 4; j < 15; j++)
            {
                string value = dgTicket.Rows[rowIndex].Cells[j].Value.ToString();
                if (Common.IsNumeric(value) || value.IndexOf("有") > -1)
                {
                    dgTicket.Rows[rowIndex].Cells[j].Style.ForeColor = Color.Green;
                    dgTicket.Rows[rowIndex].Cells[j].Style.Font = new Font("宋体", 9, FontStyle.Bold | FontStyle.Underline);
                }
            }
        }
        #endregion

        #region 查询表格双击事件
        private void dgTicket_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null)
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgv.SelectedRows[0];
                    DataGridViewCell cellOrderKey = row.Cells["OrderKey"];
                    string orderKey = cellOrderKey.Value.ToString();
                    if (orderKey == "")
                    {
                        MessageBox.Show("该车次的票已经卖完了,不能预订！","无票", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.dgTicket.Enabled = false;
                        Thread t = new Thread(() => DoPrevOrder(orderKey));
                        t.IsBackground = true;
                        t.Start();
                    }

                }
            }

        }
        #endregion

        #region 预定
        private void DoPrevOrder(string orderyKey)
        {
            string msg=string.Empty;
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    this.lbLoding.BringToFront();
                    this.lbLoding.Visible = true;
                }));
            }
            TicketInfo ti = null;
            if (!this.IsDisposed)
            {
                ti = TicketHelper.GetTicketInfo(orderyKey, qe, ref msg);
            }
            Action finishAction = () =>
            {
                this.dgTicket.Enabled = true;
                this.lbLoding.Visible = false;
                if (ti != null)
                {
                    OrderForm of = new OrderForm(ti);
                    of.ShowDialog(this);
                }
                else
                {
                    if (msg != "")
                    {
                        if (msg.Contains("您还有未处理的订单"))
                        {
                            msg = "您还有未处理的订单,请处理完后再订票！";
                        }
                        MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        msg = "获取车次预订信息失败！";
                    }
                }
            };
            this.BeginInvoke(finishAction);
        }

        #endregion

        #region 格式化列车时刻表格
        private void dgTrainDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cellIsEnabled = dgTrainDetails.Rows[e.RowIndex].Cells["colIsEnabled"];
            if (cellIsEnabled.Value.ToString() == "False")
            {
                dgTrainDetails.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
            }
            else
            {
                dgTrainDetails.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }
        #endregion

        #region 鼠标离开列表时刻表格时的事件
        private void dgTrainDetails_Leave(object sender, EventArgs e)
        {
            dgTrainDetails.Hide();
        }
        #endregion
       

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出购票助手吗?", "退出系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void 切换账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要切换账号吗?", "切换账号", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
        }

        private void chkAutoQuery_CheckedChanged(object sender, EventArgs e)
        {
            autoFlag = chkAutoQuery.Checked;
        }

        private void dgTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgTicket.Rows.Count > 0)
            {
                if (e.ColumnIndex == 0 && e.RowIndex > -1)//加载车次信息
                {
                    string trainCodeKey = dgTicket.Rows[e.RowIndex].Cells["colTrainCodeKey"].Value.ToString();
                    string[] array = trainCodeKey.Split("#".ToCharArray());
                    string train_no = array[0];
                    string start_station = array[1];
                    string aim_station = array[2];
                    string date = this.startDate.Value.ToString("yyyy-MM-dd");
                    List<TrainDetails> list = TicketHelper.GetTrainDetails(train_no, start_station, aim_station, date);
                    dgTrainDetails.DataSource = list;
                    Point pTrainDetails = new Point();
                    pTrainDetails.X = dgTicket.Location.X + (dgTicket.Width - dgTrainDetails.Width) / 2;
                    pTrainDetails.Y = dgTicket.Location.Y + (dgTicket.Height - dgTrainDetails.Height) / 2;
                    dgTrainDetails.Location = pTrainDetails;
                    dgTrainDetails.Visible = true;
                    dgTrainDetails.Focus();
                }
                if (dgTicket.Columns[e.ColumnIndex].Name == "colOrder")
                {
                    //点击预定
                    DataGridViewCell cellOrderKey = dgTicket.Rows[e.RowIndex].Cells["OrderKey"];
                    string orderKey = cellOrderKey.Value.ToString();
                    if (orderKey != "")
                    {
                        this.dgTicket.Enabled = false;
                        Thread t = new Thread(() => DoPrevOrder(orderKey));
                        t.IsBackground = true;
                        t.Start();
                    }
                }
            }
        }

        private void pbAddPassenger_Click(object sender, EventArgs e)
        {
            SelectPassengerForm sf = new SelectPassengerForm(this);
            sf.ShowDialog(this);
        }
        public void LoadPassenger()
        {
            this.plPassenger.Controls.Clear();
            int btnX = 2;
            int margin = 0;
            Font f = this.Font;
            Graphics g = this.plPassenger.CreateGraphics();
            for (int i = 0; i < myList.Count; i++)
            {
                LinkLabel lnkPassenger = new LinkLabel();
                lnkPassenger.LinkBehavior = LinkBehavior.NeverUnderline;
                string passengerName = myList[i].passenger_name;
                lnkPassenger.Text = passengerName;
                lnkPassenger.Name = "lnkPassenger" + i;
                lnkPassenger.Location = new Point(btnX, 3);
                lnkPassenger.Font = f;
                lnkPassenger.ForeColor = Color.DarkOliveGreen;
                lnkPassenger.FlatStyle = FlatStyle.Flat;
                g.PageUnit = GraphicsUnit.Display;
                int leng = Convert.ToInt32(g.MeasureString(passengerName, f).Width) + 10;
                lnkPassenger.Size = new Size(leng, 30);
                btnX = btnX + margin + leng;
                this.plPassenger.Controls.Add(lnkPassenger);
            }
        }
        public void LoadDates()
        {
            this.plSelectDates.Controls.Clear();
            int btnX = 2;
            int margin = 0;
            Font f = this.Font;
            Graphics g = this.plSelectDates.CreateGraphics();
            for (int i = 0; i < myDateList.Count; i++)
            {
                LinkLabel lnkDate = new LinkLabel();
                lnkDate.LinkBehavior = LinkBehavior.NeverUnderline;
                string date = myDateList[i];
                lnkDate.Text = date;
                lnkDate.Name = "lnkDate" + i;
                lnkDate.Location = new Point(btnX, 3);
                lnkDate.Font = f;
                lnkDate.ForeColor = Color.DarkOliveGreen;
                lnkDate.FlatStyle = FlatStyle.Flat;
                g.PageUnit = GraphicsUnit.Display;
                int leng = Convert.ToInt32(g.MeasureString(date, f).Width) + 10;
                lnkDate.Size = new Size(leng, 30);
                btnX = btnX + margin + leng;
                this.plSelectDates.Controls.Add(lnkDate);
            }
        }
        public void LoadTrainClass()
        {
            qe.trainNoList = trainNoList;
            this.plTrainClass.Controls.Clear();
            int btnX = 2;
            int margin = 0;
            Font f = this.Font;
            Graphics g = this.plTrainClass.CreateGraphics();
            for (int i = 0; i < trainNoList.Count; i++)
            {
                LinkLabel lnkTrainNo = new LinkLabel();
                lnkTrainNo.Click += lnkTrainNo_Click;
                lnkTrainNo.LinkBehavior = LinkBehavior.NeverUnderline;
                string trainNo = trainNoList[i];
                lnkTrainNo.Text = trainNo;
                lnkTrainNo.Name = "lnkTrainNo" + i;
                lnkTrainNo.Location = new Point(btnX, 3);
                lnkTrainNo.Font = f;
                lnkTrainNo.ForeColor = Color.DarkOliveGreen;
                lnkTrainNo.FlatStyle = FlatStyle.Flat;
                g.PageUnit = GraphicsUnit.Display;
                int leng = Convert.ToInt32(g.MeasureString(trainNo, f).Width) + 10;
                lnkTrainNo.Size = new Size(leng, 30);
                btnX = btnX + margin + leng;
                this.plTrainClass.Controls.Add(lnkTrainNo);
            }
        }

        void lnkTrainNo_Click(object sender, EventArgs e)
        {
            LinkLabel ll=sender as  LinkLabel;
            string trainNo=ll.Text.Trim();
            if (trainNoList.Contains(trainNo))
            {
                trainNoList.Remove(trainNo);
            }
            LoadTrainClass();

        }
        private void pbSelectDates_Click(object sender, EventArgs e)
        {
            SelectDateForm sf = new SelectDateForm(this);
            sf.ShowDialog(this);
        }

        private void txtCheCi_TextChanged(object sender, EventArgs e)
        {
            //qe.trainNoList = txtCheCi.Text.ToUpper().Replace("，", ",").Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        #region 保持登陆状态
        private void KeyLoginState()
        {
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    HttpClient client = new HttpClient(StaticValues.MyCookies);
                    string html = client.Get("https://kyfw.12306.cn/otn/index/initMy12306");
                    toolStatusBarSys.Text = "已刷新登陆状态," + DateTime.Now.AddMinutes(5).ToString() + "再次刷新！";
                    Thread.Sleep(1000 * 60 * 5);//每5分钟检测一次
                }
            });
            t.IsBackground = true;
            t.Start();
        }
        #endregion
        private void btnOpenInIE_Click(object sender, EventArgs e)
        {
            string url = "https://kyfw.12306.cn/otn";
            IEHelper.SetCookie2IE(url);
            IEHelper.OpenInIE(url);
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            buyDays = Convert.ToInt32(numericUpDown1.Value);
            toolStatusBarMsg.Text = "今天可以售[" + DateTime.Now.AddDays(buyDays - 1).ToString("yyyy-MM-dd") + "]日车票";
            //出发日期
            this.startDate.MinDate = DateTime.Now;
            this.startDate.MaxDate = DateTime.Now.AddDays(buyDays);
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            timeSpan = Convert.ToInt32(numericUpDown2.Value);
        }

        private void chkSelectCanDo_CheckedChanged(object sender, EventArgs e)
        {
            chkAutoQuery.Checked = false;
            btnQuery_Click(null, null);
        }

        private void pbAddTrainClass_Click(object sender, EventArgs e)
        {
            SelectTrainClassForm sf = new SelectTrainClassForm(this,qe);
            sf.ShowDialog(this);
        }

        private void chkUserOcr_CheckedChanged(object sender, EventArgs e)
        {
            StaticValues.UserOcr = chkUserOcr.Checked;
        }

        private void startTime2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startTime2.SelectedIndex > -1)
            {
                qe.start_time_str = startTime1.Text + "--" + startTime2.Text;
            }
        }
    }
}

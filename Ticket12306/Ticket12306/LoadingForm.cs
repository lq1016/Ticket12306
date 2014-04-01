using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Ticket12306.Resx;
using Waner8.Common;
using Ticket12306.Service.Utility;


namespace Ticket12306
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }
        private void WriteLog(string msg)
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                lbMsg.Text = msg;
            }));
        }
        private void InitData()
        {
            Thread t = new Thread(() =>
            {
                WriteLog("正在加载账号信息...");
                //检测账号配置信息
                if (!File.Exists(UserManager.userDataFile))
                {
                    FileStream fs = new FileStream(UserManager.userDataFile, FileMode.CreateNew);
                    fs.Close();
                }
                List<UserInfo> list = UserManager.GetUsers();
                StaticValues.MyUserList = list;
                Thread.Sleep(500);
                //系统启动的时候加载验证码识别模块
                WriteLog("正在加载核心模块...");
                Thread.Sleep(500);
                InitVcCode();
                WriteLog("正在加载出发地和目的地信息...");
                Thread.Sleep(500);
                LoadCity();
                WriteLog("系统初始化完毕...");
                Thread.Sleep(500);
                this.DialogResult = DialogResult.OK;

            });
            t.IsBackground = true;
            t.Start();
        }
        private void LoadCity()
        {
            List<Station> stationList = new List<Station>();
            stationList = JsonHelper.FromJson<List<Station>>(Files.StationsJson);
            StaticValues.StationList = stationList;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Images.Bg;
            InitData();
        }

        private void InitVcCode()
        {

            //初始化字模
            StaticValues.CodeList = new List<CodeEntity>();
            string[] charList0 = Files.VcCode0.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in charList0)
            {
                string[] array = line.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string charStr = array[0];
                string guiyicode = array[1];
                StaticValues.CodeList0.Add(new CodeEntity { CharStr = charStr, GuiyiCode = guiyicode });
            }



            //初始化字模
            StaticValues.CodeList = new List<CodeEntity>();
            string[] charList = Files.VcCode.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in charList)
            {
                string[] array = line.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string charStr = array[0];
                string guiyicode = array[1];
                StaticValues.CodeList.Add(new CodeEntity { CharStr = charStr, GuiyiCode = guiyicode });
            }

            //初始化字模
            StaticValues.CodeList1 = new List<CodeEntity>();
            string[] charList1 = Files.VcCode1.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in charList1)
            {
                string[] array = line.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string charStr = array[0];
                string guiyicode = array[1];
                StaticValues.CodeList1.Add(new CodeEntity { CharStr = charStr, GuiyiCode = guiyicode });
            }

            //初始化字模
            StaticValues.CodeList2 = new List<CodeEntity>();
            string[] charList2 = Files.VcCode2.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in charList2)
            {
                string[] array = line.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string charStr = array[0];
                string guiyicode = array[1];
                StaticValues.CodeList2.Add(new CodeEntity { CharStr = charStr, GuiyiCode = guiyicode });
            }

            //初始化字模
            StaticValues.CodeList3 = new List<CodeEntity>();
            string[] charList3 = Files.VcCode3.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in charList3)
            {
                string[] array = line.Split("\t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string charStr = array[0];
                string guiyicode = array[1];
                StaticValues.CodeList3.Add(new CodeEntity { CharStr = charStr, GuiyiCode = guiyicode });
            }

        }
    }
}

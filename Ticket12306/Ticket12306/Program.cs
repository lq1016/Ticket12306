using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using Waner8.Common;
using System.IO;

namespace Ticket12306
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //删除老版本文件
                string[] oldFiles = { "Common.dll", "GlassButton.dll", "TicketHelper.exe" };
                foreach (string str in oldFiles)
                {
                    if (File.Exists(str))
                        File.Delete(str);
                }
                string checkUpdateUrl = "http://waner8.sinaapp.com/Update.txt";
                HttpClient client = new HttpClient();
                FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(System.Windows.Forms.Application.ExecutablePath);
                client.TimeOut = 5000;
                string json = client.Get(checkUpdateUrl);
                bool exit = false;
                if (json != "")
                {
                    if (json != "timeout")
                    {
                        UpdateInfo ui = JsonHelper.FromJson<UpdateInfo>(json);
                        if (ui.NewVersion != myFileVersion.FileVersion)
                        {
                            exit = true;
                        }
                    }
                }
                if (exit)
                {
                    json = json.Replace("\"", "'");
                    Process.Start("AutoUpdater.exe", json);
                    Application.Exit();
                }
                else
                {
                    LoadingForm lf = new LoadingForm();
                    if (lf.ShowDialog() == DialogResult.OK)
                    {
                        LoginForm l = new LoginForm();
                        if (l.ShowDialog() == DialogResult.OK)
                        {
                            Application.Run(new MainForm());
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = "";
                string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
                if (ex != null)
                {
                    str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                         ex.GetType().Name, ex.Message, ex.StackTrace);
                }
                else
                {
                    str = string.Format("应用程序线程错误:{0}", ex);
                }

                writeLog(str);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {

            string str = "";
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            Exception error = e.Exception as Exception;
            if (error != null)
            {
                str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                     error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("应用程序线程错误:{0}", e);
            }

            writeLog(str);

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = "";
            Exception error = e.ExceptionObject as Exception;
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            if (error != null)
            {
                str = string.Format(strDateInfo + "Application UnhandledException:{0};\n\r堆栈信息:{1}", error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("Application UnhandledError:{0}", e);
            }

            writeLog(str);
           
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="str"></param>
        static void writeLog(string str)
        {
            if (!Directory.Exists("ErrLog"))
            {
                Directory.CreateDirectory("ErrLog");
            }

            using (StreamWriter sw = new StreamWriter(@"ErrLog\ErrLog.txt", true))
            {
                sw.WriteLine(str);
                sw.WriteLine("---------------------------------------------------------");
                sw.Close();
            }
        }
    }
    public class UpdateInfo
    {
        public string OldVersion { get; set; }
        public string NewVersion { get; set; }
        public string ExcuteName { get; set; }
        public string UpdateContent { get; set; }
        public List<string> FileList { get; set; }
        public string RootUrl { get; set; }
        public string ExcuteFileName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace AutoUpdater
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
                UpdateInfo ui = jsonSerializer.Deserialize<UpdateInfo>(args[0]);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main(ui));
            }
            else
                Application.Exit();
          
        }
       
      
    }
}

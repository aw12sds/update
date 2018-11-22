using NetWork.util;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using update.view;

namespace update
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            getData.getiprouter();
            if (getData.ifping("10.15.1.252"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new downloadexe());
            }
            else if (getData.ifping("47.97.210.239"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new downloadexe());
            }
           


        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using NetWorkLib.Net;
using NetWorkLib;
using NetWorkLib.util;

namespace update.view
{
    public partial class downloadexe : DevExpress.XtraEditors.XtraForm
    {
        string pathfilesave = "";
        public downloadexe()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        public void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            getdevice getdevice = new getdevice();
            string filename = System.Environment.CurrentDirectory + "\\update.zip";
            if (getdevice.unpress(filename).Equals("下载完毕"))
            {
                System.Diagnostics.Process.Start("ztoffice.exe");
                System.Environment.Exit(0);
            }
            
        }
        public void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBarX1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBarX1.Value = (int)e.BytesReceived / 100;
            progressBarX1.Text = e.ProgressPercentage.ToString() + "%";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void downloadexe_Load(object sender, EventArgs e)
        {


            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            version version = new version();
            String versionnum = version.getversion("zttofficeyasou");
            pathfilesave = System.Environment.CurrentDirectory + "\\update.zip";
            String url = "http://" + MyGlobal.ip + ":8080/ZttErp/zttCodeversionController/getZttCodeversion?fileName=zttofficeyasou";
            client.DownloadFileAsync(new Uri(url), pathfilesave);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using RestSharp;
using RestSharp.Extensions;
using System.Text.RegularExpressions;
using System.Web;

namespace CVPNSync
{
    public partial class Form1 : Form
    {
        private static string syncLocalFolder = "";
        private static string userName = "";
        private static string passWord = "";
        private static string shareVolumeName = "";
        private static string private2021VolumeName = "";
        private static string[] extensionsList = new string[] { };
        private static string[] headsList = new string[] { };
        private static bool autoLogin = false;
        private static bool autoForceSync = false;
        private static bool autoRealTimeSync = false;
        private static bool autoIntervalSync = false;
        private static bool autoMinimized = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            syncLocalFolder = Properties.Settings.Default.syncLocalFolder;
            userName = Properties.Settings.Default.userName;
            passWord = Properties.Settings.Default.passWord;
            shareVolumeName = Properties.Settings.Default.shareVolumeName;
            private2021VolumeName = Properties.Settings.Default.private2021VolumeName;
            extensionsList = Properties.Settings.Default.extensionsList.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            headsList = Properties.Settings.Default.headsList.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            autoLogin = Properties.Settings.Default.autoLogin;
            autoForceSync = Properties.Settings.Default.autoForceSync;
            autoRealTimeSync = Properties.Settings.Default.autoRealTimeSync;
            autoIntervalSync = Properties.Settings.Default.autoIntervalSync;
            autoMinimized = Properties.Settings.Default.autoMinimized;
            syncLocalFolderLabel.Text = "同期するローカルフォルダ : " + syncLocalFolder;
            userNameTextBox.Text = userName;
            passWordTextBox.Text = passWord;
            shareVolumeTextBox.Text = shareVolumeName;
            privateVolumeTextBox.Text = private2021VolumeName;
            extensionsTextBox.Text = String.Join(Environment.NewLine, extensionsList);
            headsTextBox.Text = String.Join(Environment.NewLine, headsList);
            launchCheckedListBox.SetItemChecked(0, autoLogin);
            launchCheckedListBox.SetItemChecked(1, autoForceSync);
            launchCheckedListBox.SetItemChecked(2, autoRealTimeSync);
            launchCheckedListBox.SetItemChecked(3, autoIntervalSync);
            launchCheckedListBox.SetItemChecked(4, autoMinimized);
            realTimeSyncFileSystemWatcher.Path = syncLocalFolder;
            realTimeSyncFileSystemWatcher.SynchronizingObject = this;
        }

        private void forceSyncBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            realTimeSyncFileSystemWatcher.EnableRaisingEvents = false;
            SyncDirectory(syncLocalFolder, "\\");
            realTimeSyncFileSystemWatcher.EnableRaisingEvents = true;
        }

        private void SyncDirectory(string localDirectory, string vpnDirectory)
        {
            WriteConsole("SyncDirectory " + localDirectory + " " + vpnDirectory);
            if (!Directory.Exists(localDirectory))
            {
                WriteConsole("CreateDirectory " + localDirectory);
                Directory.CreateDirectory(localDirectory);
            }
            if (vpnDirectory[vpnDirectory.Length - 1] != '\\')
            {
                vpnDirectory += @"\";
            }
            WriteConsole("GetVpnDirectory " + vpnDirectory);
            List<string> checkedFilePaths = new List<string> { };
            List<CVPNClass.VpnListInfo> vpnListInfos = CVPNClass.List(vpnDirectory, private2021VolumeName);
            foreach (CVPNClass.VpnListInfo vpnListInfo in vpnListInfos.Where(s => s.listCategory == "ファイル"))
            {
                string localFilePath = localDirectory + @"\" + Path.GetFileName(vpnListInfo.listName);
                if (!CheckSkipFile(localFilePath))
                {
                    WriteConsole("SkipFile " + vpnDirectory + vpnListInfo.listName);
                }
                else
                {
                    WriteConsole("CheckFile " + vpnDirectory + vpnListInfo.listName);
                    if (!File.Exists(localFilePath) || File.GetLastWriteTime(localFilePath) < vpnListInfo.listDateTime)
                    {
                        WriteConsole("DownloadFile " + vpnDirectory + vpnListInfo.listName + " " + localFilePath);
                        FileStream fileStream = new FileStream(localFilePath, FileMode.Create, FileAccess.Write);
                        byte[] downloadByte = CVPNClass.Download(vpnDirectory + vpnListInfo.listName, localDirectory, private2021VolumeName);
                        fileStream.Write(downloadByte, 0, downloadByte.Length);
                        fileStream.Close();
                    }
                }
                checkedFilePaths.Add(vpnListInfo.listName);
            }
            foreach (string localFileName in Array.ConvertAll(Directory.GetFiles(localDirectory), (s => Path.GetFileName(s))).Except(checkedFilePaths))
            {
                string localFilePath = localDirectory + @"\" + localFileName;
                if (!CheckSkipFile(localFilePath))
                {
                    WriteConsole("SkipFile " + localFilePath);
                }
                else
                {
                    WriteConsole("UploadFile " + localFilePath + " " + vpnDirectory + localFileName);
                    WriteDebug(CVPNClass.Upload(vpnDirectory, localFilePath, private2021VolumeName));
                }
            }
            foreach (CVPNClass.VpnListInfo vpnListInfo in vpnListInfos.Where(s => s.listCategory == "フォルダ"))
            {
                SyncDirectory(localDirectory +@"\"+ vpnListInfo.listName, vpnDirectory + vpnListInfo.listName);
            }
        }

        void WriteConsole(string logLine)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke
                ((MethodInvoker)delegate () { WriteConsole(logLine); });
                return;
            }
            consoleTextBox.Text += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff") + "   " + logLine + Environment.NewLine;
        }

        void WriteDebug(string logLine)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke
                ((MethodInvoker)delegate () { WriteDebug(logLine); });
                return;
            }
            debugTextBox.Text += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss fff") + "   " + logLine + Environment.NewLine;
        }

        private void forceSyncTimer_Tick(object sender, EventArgs e)
        {
            WriteConsole("ForceSync");
            forceSyncBackgroundWorker.RunWorkerAsync();
        }

        private void realTimeSyncFileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            string localFilePath = e.FullPath;
            if (!CheckSkipFile(localFilePath))
            {
                WriteConsole("SkipFile " + localFilePath);
                return;
            }
            string vpnFilePath = localFilePath.Replace(syncLocalFolder, "");
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Changed:
                    WriteConsole("ChangeFile " + localFilePath);
                    WriteConsole("UploadFile " + localFilePath + " " + vpnFilePath);
                    WriteDebug(CVPNClass.Upload(vpnFilePath, localFilePath, private2021VolumeName));
                    break;
                case WatcherChangeTypes.Created:
                    WriteConsole("UploadFile " + localFilePath + " " + vpnFilePath);
                    WriteDebug(CVPNClass.Upload(vpnFilePath, localFilePath, private2021VolumeName));
                    break;
                case WatcherChangeTypes.Deleted:
                    WriteConsole("DeleteFile " + localFilePath + " " + vpnFilePath);
                    WriteDebug(CVPNClass.Delete(vpnFilePath.Substring(1), private2021VolumeName));
                    break;
            }
        }

        private void realTimeSyncFileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            string localFilePath = e.FullPath;
            string vpnFilePath = localFilePath.Replace(Path.GetDirectoryName(syncLocalFolder), "");
            string localOldFilePath = e.OldFullPath;
            string vpnOldFilePath = localOldFilePath.Replace(Path.GetDirectoryName(syncLocalFolder), "");
            WriteConsole("RenameFile " + localOldFilePath + " " + localFilePath);
            if (!CheckSkipFile(localFilePath))
            {
                WriteConsole("SkipFile " + localOldFilePath);
            }
            else
            {
                WriteConsole("DeleteFile " + localOldFilePath + " " + vpnOldFilePath);
                WriteDebug(CVPNClass.Delete(vpnOldFilePath, private2021VolumeName));
            }
            if (!CheckSkipFile(localFilePath))
            {
                WriteConsole("SkipFile " + localFilePath);
            }
            else
            {
                WriteConsole("UploadFile " + localFilePath + " " + vpnFilePath);
                WriteDebug(CVPNClass.Upload(vpnFilePath, localFilePath, private2021VolumeName));
            }
        }

        private bool CheckSkipFile(string localFilePath)
        {
            if (extensionsList.Contains(Path.GetExtension(localFilePath).ToLower()))
            {
                return false;
            }
            foreach (string head in headsList)
            {
                if (Path.GetFileNameWithoutExtension(localFilePath).Substring(0, head.Length) == head)
                {
                    return false;
                }
            }
            return true;
        }

        private void syncLocalFolderButton_Click(object sender, EventArgs e)
        {
            if (syncLocalFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                syncLocalFolder = syncLocalFolderBrowserDialog.SelectedPath;
                realTimeSyncFileSystemWatcher.Path = syncLocalFolder;
                syncLocalFolderLabel.Text = "同期するローカルフォルダ : " + syncLocalFolder;
            }
        }

        private void forceSyncButton_Click(object sender, EventArgs e)
        {
            if (!forceSyncBackgroundWorker.IsBusy)
            {
                WriteConsole("ForceSync");
                forceSyncBackgroundWorker.RunWorkerAsync();
            }
        }

        private void realTimeSyncButton_Click(object sender, EventArgs e)
        {
            realTimeSyncFileSystemWatcher.EnableRaisingEvents = !realTimeSyncFileSystemWatcher.EnableRaisingEvents;
            if (realTimeSyncFileSystemWatcher.EnableRaisingEvents)
            {
                realTimeSyncButton.Text = "リアルタイム同期をオフにする";
            }
            else
            {
                realTimeSyncButton.Text = "リアルタイム同期をオンにする";
            }
        }

        private void timerSyncButton_Click(object sender, EventArgs e)
        {
            forceSyncTimer.Enabled = !forceSyncTimer.Enabled;
            if (forceSyncTimer.Enabled)
            {
                timerSyncButton.Text = "インターバル同期をオフにする";
            }
            else
            {
                timerSyncButton.Text = "インターバル同期をオンにする";
            }
        }


        private void applyButton_Click(object sender, EventArgs e)
        {
            userName = userNameTextBox.Text;
            passWord = passWordTextBox.Text;
            shareVolumeName = shareVolumeTextBox.Text;
            private2021VolumeName = privateVolumeTextBox.Text;
            extensionsList = extensionsTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            headsList = headsTextBox.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            autoLogin = launchCheckedListBox.GetItemChecked(0);
            autoForceSync = launchCheckedListBox.GetItemChecked(1);
            autoRealTimeSync = launchCheckedListBox.GetItemChecked(2);
            autoIntervalSync = launchCheckedListBox.GetItemChecked(3);
            autoMinimized = launchCheckedListBox.GetItemChecked(4);
            Properties.Settings.Default.syncLocalFolder = syncLocalFolder;
            Properties.Settings.Default.userName = userName;
            Properties.Settings.Default.passWord = passWord;
            Properties.Settings.Default.shareVolumeName = shareVolumeName;
            Properties.Settings.Default.private2021VolumeName = private2021VolumeName;
            Properties.Settings.Default.extensionsList = String.Join(Environment.NewLine, extensionsList);
            Properties.Settings.Default.headsList = String.Join(Environment.NewLine, headsList);
            Properties.Settings.Default.autoLogin = autoLogin;
            Properties.Settings.Default.autoForceSync = autoForceSync;
            Properties.Settings.Default.autoRealTimeSync = autoRealTimeSync;
            Properties.Settings.Default.autoIntervalSync = autoIntervalSync;
            Properties.Settings.Default.autoMinimized = autoMinimized;
            Properties.Settings.Default.Save();
            CVPNClass.userName = userName;
            CVPNClass.passWord = passWord;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            CVPNClass.userName = userName;
            CVPNClass.passWord = passWord;
            WriteConsole("Login");
            WriteDebug(CVPNClass.Login());
        }

        private void clearConsoleButton_Click(object sender, EventArgs e)
        {
            consoleTextBox.Clear();
        }

        private void clearDebugButton_Click(object sender, EventArgs e)
        {
            debugTextBox.Clear();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
                notifyIcon.Visible = true;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Visible = false;
            if (autoLogin)
            {
                loginButton_Click(null, null);
            }
            if (autoForceSync)
            {
                forceSyncButton_Click(null, null);
            }
            if (autoRealTimeSync)
            {
                realTimeSyncButton_Click(null, null);
            }
            if (autoIntervalSync)
            {
                timerSyncButton_Click(null, null);
            }
            if (!autoMinimized)
            {
                Visible = true;
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = true;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", syncLocalFolder);
        }

        private void formToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Dispose();
            Application.Exit();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", syncLocalFolder);
        }
    }

    public class CVPNClass
    {
        public static RestClient restClient = new RestClient();
        public static RestRequest restRequest = new RestRequest();
        public static string userName = "";
        public static string passWord = "";

        public static string Login()
        {
            restClient.CookieContainer = new System.Net.CookieContainer();
            restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana-na/auth/url_3/login.cgi");
            restRequest.Method = Method.POST;
            restRequest.AddParameter("tz_offset", "540");
            restRequest.AddParameter("username", userName);
            restRequest.AddParameter("password", passWord);
            restRequest.AddParameter("realm", "Student-Realm");
            restRequest.AddParameter("btnSubmit", "Sign In");
            IRestResponse restResponse = restClient.Execute(restRequest);
            if (restResponse.Content.Contains("Continue will result in termination of the other session.  Please select from one of the following options:"))
            {
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(restResponse.Content);
                string FormDataStr = htmlDocument.GetElementbyId("DSIDFormDataStr").Attributes["value"].Value;
                restRequest = new RestRequest();
                restRequest.Method = Method.POST;
                restRequest.AddParameter("btnContinue", "セッションを続行します");
                restRequest.AddParameter("FormDataStr", FormDataStr);
                restResponse = restClient.Execute(restRequest);
            }
            return restResponse.Content;
        }

        public static List<VpnListInfo> List(string vpnPath, string volumeName)
        {
            restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana/fb/smb/wfb.cgi?t=p&v=" + volumeName + "&si=0&ri=0&pi=0&sb=name&so=asc&dir=" + vpnPath);
            restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            IRestResponse restResponse = restClient.Execute(restRequest);
            if (restResponse.Content.Contains("The page you requested could not be found.") || restResponse.Content.Contains("You are logged out because you have logged in from another machine"))
            {
                Login();
                restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana/fb/smb/wfb.cgi?t=p&v=" + volumeName + "&si=0&ri=0&pi=0&sb=name&so=asc&dir=" + vpnPath);
                restRequest = new RestRequest();
                restRequest.Method = Method.GET;
                restResponse = restClient.Execute(restRequest);
            }
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(restResponse.Content);
            string scriptLines = HttpUtility.UrlDecode(htmlDocument.GetElementbyId("table_wfb_5").SelectSingleNode("script").InnerHtml.Trim());
            StringReader stringReader = new StringReader(scriptLines);
            List<VpnListInfo> vpnListInfos = new List<VpnListInfo> { };
            while (stringReader.Peek() > -1)
            {
                string scriptLine = Regex.Replace(stringReader.ReadLine(), @"<[^>]+>|&nbsp;", "").Trim();
                string listCategory = scriptLine.Substring(0, 1);
                scriptLine = scriptLine.Substring(2);
                scriptLine = scriptLine.Substring(0, scriptLine.Length - 2);
                Regex regex = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                string[] listArray = regex.Split(scriptLine);
                listArray = Array.ConvertAll(listArray, s => s.Trim('"'));
                string dateTimeFormat = "ddd MMM d HH:mm:ss yyyy";
                switch (listCategory)
                {
                    case "d":
                        if (listArray[2].Substring(8, 1) == " ")
                        {
                            dateTimeFormat = "ddd MMM  d HH:mm:ss yyyy";
                        }
                        else
                        {
                            dateTimeFormat = "ddd MMM d HH:mm:ss yyyy";
                        }
                        vpnListInfos.Add(new VpnListInfo { listName = listArray[0], listCategory = "フォルダ", listDateTime = DateTime.ParseExact(listArray[2], dateTimeFormat, new CultureInfo("en-US", false)), listSize = "" });
                        break;
                    case "f":
                        if (listArray[3].Substring(8, 1) == " ")
                        {
                            dateTimeFormat = "ddd MMM  d HH:mm:ss yyyy";
                        }
                        else
                        {
                            dateTimeFormat = "ddd MMM d HH:mm:ss yyyy";
                        }
                        vpnListInfos.Add(new VpnListInfo { listName = listArray[0], listCategory = "ファイル", listDateTime = DateTime.ParseExact(listArray[3], dateTimeFormat, new CultureInfo("en-US", false)), listSize = listArray[2] });
                        break;
                }
            }
            return vpnListInfos;
        }

        public static byte[] Download(string vpnPath, string localPath, string volumeName)
        {
            string vpnFileName = Path.GetFileName(vpnPath);
            string vpnFolderPath = Path.GetDirectoryName(vpnPath);
            vpnFolderPath = vpnFolderPath.Substring(1);
            if (localPath == "")
            {
                localPath = vpnFileName;
            }
            restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana/download/" + vpnFileName + "?url=/dana-cached/fb/smb/wfv.cgi?t=p&v=" + volumeName + "&si=0&ri=0&pi=0&ignoreDfs=1&dir=" + vpnFolderPath + "&file=" + vpnFileName);
            restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            return restClient.DownloadData(restRequest);
        }

        public static string Delete(string vpnPath, string volumeName)
        {
            restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana/fb/smb/wu.cgi");
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.AddParameter("v", volumeName);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(restClient.Execute(restRequest).Content);
            string xsauth = htmlDocument.GetElementbyId("xsauth_386").Attributes["value"].Value;
            restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana/fb/smb/wfb.cgi");
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.AddParameter("xsauth", xsauth);
            restRequest.AddParameter("btnSubmit", "はい");
            restRequest.AddParameter("acttype", "delete");
            restRequest.AddParameter("confirm", "yes");
            restRequest.AddParameter("t", "p");
            restRequest.AddParameter("v", volumeName);
            restRequest.AddParameter("si", "");
            restRequest.AddParameter("ri", "");
            restRequest.AddParameter("pi", "");
            restRequest.AddParameter("dir", Path.GetDirectoryName(vpnPath));
            restRequest.AddParameter("files", vpnPath);
            restRequest.AddParameter("ignoreDfs", "1");
            return restClient.Execute(restRequest).Content;
        }

        public static string Create(string vpnPath,string folderName, string volumeName)
        {
            restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana/fb/smb/wu.cgi");
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.AddParameter("v", volumeName);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(restClient.Execute(restRequest).Content);
            string xsauth = htmlDocument.GetElementbyId("xsauth_386").Attributes["value"].Value;
            restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana/fb/smb/wnf.cgi");
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.AddParameter("xsauth", xsauth);
            restRequest.AddParameter("folder", folderName);
            restRequest.AddParameter("create", "フォルダの作成");
            restRequest.AddParameter("action", "create");
            restRequest.AddParameter("t", "p");
            restRequest.AddParameter("v", volumeName);
            restRequest.AddParameter("si", "");
            restRequest.AddParameter("ri", "");
            restRequest.AddParameter("pi", "");
            restRequest.AddParameter("dir", vpnPath);
            restRequest.AddParameter("ignoreDfs", "1");
            restRequest.AddParameter("confirm", "yes");
            return restClient.Execute(restRequest).Content;
        }

        public static string Upload(string vpnPath, string localPath, string volumeName)
        {
            restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana/fb/smb/wu.cgi");
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.AddParameter("v", volumeName);
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(restClient.Execute(restRequest).Content);
            string xsauth = htmlDocument.GetElementbyId("xsauth_386").Attributes["value"].Value;
            string trackid = htmlDocument.GetElementbyId("trackid_1").Attributes["value"].Value;
            restClient.BaseUrl = new Uri("https://vpn.inf.shizuoka.ac.jp/dana/fb/smb/wu.cgi");
            restRequest = new RestRequest();
            restRequest.Method = Method.POST;
            restRequest.AddHeader("Content-Type", "multipart/form-data");
            restRequest.AddParameter("xsauth", xsauth);
            restRequest.AddParameter("txtServerUploadID", "");
            restRequest.AddParameter("trackid", trackid);
            restRequest.AddParameter("t", "p");
            restRequest.AddParameter("v", volumeName);
            restRequest.AddParameter("si", "0");
            restRequest.AddParameter("ri", "0");
            restRequest.AddParameter("pi", "0");
            restRequest.AddParameter("dir", vpnPath);
            restRequest.AddParameter("acttype", "upload");
            restRequest.AddParameter("confirm", "yes");
            restRequest.AddParameter("ignoreDfs", "1");
            if (File.Exists(localPath))
            {
                restRequest.AddFile("file1", localPath);
                return restClient.Execute(restRequest).Content;
            }
            else
            {
                return "File does not exist.";
            }
        }

        public class VpnListInfo
        {
            public string listName { get; set; }
            public DateTime listDateTime { get; set; }
            public string listCategory { get; set; }
            public string listSize { get; set; }
        }

        private static DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        public static long GetUnixTime(DateTime targetTime)
        {
            targetTime = targetTime.ToUniversalTime();
            TimeSpan elapsedTime = targetTime - UNIX_EPOCH;
            return (long)elapsedTime.TotalMilliseconds;
        }
    }
}


namespace CVPNSync
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.forceSyncBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.realTimeSyncFileSystemWatcher = new System.IO.FileSystemWatcher();
            this.forceSyncTimer = new System.Windows.Forms.Timer(this.components);
            this.syncLocalFolderLabel = new System.Windows.Forms.Label();
            this.syncLocalFolderButton = new System.Windows.Forms.Button();
            this.syncLocalFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.forceSyncButton = new System.Windows.Forms.Button();
            this.realTimeSyncButton = new System.Windows.Forms.Button();
            this.timerSyncButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.consoleTabPage = new System.Windows.Forms.TabPage();
            this.debugTabPage = new System.Windows.Forms.TabPage();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.headsTextBox = new System.Windows.Forms.TextBox();
            this.extensionsTextBox = new System.Windows.Forms.TextBox();
            this.headLabel = new System.Windows.Forms.Label();
            this.extensionLabel = new System.Windows.Forms.Label();
            this.launchCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.launchLabel = new System.Windows.Forms.Label();
            this.clearDebugButton = new System.Windows.Forms.Button();
            this.clearConsoleButton = new System.Windows.Forms.Button();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.privateVolumeTextBox = new System.Windows.Forms.TextBox();
            this.privateVolumeLabel = new System.Windows.Forms.Label();
            this.shareVolumeTextBox = new System.Windows.Forms.TextBox();
            this.shareVolumeLabel = new System.Windows.Forms.Label();
            this.accountLabel = new System.Windows.Forms.Label();
            this.passWordTextBox = new System.Windows.Forms.TextBox();
            this.passWordLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.realTimeSyncFileSystemWatcher)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.consoleTabPage.SuspendLayout();
            this.debugTabPage.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Location = new System.Drawing.Point(6, 6);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleTextBox.Size = new System.Drawing.Size(740, 341);
            this.consoleTextBox.TabIndex = 0;
            // 
            // forceSyncBackgroundWorker
            // 
            this.forceSyncBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.forceSyncBackgroundWorker_DoWork);
            // 
            // realTimeSyncFileSystemWatcher
            // 
            this.realTimeSyncFileSystemWatcher.IncludeSubdirectories = true;
            this.realTimeSyncFileSystemWatcher.NotifyFilter = ((System.IO.NotifyFilters)((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName) 
            | System.IO.NotifyFilters.LastWrite) 
            | System.IO.NotifyFilters.LastAccess)));
            this.realTimeSyncFileSystemWatcher.SynchronizingObject = this;
            this.realTimeSyncFileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.realTimeSyncFileSystemWatcher_Changed);
            this.realTimeSyncFileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.realTimeSyncFileSystemWatcher_Changed);
            this.realTimeSyncFileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.realTimeSyncFileSystemWatcher_Changed);
            this.realTimeSyncFileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.realTimeSyncFileSystemWatcher_Renamed);
            // 
            // forceSyncTimer
            // 
            this.forceSyncTimer.Interval = 60000;
            this.forceSyncTimer.Tick += new System.EventHandler(this.forceSyncTimer_Tick);
            // 
            // syncLocalFolderLabel
            // 
            this.syncLocalFolderLabel.AutoSize = true;
            this.syncLocalFolderLabel.Location = new System.Drawing.Point(12, 17);
            this.syncLocalFolderLabel.Name = "syncLocalFolderLabel";
            this.syncLocalFolderLabel.Size = new System.Drawing.Size(121, 12);
            this.syncLocalFolderLabel.TabIndex = 1;
            this.syncLocalFolderLabel.Text = "同期するローカルフォルダ";
            // 
            // syncLocalFolderButton
            // 
            this.syncLocalFolderButton.Location = new System.Drawing.Point(620, 12);
            this.syncLocalFolderButton.Name = "syncLocalFolderButton";
            this.syncLocalFolderButton.Size = new System.Drawing.Size(150, 23);
            this.syncLocalFolderButton.TabIndex = 2;
            this.syncLocalFolderButton.Text = "フォルダを選択";
            this.syncLocalFolderButton.UseVisualStyleBackColor = true;
            this.syncLocalFolderButton.Click += new System.EventHandler(this.syncLocalFolderButton_Click);
            // 
            // syncLocalFolderBrowserDialog
            // 
            this.syncLocalFolderBrowserDialog.Description = "同期するローカルフォルダを選択してください。";
            // 
            // forceSyncButton
            // 
            this.forceSyncButton.Location = new System.Drawing.Point(218, 41);
            this.forceSyncButton.Name = "forceSyncButton";
            this.forceSyncButton.Size = new System.Drawing.Size(180, 23);
            this.forceSyncButton.TabIndex = 3;
            this.forceSyncButton.Text = "強制的に同期する";
            this.forceSyncButton.UseVisualStyleBackColor = true;
            this.forceSyncButton.Click += new System.EventHandler(this.forceSyncButton_Click);
            // 
            // realTimeSyncButton
            // 
            this.realTimeSyncButton.Location = new System.Drawing.Point(404, 41);
            this.realTimeSyncButton.Name = "realTimeSyncButton";
            this.realTimeSyncButton.Size = new System.Drawing.Size(180, 23);
            this.realTimeSyncButton.TabIndex = 4;
            this.realTimeSyncButton.Text = "リアルタイム同期をオンにする";
            this.realTimeSyncButton.UseVisualStyleBackColor = true;
            this.realTimeSyncButton.Click += new System.EventHandler(this.realTimeSyncButton_Click);
            // 
            // timerSyncButton
            // 
            this.timerSyncButton.Location = new System.Drawing.Point(590, 41);
            this.timerSyncButton.Name = "timerSyncButton";
            this.timerSyncButton.Size = new System.Drawing.Size(180, 23);
            this.timerSyncButton.TabIndex = 5;
            this.timerSyncButton.Text = "インターバル同期をオンにする";
            this.timerSyncButton.UseVisualStyleBackColor = true;
            this.timerSyncButton.Click += new System.EventHandler(this.timerSyncButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.consoleTabPage);
            this.tabControl1.Controls.Add(this.debugTabPage);
            this.tabControl1.Controls.Add(this.settingsTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 379);
            this.tabControl1.TabIndex = 6;
            // 
            // consoleTabPage
            // 
            this.consoleTabPage.Controls.Add(this.consoleTextBox);
            this.consoleTabPage.Location = new System.Drawing.Point(4, 22);
            this.consoleTabPage.Name = "consoleTabPage";
            this.consoleTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.consoleTabPage.Size = new System.Drawing.Size(752, 353);
            this.consoleTabPage.TabIndex = 0;
            this.consoleTabPage.Text = "コンソール";
            this.consoleTabPage.UseVisualStyleBackColor = true;
            // 
            // debugTabPage
            // 
            this.debugTabPage.Controls.Add(this.debugTextBox);
            this.debugTabPage.Location = new System.Drawing.Point(4, 22);
            this.debugTabPage.Name = "debugTabPage";
            this.debugTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.debugTabPage.Size = new System.Drawing.Size(752, 353);
            this.debugTabPage.TabIndex = 1;
            this.debugTabPage.Text = "デバッグ";
            this.debugTabPage.UseVisualStyleBackColor = true;
            // 
            // debugTextBox
            // 
            this.debugTextBox.Location = new System.Drawing.Point(6, 6);
            this.debugTextBox.Multiline = true;
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.ReadOnly = true;
            this.debugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.debugTextBox.Size = new System.Drawing.Size(740, 341);
            this.debugTextBox.TabIndex = 1;
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Controls.Add(this.headsTextBox);
            this.settingsTabPage.Controls.Add(this.extensionsTextBox);
            this.settingsTabPage.Controls.Add(this.headLabel);
            this.settingsTabPage.Controls.Add(this.extensionLabel);
            this.settingsTabPage.Controls.Add(this.launchCheckedListBox);
            this.settingsTabPage.Controls.Add(this.launchLabel);
            this.settingsTabPage.Controls.Add(this.clearDebugButton);
            this.settingsTabPage.Controls.Add(this.clearConsoleButton);
            this.settingsTabPage.Controls.Add(this.volumeLabel);
            this.settingsTabPage.Controls.Add(this.privateVolumeTextBox);
            this.settingsTabPage.Controls.Add(this.privateVolumeLabel);
            this.settingsTabPage.Controls.Add(this.shareVolumeTextBox);
            this.settingsTabPage.Controls.Add(this.shareVolumeLabel);
            this.settingsTabPage.Controls.Add(this.accountLabel);
            this.settingsTabPage.Controls.Add(this.passWordTextBox);
            this.settingsTabPage.Controls.Add(this.passWordLabel);
            this.settingsTabPage.Controls.Add(this.userNameTextBox);
            this.settingsTabPage.Controls.Add(this.userNameLabel);
            this.settingsTabPage.Controls.Add(this.applyButton);
            this.settingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTabPage.Size = new System.Drawing.Size(752, 353);
            this.settingsTabPage.TabIndex = 2;
            this.settingsTabPage.Text = "設定";
            this.settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // headsTextBox
            // 
            this.headsTextBox.Location = new System.Drawing.Point(352, 80);
            this.headsTextBox.Multiline = true;
            this.headsTextBox.Name = "headsTextBox";
            this.headsTextBox.Size = new System.Drawing.Size(120, 160);
            this.headsTextBox.TabIndex = 19;
            // 
            // extensionsTextBox
            // 
            this.extensionsTextBox.Location = new System.Drawing.Point(226, 80);
            this.extensionsTextBox.Multiline = true;
            this.extensionsTextBox.Name = "extensionsTextBox";
            this.extensionsTextBox.Size = new System.Drawing.Size(120, 160);
            this.extensionsTextBox.TabIndex = 18;
            // 
            // headLabel
            // 
            this.headLabel.AutoSize = true;
            this.headLabel.Location = new System.Drawing.Point(350, 65);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(65, 12);
            this.headLabel.TabIndex = 17;
            this.headLabel.Text = "ヘッダー設定";
            // 
            // extensionLabel
            // 
            this.extensionLabel.AutoSize = true;
            this.extensionLabel.Location = new System.Drawing.Point(224, 65);
            this.extensionLabel.Name = "extensionLabel";
            this.extensionLabel.Size = new System.Drawing.Size(65, 12);
            this.extensionLabel.TabIndex = 15;
            this.extensionLabel.Text = "拡張子設定";
            // 
            // launchCheckedListBox
            // 
            this.launchCheckedListBox.FormattingEnabled = true;
            this.launchCheckedListBox.Items.AddRange(new object[] {
            "自動でログインする",
            "強制的に同期する",
            "リアルタイム同期をオンにする",
            "インターバル同期をオンにする",
            "最小化状態で起動する"});
            this.launchCheckedListBox.Location = new System.Drawing.Point(8, 80);
            this.launchCheckedListBox.Name = "launchCheckedListBox";
            this.launchCheckedListBox.Size = new System.Drawing.Size(210, 74);
            this.launchCheckedListBox.TabIndex = 14;
            // 
            // launchLabel
            // 
            this.launchLabel.AutoSize = true;
            this.launchLabel.Location = new System.Drawing.Point(6, 65);
            this.launchLabel.Name = "launchLabel";
            this.launchLabel.Size = new System.Drawing.Size(65, 12);
            this.launchLabel.TabIndex = 13;
            this.launchLabel.Text = "起動時設定";
            // 
            // clearDebugButton
            // 
            this.clearDebugButton.Location = new System.Drawing.Point(546, 295);
            this.clearDebugButton.Name = "clearDebugButton";
            this.clearDebugButton.Size = new System.Drawing.Size(200, 23);
            this.clearDebugButton.TabIndex = 12;
            this.clearDebugButton.Text = "デバッグをクリアする";
            this.clearDebugButton.UseVisualStyleBackColor = true;
            this.clearDebugButton.Click += new System.EventHandler(this.clearDebugButton_Click);
            // 
            // clearConsoleButton
            // 
            this.clearConsoleButton.Location = new System.Drawing.Point(546, 266);
            this.clearConsoleButton.Name = "clearConsoleButton";
            this.clearConsoleButton.Size = new System.Drawing.Size(200, 23);
            this.clearConsoleButton.TabIndex = 11;
            this.clearConsoleButton.Text = "コンソールをクリアする";
            this.clearConsoleButton.UseVisualStyleBackColor = true;
            this.clearConsoleButton.Click += new System.EventHandler(this.clearConsoleButton_Click);
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(224, 3);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(64, 12);
            this.volumeLabel.TabIndex = 10;
            this.volumeLabel.Text = "ドライブ設定";
            // 
            // privateVolumeTextBox
            // 
            this.privateVolumeTextBox.Location = new System.Drawing.Point(309, 43);
            this.privateVolumeTextBox.Name = "privateVolumeTextBox";
            this.privateVolumeTextBox.Size = new System.Drawing.Size(437, 19);
            this.privateVolumeTextBox.TabIndex = 9;
            // 
            // privateVolumeLabel
            // 
            this.privateVolumeLabel.AutoSize = true;
            this.privateVolumeLabel.Location = new System.Drawing.Point(224, 46);
            this.privateVolumeLabel.Name = "privateVolumeLabel";
            this.privateVolumeLabel.Size = new System.Drawing.Size(79, 12);
            this.privateVolumeLabel.TabIndex = 8;
            this.privateVolumeLabel.Text = "PrivateVolume";
            // 
            // shareVolumeTextBox
            // 
            this.shareVolumeTextBox.Location = new System.Drawing.Point(309, 18);
            this.shareVolumeTextBox.Name = "shareVolumeTextBox";
            this.shareVolumeTextBox.Size = new System.Drawing.Size(437, 19);
            this.shareVolumeTextBox.TabIndex = 7;
            // 
            // shareVolumeLabel
            // 
            this.shareVolumeLabel.AutoSize = true;
            this.shareVolumeLabel.Location = new System.Drawing.Point(224, 21);
            this.shareVolumeLabel.Name = "shareVolumeLabel";
            this.shareVolumeLabel.Size = new System.Drawing.Size(72, 12);
            this.shareVolumeLabel.TabIndex = 6;
            this.shareVolumeLabel.Text = "ShareVolume";
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Location = new System.Drawing.Point(6, 3);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(73, 12);
            this.accountLabel.TabIndex = 5;
            this.accountLabel.Text = "アカウント設定";
            // 
            // passWordTextBox
            // 
            this.passWordTextBox.Location = new System.Drawing.Point(68, 43);
            this.passWordTextBox.Name = "passWordTextBox";
            this.passWordTextBox.PasswordChar = '*';
            this.passWordTextBox.Size = new System.Drawing.Size(150, 19);
            this.passWordTextBox.TabIndex = 4;
            // 
            // passWordLabel
            // 
            this.passWordLabel.AutoSize = true;
            this.passWordLabel.Location = new System.Drawing.Point(6, 46);
            this.passWordLabel.Name = "passWordLabel";
            this.passWordLabel.Size = new System.Drawing.Size(54, 12);
            this.passWordLabel.TabIndex = 3;
            this.passWordLabel.Text = "Password";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(68, 18);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(150, 19);
            this.userNameTextBox.TabIndex = 2;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(6, 21);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(56, 12);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "Username";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(8, 324);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(738, 23);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "適用";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(12, 41);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(200, 23);
            this.loginButton.TabIndex = 7;
            this.loginButton.Text = "ログインする";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "CVPNSync";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.formToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(105, 70);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.openToolStripMenuItem.Text = "開く";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.formToolStripMenuItem.Text = "設定";
            this.formToolStripMenuItem.Click += new System.EventHandler(this.formToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.closeToolStripMenuItem.Text = "閉じる";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.timerSyncButton);
            this.Controls.Add(this.realTimeSyncButton);
            this.Controls.Add(this.forceSyncButton);
            this.Controls.Add(this.syncLocalFolderButton);
            this.Controls.Add(this.syncLocalFolderLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CVPNSync";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.realTimeSyncFileSystemWatcher)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.consoleTabPage.ResumeLayout(false);
            this.consoleTabPage.PerformLayout();
            this.debugTabPage.ResumeLayout(false);
            this.debugTabPage.PerformLayout();
            this.settingsTabPage.ResumeLayout(false);
            this.settingsTabPage.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox consoleTextBox;
        private System.ComponentModel.BackgroundWorker forceSyncBackgroundWorker;
        private System.IO.FileSystemWatcher realTimeSyncFileSystemWatcher;
        private System.Windows.Forms.Timer forceSyncTimer;
        private System.Windows.Forms.Label syncLocalFolderLabel;
        private System.Windows.Forms.Button syncLocalFolderButton;
        private System.Windows.Forms.FolderBrowserDialog syncLocalFolderBrowserDialog;
        private System.Windows.Forms.Button forceSyncButton;
        private System.Windows.Forms.Button realTimeSyncButton;
        private System.Windows.Forms.Button timerSyncButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage consoleTabPage;
        private System.Windows.Forms.TabPage debugTabPage;
        private System.Windows.Forms.TextBox debugTextBox;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox passWordTextBox;
        private System.Windows.Forms.Label passWordLabel;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.TextBox privateVolumeTextBox;
        private System.Windows.Forms.Label privateVolumeLabel;
        private System.Windows.Forms.TextBox shareVolumeTextBox;
        private System.Windows.Forms.Label shareVolumeLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button clearConsoleButton;
        private System.Windows.Forms.Button clearDebugButton;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label launchLabel;
        private System.Windows.Forms.CheckedListBox launchCheckedListBox;
        private System.Windows.Forms.Label extensionLabel;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.TextBox extensionsTextBox;
        private System.Windows.Forms.TextBox headsTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}


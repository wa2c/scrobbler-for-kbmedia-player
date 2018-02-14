using Lastfm.Scrobbling;
using NDde;
using ScrobblerForKbMediaPlayer.Entities;
using ScrobblerForKbMediaPlayer.Enums;
using ScrobblerForKbMediaPlayer.Utils;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;



namespace ScrobblerForKbMediaPlayer
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>監視サイクル.</summary>
        private const int cycleMilliseconds = 1000;
        /// <summary>現在読込まれているプロパティ情報.</summary>
        private PropertyData CurrentPropertyData { get; set; }
        /// <summary>Last.fm 管理.</summary>
        private LastFmManager lastFmManager;
        /// <summary>スタートアップのショートカットパス。</summary>
        string shortcutPath = Path.Combine(
            System.Environment.GetFolderPath(Environment.SpecialFolder.Startup),
            Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".lnk");



        /// <summary>
        /// コンストラクタ.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            if (DesignMode)
                return;

            this.Text = AppUtil.GetAppName();

            // Window位置
            if (Program.Settings.MainFormLocation != null)
            {
                Screen s = Screen.FromControl(this);
                Point p = Program.Settings.MainFormLocation;
                p.X = Math.Max(0, p.X);
                p.Y = Math.Max(0, p.Y);
                p.X = Math.Min(p.X, s.Bounds.Width  - this.RestoreBounds.Width);
                p.Y = Math.Min(p.Y, s.Bounds.Height - this.RestoreBounds.Height);
                this.Location = p;
            }

            // 認証
            this.lastFmManager = new LastFmManager();
            authenticate(false);

            if (!this.lastFmManager.Authenticated)
            {
                notifyIcon.ShowBalloonTip(
                    2000,
                    Properties.Resources.MessageAuthorizeFailedTitle,
                    Properties.Resources.MessageAuthorizeFailedText,
                    ToolTipIcon.Info
                    );
            }


            // サイクル
            this.bindingSource.DataSource = Program.Settings;
            this.backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// アプリケーション終了.
        /// </summary>
        private void ExitApplication()
        {
            backgroundWorker.CancelAsync();

            // Window位置
            if (this.WindowState == FormWindowState.Normal)
                Program.Settings.MainFormLocation = this.Bounds.Location;
            else
                Program.Settings.MainFormLocation = this.RestoreBounds.Location;

            Application.Exit();
        }

        /// <summary>
        /// ウィンドウ表示.
        /// </summary>
        private void ShowWindow()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// ウィンドウ非表示.
        /// </summary>
        private void HideWindow(bool saveSettings = true)
        {
            // Window位置
            if (this.WindowState == FormWindowState.Normal)
                Program.Settings.MainFormLocation = this.Bounds.Location;
            else
                Program.Settings.MainFormLocation = this.RestoreBounds.Location;

            WindowState = FormWindowState.Minimized;
            Hide();
            if (saveSettings)
            {
                Program.Settings.WriteXml();
            }
        }

        /// <summary>
        /// 認証登録.
        /// </summary>
        private void authenticate(bool useWeb = false)
        {
            string k = System.Security.Principal.WindowsIdentity.GetCurrent().User.ToString();
            bool authenticated = useWeb ? this.lastFmManager.AuthenticateWeb() : this.lastFmManager.AuthenticateKey(AppUtil.DecryptString(Program.Settings.LastFmSessionId, k));

            if (authenticated)
            {
                this.authStateLabel.Text = Properties.Resources.MessageAuthenticated;
                this.usernameTextBox.Text = this.lastFmManager.UserName;
                this.useIconPictureBox.Image = this.lastFmManager.UserImage;
                string sessionId = AppUtil.EncryptString(this.lastFmManager.SessionKey, k);
                if (!string.IsNullOrEmpty(sessionId))
                    Program.Settings.LastFmSessionId = sessionId;
            }
            else
            {
                if (string.IsNullOrEmpty(this.lastFmManager.SessionKey))
                    this.authStateLabel.Text = Properties.Resources.MessageAuthenticatedNot;
                else
                    this.authStateLabel.Text = Properties.Resources.MessageAuthenticatedFailed;
                this.usernameTextBox.Text = "";
                this.useIconPictureBox.Image = null;
            }
        }

        /// <summary>
        /// 認証解除
        /// </summary>
        private void logout()
        {
            this.lastFmManager.Logout();

            this.notifyLastfmUserPageToolStripMenuItem.Enabled = false;
            this.notifyScrobbleToolStripMenuItem.Enabled = false;
            this.notifyLoveToolStripMenuItem.Enabled = false;
            this.notifyUnloveToolStripMenuItem.Enabled = false;

            this.authStateLabel.Text = Properties.Resources.MessageAuthenticatedNot;
            this.usernameTextBox.Text = "";
            this.useIconPictureBox.Image = null;
            Program.Settings.LastFmSessionId = "";
        }



        #region Background process

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (KbMediaPlayerManager client = new KbMediaPlayerManager())
            {
                while (!backgroundWorker.CancellationPending)
                {
                    Thread.Sleep(1000);
                    try
                    {
                        client.Connect();
                        while (!backgroundWorker.CancellationPending)
                        {
                            var map = client.GetCurrentPropertyMap(false);
                            PropertyData data = new PropertyData(map);
                            backgroundWorker.ReportProgress(0, data);
                            if (map == null || map.Count == 0)
                                break; // 取得失敗している場合、再接続を行う
                            Thread.Sleep(cycleMilliseconds);
                        }

                    }
                    catch (DdeException ex)
                    {
                        client.Disconnect();
                        Debug.WriteLine(ex);
                    }
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PropertyData receivedData = e?.UserState as PropertyData;
            bool isChanged = ( (this.CurrentPropertyData != null && receivedData != null) && (!this.CurrentPropertyData.EqualsMedia(receivedData) || this.CurrentPropertyData.State != receivedData.State) )
                            || (this.CurrentPropertyData != null && receivedData == null)
                            || (this.CurrentPropertyData == null && receivedData != null);

            if (!isChanged)
                return;
            scrobbleTimer.Stop();

            // scrobble.
            if (Program.Settings.ScrobbleList.Count > 0)
            {
                lock (Program.Settings.ScrobbleList)
                {
                    if (Program.Settings.UseScrobble)
                    {
                        try
                        {
                            this.lastFmManager.Scrobble(Program.Settings.ScrobbleList);
                            Program.Settings.ScrobbleList.Clear();
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                        finally
                        {
                            Program.Settings.WriteXml(); // Scrobble時に設定保存
                        }
                    }
                }
            }

            // play start.
            if (receivedData != null && receivedData.State == KbMediaPlayState.Playing)
            {
                if (Program.Settings.UseUpdateNowPlaying)
                    try
                    {
                        lastFmManager.UpdateNowPlaying(receivedData);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }

                // start scrobble timer
                double timer = (receivedData.Milliseconds * Program.Settings.ScrobbleTimeRate) / 100;
                if (Program.Settings.UseScrobbleTimeSeconds)
                {
                    if (Program.Settings.ScrobbleTimeSeconds * 1000 < timer)
                        timer = Program.Settings.ScrobbleTimeSeconds * 1000;
                }
                timer = Math.Max(timer, 1000); // 最低1秒

                scrobbleTimer.Interval = (int)timer;
                scrobbleTimer.Start();
            }

            // menu update
            notifyStateToolStripMenuItem.Text = "STATE: " + receivedData?.State.ToString() ?? KbMediaPlayState.Stop.ToString();
            notifyTitleToolStripMenuItem.Enabled = !string.IsNullOrEmpty(receivedData?.Title);
            notifyTitleToolStripMenuItem.Text = "TITLE: " + receivedData?.Title ?? "";
            notifyArtistToolStripMenuItem.Enabled = !string.IsNullOrEmpty(receivedData?.Artist);
            notifyArtistToolStripMenuItem.Text = "ARTIST: " + receivedData?.Artist ?? "";
            notifyAlbumToolStripMenuItem.Enabled = !string.IsNullOrEmpty(receivedData?.Album);
            notifyAlbumToolStripMenuItem.Text = "ALBUM: " + receivedData?.Album ?? "";

            // notify update
            string text = AppUtil.GetAppName() + 
                ( (receivedData != null && (!string.IsNullOrEmpty(receivedData.Title) || !string.IsNullOrEmpty(receivedData.Artist))) ? (Environment.NewLine + receivedData.Title + " / " + receivedData.Artist) : "" );
            notifyIcon.Text = text.Substring(0, Math.Min(text.Length, 63));

            this.CurrentPropertyData = receivedData;
        }


        /// <summary>
        /// Scrobble 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scrobbleTimer_Tick(object sender, EventArgs e)
        {
            scrobbleTimer.Stop();
            if (this.CurrentPropertyData != null)
            {
                lock (Program.Settings.ScrobbleList)
                {
                    if (Program.Settings.UseScrobble)
                        Program.Settings.ScrobbleList.Add(this.CurrentPropertyData);
                }
            }
        }

        #endregion



        #region Event

        private void MainForm_Load(object sender, EventArgs e)
        {
            HideWindow(false);
            scrobbleTimeLabel.Text = scrobbleTimeRateTrackBar.Value.ToString();
            useScrobbleGroupBox.Enabled = useScrobbleCheckBox.Checked;
            scrobbleTimeSecondsNumericUpDown.Enabled = useScrobbleTimeSecondsCheckBox.Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }

            HideWindow();
        }



        private void authenticateButton_Click(object sender, EventArgs e)
        {
            authenticate(true);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            HideWindow();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, Properties.Resources.MessageConfirmExit, AppUtil.GetAppName(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ExitApplication();
        }




        private void scrobbleTimeRateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            scrobbleTimeLabel.Text = scrobbleTimeRateTrackBar.Value.ToString();
        }

        private void useScrobbleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            useScrobbleGroupBox.Enabled = useScrobbleCheckBox.Checked;
        }

        private void useScrobbleTimeSecondsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            scrobbleTimeSecondsNumericUpDown.Enabled = useScrobbleTimeSecondsCheckBox.Checked;
        }



        private void createStartupButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(shortcutPath))
            {
                if (MessageBox.Show(Properties.Resources.MessageStartupOverwrite, AppUtil.GetAppName(), MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
            }

            IWshRuntimeLibrary.WshShell shell = null;
            IWshRuntimeLibrary.IWshShortcut shortcut = null;
            try
            {
                shell = new IWshRuntimeLibrary.WshShell();
                shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.Save();
                MessageBox.Show(Properties.Resources.MessageStartupCreated, AppUtil.GetAppName());

            }
            finally
            {
                if (shortcut != null)
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shortcut);
                if (shell != null)
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shell);
            }
        }

        private void deleteStartupButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(shortcutPath))
            {
                if (MessageBox.Show(Properties.Resources.MessageStartupDelete, AppUtil.GetAppName(), MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;
                File.Delete(shortcutPath);
            }
            else
            {
                MessageBox.Show(Properties.Resources.MessageStartupNotExists, AppUtil.GetAppName());
            }
        }

        #endregion



        #region Notify icon

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible)
                HideWindow();
            else
                ShowWindow();
        }

        private void notifySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void notifyExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.MessageConfirmExit, AppUtil.GetAppName(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ExitApplication();
        }

        private void notifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Top Page
                if (sender == notifyLastfmTopPageToolStripMenuItem)
                {
                    lastFmManager.OpenTopPage();
                    return;
                }

                // User Page
                if (sender == notifyLastfmUserPageToolStripMenuItem)
                {
                    lastFmManager.OpenUserPage();
                    return;
                }

                PropertyData data = this.CurrentPropertyData;
                if (data != null)
                {
                    if (sender == notifyScrobbleToolStripMenuItem)
                    {
                        // Scrobble
                        lock (Program.Settings.ScrobbleList)
                        {
                            try
                            {
                                Program.Settings.ScrobbleList.Add(data);
                                bool succeeded = lastFmManager.Scrobble(Program.Settings.ScrobbleList);
                                if (succeeded)
                                {
                                    notifyIcon.ShowBalloonTip(
                                        2000,
                                        Properties.Resources.TitleNotificationScrobble,
                                        string.Format(Properties.Resources.FormatNotificationMessage, data.Title, data.Artist),
                                        ToolTipIcon.Info
                                        );
                                }
                                else
                                {
                                    notifyIcon.ShowBalloonTip(
                                        2000,
                                        Properties.Resources.TitleNotificationScrobbleFailed,
                                        string.Format(Properties.Resources.FormatNotificationMessage, data.Title, data.Artist),
                                        ToolTipIcon.Warning
                                        );
                                }
                            }
                            finally
                            {
                                Program.Settings.WriteXml(); // Scrobble時に設定保存
                                scrobbleTimer.Stop();
                            }
                        }
                    }
                    else if (sender == notifyLoveToolStripMenuItem)
                    {
                        // Love
                        bool succeeded = lastFmManager.Love(data);
                        if (succeeded)
                        {
                            notifyIcon.ShowBalloonTip(
                                2000,
                                Properties.Resources.TitleNotificationLove,
                                string.Format(Properties.Resources.FormatNotificationMessage, data.Title, data.Artist),
                                ToolTipIcon.Info
                                );
                        }
                        else
                        {
                            notifyIcon.ShowBalloonTip(
                               2000,
                                Properties.Resources.TitleNotificationLoveFailed,
                                string.Format(Properties.Resources.FormatNotificationMessage, data.Title, data.Artist),
                                ToolTipIcon.Warning
                                );
                        }
                    }
                    else if (sender == notifyUnloveToolStripMenuItem)
                    {
                        // Unlove
                        bool succeeded = lastFmManager.UnLove(data);
                        if (succeeded)
                        {
                            notifyIcon.ShowBalloonTip(
                                2000,
                                Properties.Resources.TitleNotificationUnlove,
                                string.Format(Properties.Resources.FormatNotificationMessage, data.Title, data.Artist),
                                ToolTipIcon.Info
                                );
                        }
                        else
                        {
                            notifyIcon.ShowBalloonTip(
                                2000,
                                Properties.Resources.TitleNotificationUnloveFailed,
                                string.Format(Properties.Resources.FormatNotificationMessage, data.Title, data.Artist),
                                ToolTipIcon.Warning
                                );
                        }
                    }
                    else if (sender == notifyTitleToolStripMenuItem)
                    {
                        // Track Page
                        lastFmManager.OpenTrackPage(data);
                    }
                    else if (sender == notifyArtistToolStripMenuItem)
                    {
                        // Artist Page
                        lastFmManager.OpenArtistPage(data);
                    }
                    else if (sender == notifyAlbumToolStripMenuItem)
                    {
                        // Album Page
                        lastFmManager.OpenAlbumPage(data);
                    }
                }
            }
            catch (Exception ex) when (ex is WebException || ex is TargetInvocationException)
            {
                notifyIcon.ShowBalloonTip(
                    2000,
                    Properties.Resources.ErrorTitle,
                    Properties.Resources.ErrorNetwork,
                    ToolTipIcon.Warning
                    );
            }
            catch (Exception ex) when (ex is Lastfm.Scrobbling.ScrobblingException || ex is Exception)
            {
                notifyIcon.ShowBalloonTip(
                    2000,
                    Properties.Resources.ErrorTitle,
                    Properties.Resources.ErrorApp,
                    ToolTipIcon.Warning
                    );
                // 送信に失敗した場合は現在の状態を保存
                Program.Settings.WriteXml();
            }

        }


        #endregion



    }
}

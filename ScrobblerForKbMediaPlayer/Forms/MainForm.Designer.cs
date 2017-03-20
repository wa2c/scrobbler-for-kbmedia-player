namespace ScrobblerForKbMediaPlayer
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifyLastfmTopPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyLastfmUserPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyArtistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyAlbumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyScrobbleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyLoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyUnloveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.notifySettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.useScrobbleGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scrobbleTimeRateLabel = new System.Windows.Forms.Label();
            this.scrobbleTimeLabel = new System.Windows.Forms.Label();
            this.useScrobbleTimeSecondsCheckBox = new System.Windows.Forms.CheckBox();
            this.scrobbleTimeRateTrackBar = new System.Windows.Forms.TrackBar();
            this.scrobbleTimeSecondsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.scrobbleTimeSecondsLabel = new System.Windows.Forms.Label();
            this.useScrobbleCheckBox = new System.Windows.Forms.CheckBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.useUpdateNowPlayingCheckBox = new System.Windows.Forms.CheckBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.authGroupBox = new System.Windows.Forms.GroupBox();
            this.logoutButton = new System.Windows.Forms.Button();
            this.useIconPictureBox = new System.Windows.Forms.PictureBox();
            this.authStateLabel = new System.Windows.Forms.Label();
            this.authenticateButton = new System.Windows.Forms.Button();
            this.scrobbleTimer = new System.Windows.Forms.Timer(this.components);
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.useScrobbleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrobbleTimeRateTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrobbleTimeSecondsNumericUpDown)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.authGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useIconPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Scrobbler for KbMedia Player";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifyLastfmTopPageToolStripMenuItem,
            this.notifyLastfmUserPageToolStripMenuItem,
            this.toolStripSeparator1,
            this.notifyStateToolStripMenuItem,
            this.notifyTitleToolStripMenuItem,
            this.notifyArtistToolStripMenuItem,
            this.notifyAlbumToolStripMenuItem,
            this.toolStripSeparator2,
            this.notifyScrobbleToolStripMenuItem,
            this.notifyLoveToolStripMenuItem,
            this.notifyUnloveToolStripMenuItem,
            this.toolStripSeparator3,
            this.notifySettingsToolStripMenuItem,
            this.notifyExitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(188, 352);
            // 
            // notifyLastfmTopPageToolStripMenuItem
            // 
            this.notifyLastfmTopPageToolStripMenuItem.Name = "notifyLastfmTopPageToolStripMenuItem";
            this.notifyLastfmTopPageToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifyLastfmTopPageToolStripMenuItem.Text = "Top Page";
            this.notifyLastfmTopPageToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // notifyLastfmUserPageToolStripMenuItem
            // 
            this.notifyLastfmUserPageToolStripMenuItem.Name = "notifyLastfmUserPageToolStripMenuItem";
            this.notifyLastfmUserPageToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifyLastfmUserPageToolStripMenuItem.Text = "User Page";
            this.notifyLastfmUserPageToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(184, 6);
            // 
            // notifyStateToolStripMenuItem
            // 
            this.notifyStateToolStripMenuItem.Enabled = false;
            this.notifyStateToolStripMenuItem.Name = "notifyStateToolStripMenuItem";
            this.notifyStateToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            // 
            // notifyTitleToolStripMenuItem
            // 
            this.notifyTitleToolStripMenuItem.Enabled = false;
            this.notifyTitleToolStripMenuItem.Name = "notifyTitleToolStripMenuItem";
            this.notifyTitleToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifyTitleToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // notifyArtistToolStripMenuItem
            // 
            this.notifyArtistToolStripMenuItem.Enabled = false;
            this.notifyArtistToolStripMenuItem.Name = "notifyArtistToolStripMenuItem";
            this.notifyArtistToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifyArtistToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // notifyAlbumToolStripMenuItem
            // 
            this.notifyAlbumToolStripMenuItem.Enabled = false;
            this.notifyAlbumToolStripMenuItem.Name = "notifyAlbumToolStripMenuItem";
            this.notifyAlbumToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifyAlbumToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // notifyScrobbleToolStripMenuItem
            // 
            this.notifyScrobbleToolStripMenuItem.Name = "notifyScrobbleToolStripMenuItem";
            this.notifyScrobbleToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifyScrobbleToolStripMenuItem.Text = "Scrobble(&S)";
            this.notifyScrobbleToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // notifyLoveToolStripMenuItem
            // 
            this.notifyLoveToolStripMenuItem.Name = "notifyLoveToolStripMenuItem";
            this.notifyLoveToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifyLoveToolStripMenuItem.Text = "Love(&L)";
            this.notifyLoveToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // notifyUnloveToolStripMenuItem
            // 
            this.notifyUnloveToolStripMenuItem.Name = "notifyUnloveToolStripMenuItem";
            this.notifyUnloveToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifyUnloveToolStripMenuItem.Text = "Unlove(&U)";
            this.notifyUnloveToolStripMenuItem.Click += new System.EventHandler(this.notifyToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // notifySettingsToolStripMenuItem
            // 
            this.notifySettingsToolStripMenuItem.Name = "notifySettingsToolStripMenuItem";
            this.notifySettingsToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifySettingsToolStripMenuItem.Text = "設定(&O)";
            this.notifySettingsToolStripMenuItem.Click += new System.EventHandler(this.notifySettingsToolStripMenuItem_Click);
            // 
            // notifyExitToolStripMenuItem
            // 
            this.notifyExitToolStripMenuItem.Name = "notifyExitToolStripMenuItem";
            this.notifyExitToolStripMenuItem.Size = new System.Drawing.Size(187, 30);
            this.notifyExitToolStripMenuItem.Text = "終了(&X)";
            this.notifyExitToolStripMenuItem.Click += new System.EventHandler(this.notifyExitToolStripMenuItem_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            // 
            // useScrobbleGroupBox
            // 
            this.useScrobbleGroupBox.Controls.Add(this.label1);
            this.useScrobbleGroupBox.Controls.Add(this.scrobbleTimeRateLabel);
            this.useScrobbleGroupBox.Controls.Add(this.scrobbleTimeLabel);
            this.useScrobbleGroupBox.Controls.Add(this.useScrobbleTimeSecondsCheckBox);
            this.useScrobbleGroupBox.Controls.Add(this.scrobbleTimeRateTrackBar);
            this.useScrobbleGroupBox.Controls.Add(this.scrobbleTimeSecondsNumericUpDown);
            this.useScrobbleGroupBox.Controls.Add(this.scrobbleTimeSecondsLabel);
            this.useScrobbleGroupBox.Location = new System.Drawing.Point(5, 204);
            this.useScrobbleGroupBox.Name = "useScrobbleGroupBox";
            this.useScrobbleGroupBox.Size = new System.Drawing.Size(295, 159);
            this.useScrobbleGroupBox.TabIndex = 3;
            this.useScrobbleGroupBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "(いずれか早い方)";
            // 
            // scrobbleTimeRateLabel
            // 
            this.scrobbleTimeRateLabel.AutoSize = true;
            this.scrobbleTimeRateLabel.Location = new System.Drawing.Point(200, 69);
            this.scrobbleTimeRateLabel.Name = "scrobbleTimeRateLabel";
            this.scrobbleTimeRateLabel.Size = new System.Drawing.Size(73, 18);
            this.scrobbleTimeRateLabel.TabIndex = 2;
            this.scrobbleTimeRateLabel.Text = "% の再生";
            // 
            // scrobbleTimeLabel
            // 
            this.scrobbleTimeLabel.Location = new System.Drawing.Point(8, 69);
            this.scrobbleTimeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.scrobbleTimeLabel.Name = "scrobbleTimeLabel";
            this.scrobbleTimeLabel.Size = new System.Drawing.Size(273, 22);
            this.scrobbleTimeLabel.TabIndex = 1;
            this.scrobbleTimeLabel.Text = "100";
            this.scrobbleTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // useScrobbleTimeSecondsCheckBox
            // 
            this.useScrobbleTimeSecondsCheckBox.AutoSize = true;
            this.useScrobbleTimeSecondsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "UseScrobbleTimeSeconds", true));
            this.useScrobbleTimeSecondsCheckBox.Location = new System.Drawing.Point(10, 100);
            this.useScrobbleTimeSecondsCheckBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.useScrobbleTimeSecondsCheckBox.Name = "useScrobbleTimeSecondsCheckBox";
            this.useScrobbleTimeSecondsCheckBox.Size = new System.Drawing.Size(22, 21);
            this.useScrobbleTimeSecondsCheckBox.TabIndex = 3;
            this.useScrobbleTimeSecondsCheckBox.UseVisualStyleBackColor = true;
            this.useScrobbleTimeSecondsCheckBox.CheckedChanged += new System.EventHandler(this.useScrobbleTimeSecondsCheckBox_CheckedChanged);
            // 
            // scrobbleTimeRateTrackBar
            // 
            this.scrobbleTimeRateTrackBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ScrobbleTimeRate", true));
            this.scrobbleTimeRateTrackBar.Location = new System.Drawing.Point(7, 24);
            this.scrobbleTimeRateTrackBar.Maximum = 100;
            this.scrobbleTimeRateTrackBar.Minimum = 1;
            this.scrobbleTimeRateTrackBar.Name = "scrobbleTimeRateTrackBar";
            this.scrobbleTimeRateTrackBar.Size = new System.Drawing.Size(275, 69);
            this.scrobbleTimeRateTrackBar.TabIndex = 0;
            this.scrobbleTimeRateTrackBar.TickFrequency = 10;
            this.scrobbleTimeRateTrackBar.Value = 50;
            this.scrobbleTimeRateTrackBar.ValueChanged += new System.EventHandler(this.scrobbleTimeRateTrackBar_ValueChanged);
            // 
            // scrobbleTimeSecondsNumericUpDown
            // 
            this.scrobbleTimeSecondsNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource, "ScrobbleTimeSeconds", true));
            this.scrobbleTimeSecondsNumericUpDown.Location = new System.Drawing.Point(43, 98);
            this.scrobbleTimeSecondsNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.scrobbleTimeSecondsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.scrobbleTimeSecondsNumericUpDown.Name = "scrobbleTimeSecondsNumericUpDown";
            this.scrobbleTimeSecondsNumericUpDown.Size = new System.Drawing.Size(127, 25);
            this.scrobbleTimeSecondsNumericUpDown.TabIndex = 4;
            this.scrobbleTimeSecondsNumericUpDown.Value = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            // 
            // scrobbleTimeSecondsLabel
            // 
            this.scrobbleTimeSecondsLabel.AutoSize = true;
            this.scrobbleTimeSecondsLabel.Location = new System.Drawing.Point(177, 100);
            this.scrobbleTimeSecondsLabel.Name = "scrobbleTimeSecondsLabel";
            this.scrobbleTimeSecondsLabel.Size = new System.Drawing.Size(95, 18);
            this.scrobbleTimeSecondsLabel.TabIndex = 5;
            this.scrobbleTimeSecondsLabel.Text = "秒間の再生";
            // 
            // useScrobbleCheckBox
            // 
            this.useScrobbleCheckBox.AutoSize = true;
            this.useScrobbleCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "UseScrobble", true));
            this.useScrobbleCheckBox.Location = new System.Drawing.Point(5, 174);
            this.useScrobbleCheckBox.Name = "useScrobbleCheckBox";
            this.useScrobbleCheckBox.Size = new System.Drawing.Size(155, 22);
            this.useScrobbleCheckBox.TabIndex = 2;
            this.useScrobbleCheckBox.Text = "Scrobble を有効";
            this.useScrobbleCheckBox.UseVisualStyleBackColor = true;
            this.useScrobbleCheckBox.CheckedChanged += new System.EventHandler(this.useScrobbleCheckBox_CheckedChanged);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Location = new System.Drawing.Point(88, 27);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(156, 25);
            this.usernameTextBox.TabIndex = 0;
            // 
            // useUpdateNowPlayingCheckBox
            // 
            this.useUpdateNowPlayingCheckBox.AutoSize = true;
            this.useUpdateNowPlayingCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource, "UseUpdateNowPlaying", true));
            this.useUpdateNowPlayingCheckBox.Location = new System.Drawing.Point(5, 144);
            this.useUpdateNowPlayingCheckBox.Name = "useUpdateNowPlayingCheckBox";
            this.useUpdateNowPlayingCheckBox.Size = new System.Drawing.Size(176, 22);
            this.useUpdateNowPlayingCheckBox.TabIndex = 1;
            this.useUpdateNowPlayingCheckBox.Text = "NowPlaying を有効";
            this.useUpdateNowPlayingCheckBox.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Controls.Add(this.exitButton);
            this.mainPanel.Location = new System.Drawing.Point(20, 390);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(383, 42);
            this.mainPanel.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(258, 0);
            this.closeButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(125, 42);
            this.closeButton.TabIndex = 0;
            this.closeButton.Text = "閉じる";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitButton.Location = new System.Drawing.Point(0, 0);
            this.exitButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(125, 42);
            this.exitButton.TabIndex = 1;
            this.exitButton.Text = "終了";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.authGroupBox);
            this.panel1.Controls.Add(this.useUpdateNowPlayingCheckBox);
            this.panel1.Controls.Add(this.useScrobbleCheckBox);
            this.panel1.Controls.Add(this.useScrobbleGroupBox);
            this.panel1.Location = new System.Drawing.Point(20, 18);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 364);
            this.panel1.TabIndex = 1;
            // 
            // authGroupBox
            // 
            this.authGroupBox.Controls.Add(this.logoutButton);
            this.authGroupBox.Controls.Add(this.usernameTextBox);
            this.authGroupBox.Controls.Add(this.useIconPictureBox);
            this.authGroupBox.Controls.Add(this.authStateLabel);
            this.authGroupBox.Controls.Add(this.authenticateButton);
            this.authGroupBox.Location = new System.Drawing.Point(5, 4);
            this.authGroupBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.authGroupBox.Name = "authGroupBox";
            this.authGroupBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.authGroupBox.Size = new System.Drawing.Size(370, 132);
            this.authGroupBox.TabIndex = 0;
            this.authGroupBox.TabStop = false;
            this.authGroupBox.Text = "ユーザ情報";
            // 
            // logoutButton
            // 
            this.logoutButton.AutoSize = true;
            this.logoutButton.Location = new System.Drawing.Point(223, 81);
            this.logoutButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(142, 42);
            this.logoutButton.TabIndex = 3;
            this.logoutButton.Text = "解除";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // useIconPictureBox
            // 
            this.useIconPictureBox.Location = new System.Drawing.Point(10, 27);
            this.useIconPictureBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.useIconPictureBox.Name = "useIconPictureBox";
            this.useIconPictureBox.Size = new System.Drawing.Size(70, 63);
            this.useIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.useIconPictureBox.TabIndex = 19;
            this.useIconPictureBox.TabStop = false;
            // 
            // authStateLabel
            // 
            this.authStateLabel.AutoSize = true;
            this.authStateLabel.Location = new System.Drawing.Point(90, 58);
            this.authStateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.authStateLabel.Name = "authStateLabel";
            this.authStateLabel.Size = new System.Drawing.Size(0, 18);
            this.authStateLabel.TabIndex = 1;
            // 
            // authenticateButton
            // 
            this.authenticateButton.AutoSize = true;
            this.authenticateButton.Location = new System.Drawing.Point(88, 81);
            this.authenticateButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.authenticateButton.Name = "authenticateButton";
            this.authenticateButton.Size = new System.Drawing.Size(125, 42);
            this.authenticateButton.TabIndex = 2;
            this.authenticateButton.Text = "認証";
            this.authenticateButton.UseVisualStyleBackColor = true;
            this.authenticateButton.Click += new System.EventHandler(this.authenticateButton_Click);
            // 
            // scrobbleTimer
            // 
            this.scrobbleTimer.Tick += new System.EventHandler(this.scrobbleTimer_Tick);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(ScrobblerForKbMediaPlayer.Settings);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(420, 448);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.useScrobbleGroupBox.ResumeLayout(false);
            this.useScrobbleGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scrobbleTimeRateTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrobbleTimeSecondsNumericUpDown)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.authGroupBox.ResumeLayout(false);
            this.authGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.useIconPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem notifySettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyExitToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label scrobbleTimeSecondsLabel;
        private System.Windows.Forms.NumericUpDown scrobbleTimeSecondsNumericUpDown;
        private System.Windows.Forms.CheckBox useScrobbleCheckBox;
        private System.Windows.Forms.CheckBox useUpdateNowPlayingCheckBox;
        private System.Windows.Forms.ToolStripMenuItem notifyLoveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyUnloveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.ToolStripMenuItem notifyTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyArtistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem notifyAlbumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyLastfmTopPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notifyLastfmUserPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem notifyStateToolStripMenuItem;
        private System.Windows.Forms.TrackBar scrobbleTimeRateTrackBar;
        private System.Windows.Forms.GroupBox useScrobbleGroupBox;
        private System.Windows.Forms.Label scrobbleTimeRateLabel;
        private System.Windows.Forms.CheckBox useScrobbleTimeSecondsCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label scrobbleTimeLabel;
        private System.Windows.Forms.Label authStateLabel;
        private System.Windows.Forms.PictureBox useIconPictureBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button authenticateButton;
        private System.Windows.Forms.Timer scrobbleTimer;
        private System.Windows.Forms.GroupBox authGroupBox;
        private System.Windows.Forms.ToolStripMenuItem notifyScrobbleToolStripMenuItem;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeButton;
    }
}


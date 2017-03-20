using ScrobblerForKbMediaPlayer.Utils;
using System;
using System.Threading;
using System.Windows.Forms;



namespace ScrobblerForKbMediaPlayer
{
    static class Program
    {
        public static Settings Settings { get; private set; }
        //Mutex
        private static Mutex mutex = new System.Threading.Mutex(false, AppUtil.GetAppName());

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool hasHandle = false;
            using (Mutex mutex = new Mutex(false, AppUtil.GetAppName()))
            {
                try
                {
                    hasHandle = mutex.WaitOne(0, false);
                }
                catch (AbandonedMutexException)
                {
                    hasHandle = true;
                }

                if (hasHandle == false)
                {
                    MessageBox.Show(Properties.Resources.MessageMutex, AppUtil.GetAppName(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                //// ThreadException
                //Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                //// UnhandledException
                //Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(Application_UnhandledException);
                

                Program.Settings = new Settings();
                Program.Settings.ReadXml();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                Program.Settings.WriteXml();
            }
        }

        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(Properties.Resources.ErrorApp + Environment.NewLine + Environment.NewLine + e.Exception.Message, AppUtil.GetAppName());
            Application.Exit();
        }

        public static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                MessageBox.Show(Properties.Resources.ErrorApp + Environment.NewLine + Environment.NewLine + ex.Message, AppUtil.GetAppName());
                Application.Exit();
            }
        }

    }


}

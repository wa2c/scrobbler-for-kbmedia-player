using Lastfm.Scrobbling;
using Lastfm.Services;
using ScrobblerForKbMediaPlayer.Entities;
using ScrobblerForKbMediaPlayer.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace ScrobblerForKbMediaPlayer
{
    class LastFmManager : IDisposable
    {
        private const string dp = "Scrobbler for KMP";

        /// <summary>言語.</summary>
        public SiteLanguage Language { get; private set; } = SiteLanguage.Japanese;

        /// <summary>ユーザ名.</summary>
        public string UserName { get; private set; }
        /// <summary>ユーザ画像.</summary>
        public Image UserImage { get; private set; }
        /// <summary>セッションキー.</summary>
        public string SessionKey { get { return session?.SessionKey; } }
        /// <summary>認証済の場合はtrue.</summary>
        public bool Authenticated { get { return session.Authenticated && !string.IsNullOrEmpty(SessionKey); } }

        /// <summary>セッション.</summary>
        private Session session;
        /// <summary>認証済ユーザ. 未認証の場合はnull.</summary>
        private AuthenticatedUser user;
        /// <summary>Connection.</summary>
        private Connection connection;


        /// <summary>
        /// Constructor.
        /// </summary>
        public LastFmManager() 
        {
            string apiKey = AppUtil.DecryptString("d1CqThW+zHNDaxPiLQCUvC5h7I8z4P/4TTCSm7X829DUQQRHOvLvt5zEi17Xs9iy", dp);
            string apiSecret = AppUtil.DecryptString("NfFEYnmtlUcpe3XvFy9TU2SfsXBhgGJ0vb3YQOp4D8kG+oBhecgOss7ibgxBUQjn", dp);

            this.session = new Session(apiKey, apiSecret);
            this.connection = new Connection(Utils.AppUtil.GetAppName(), Utils.AppUtil.GetVersion(), this.UserName, this.session);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            this.UserImage?.Dispose();
        }
        


        /// <summary>
        /// Web認証を行う.
        /// </summary>
        /// <returns>最後まで完了した場合はtrue.</returns>
        public bool AuthenticateWeb()
        {
            try
            {
                this.session.SessionKey = null;
                Process.Start(this.session.GetWebAuthenticationURL());
                if (System.Windows.Forms.MessageBox.Show(Properties.Resources.MessageAuthentication, AppUtil.GetAppName(), System.Windows.Forms.MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                    return false;
                this.session.AuthenticateViaWeb();
                return Authenticate(); ;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// キー認証を行う.
        /// </summary>
        /// <param name="key">セッションキー.</param>
        /// <returns>最後まで完了した場合はtrue.</returns>
        public bool AuthenticateKey(string key)
        {
            this.session.SessionKey = key;
            return Authenticate(); ;
        }

        /// <summary>
        /// 認証を行う.
        /// </summary>
        /// <returns>認証に成功した場合はtrue.</returns>
        private bool Authenticate()
        {
            bool isSucceeded = false;
            try
            {
                // ユーザ情報取得
                this.user = AuthenticatedUser.GetUser(this.session);
                this.UserName = this.user.Name;
                using (var client = new WebClient())
                using (Stream stream = client.OpenRead(user.GetImageURL()))
                {
                    this.UserImage = Image.FromStream(stream);
                }
                this.connection = new Connection(Utils.AppUtil.GetAppName(), Utils.AppUtil.GetVersion(), this.UserName, this.session);
                this.connection.Initialize();
                isSucceeded = true;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            finally
            {
                if (!isSucceeded)
                {
                    this.user = null;
                    this.UserName = null;
                    this.UserImage?.Dispose();
                    this.UserImage = null;
                }
            }
            return isSucceeded;
        }

        /// <summary>
        /// ログアウト.
        /// </summary>
        public void Logout()
        {
            AuthenticateKey(null);
        }

        /// <summary>
        /// UpdateNowPlaying
        /// </summary>
        public void UpdateNowPlaying(PropertyData data, bool isAuthRetry = false)
        {
            try
            {
                if (!this.session.Authenticated)
                    return;

                var entry = new NowplayingTrack(data.Artist, data.Title, data.GetDurationSpan());
                entry.Album = data.Album;
                connection.ReportNowplaying(entry);
            }
            catch (AuthenticationFailureException)
            {
                if (isAuthRetry)
                    return;
                Authenticate();
                UpdateNowPlaying(data, true);
            }
        }

        /// <summary>
        /// Scrobble
        /// </summary>
        public bool Scrobble(ICollection<PropertyData> dataList, bool isAuthRetry = false)
        {
            try
            {
                if (!this.session.Authenticated || this.connection == null)
                    return false;
                if (dataList == null || dataList.Count == 0)
                    return false;

                foreach (PropertyData data in dataList)
                {
                    var entry = new Entry(data.Artist, data.Title, data.PlayedTime, PlaybackSource.User, data.GetDurationSpan(), ScrobbleMode.Played);
                    entry.Album = data.Album;
                    this.connection.Scrobble(entry);
                }
                return true;
            }
            catch (AuthenticationFailureException ex)
            {
                if (isAuthRetry)
                {
                    throw ex;
                }
                Authenticate();
                return Scrobble(dataList, true);
            }
        }

        /// <summary>
        /// Love.
        /// </summary>
        public bool Love(PropertyData data, bool isAuthRetry = false)
        {
            try
            {
                if (!this.session.Authenticated)
                    return false;

                var track = new Track(data.Artist, data.Title, this.session);
                track.Love();
                return true;
            }
            catch (AuthenticationFailureException ex)
            {
                if (isAuthRetry)
                {
                    throw ex;
                }
                Authenticate();
                return Love(data, true);
            }
        }

        /// <summary>
        /// Unlove.
        /// </summary>
        public bool UnLove(PropertyData data, bool isAuthRetry = false)
        {
            try
            {
                if (!this.session.Authenticated)
                    return false;

                // メソッドが無いので、リフレクションで track.unlove を実行
                var track = new Track(data.Artist, data.Title, this.session);
                track.GetType().InvokeMember("requireAuthentication", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, track, null);
                track.GetType().InvokeMember("request", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod, null, track, new string[] { "track.unlove" });
                return true;
            }
            catch (AuthenticationFailureException ex)
            {
                if (isAuthRetry)
                {
                    throw ex;
                }
                Authenticate();
                return UnLove(data, true);
            }
        }

        /// <summary>
        /// Open tack page.
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public void OpenTrackPage(PropertyData data)
        {
            var track = new Track(data.Artist, data.Title, this.session);
            string url = track.GetURL(this.Language);
            Process.Start(url);
        }

        /// <summary>
        /// Open artist page.
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public void OpenArtistPage(PropertyData data)
        {
            var artist = new Artist(data.Artist, this.session);
            string url = artist.GetURL(this.Language);
            Process.Start(url);
        }

        /// <summary>
        /// Open album page.
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns></returns>
        public void OpenAlbumPage(PropertyData data)
        {
            var album = new Album(data.Artist, data.Title, this.session);
            string url = album.GetURL(this.Language);
            Process.Start(url);
        }

        /// <summary>
        /// Open user page.
        /// </summary>
        /// <returns></returns>
        public void OpenUserPage()
        {
            User user = new User(this.UserName, this.session);
            Process.Start(user.GetURL(this.Language));
        }

        /// <summary>
        /// Open top page.
        /// </summary>
        /// <returns></returns>
        public void OpenTopPage()
        {
            User user = new User("", this.session);
            Uri uri = new Uri(user.GetURL(this.Language));
            Process.Start(uri.Host);
        }

    }
}

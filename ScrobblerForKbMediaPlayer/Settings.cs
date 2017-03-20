using ScrobblerForKbMediaPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;



namespace ScrobblerForKbMediaPlayer
{
    [Serializable()]
    public class Settings : AbstractSettings
    {
        /// <summary>ウィンドウ位置</summary>
        public Point MainFormLocation { get; set; }

        /// <summary>Last.fmのセッションID</summary>
        public string LastFmSessionId { get; set; } = "";

        /// <summary>Update Now Playingを使用</summary>
        public bool UseUpdateNowPlaying { get; set; } = true;
        /// <summary>Scrobbleを使用</summary>
        public bool UseScrobble { get; set; } = true;
        /// <summary>Scrobbleを行う再生時間割合</summary>
        public int ScrobbleTimeRate { get; set; } = 50;
        /// <summary>Scrobbleに再生秒数を使用</summary>
        public bool UseScrobbleTimeSeconds { get; set; } = false;
        /// <summary>Scrobbleを行う再生秒数</summary>
        public int ScrobbleTimeSeconds { get; set; } = 240;

        /// <summary>Scrobbleデータリスト.</summary>
        public List<PropertyData> ScrobbleList { get; set; } = new List<PropertyData>();

    }
    
}



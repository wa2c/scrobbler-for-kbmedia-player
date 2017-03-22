using ScrobblerForKbMediaPlayer.Enums;
using System;
using System.Collections.Generic;



namespace ScrobblerForKbMediaPlayer.Entities
{
    public class PropertyData
    {
        /// <summary>タイトル</summary>
        public string Title { get; set; }
        /// <summary>アーティスト</summary>
        public string Artist { get; set; }
        /// <summary>アルバム</summary>
        public string Album { get; set; }
        /// <summary>アルバムアーティスト</summary>
        public string AlbumArtist { get; set; }
        /// <summary>長さ</summary>
        public long Milliseconds { get; set; }

        /// <summary>再生状態</summary>
        public KbMediaPlayState State { get; set; }

        /// <summary>再生日時</summary>
        public DateTime PlayedTime { get; set; }




        public PropertyData()
        {
            this.PlayedTime = DateTime.Now;
        }

        public PropertyData(IDictionary<KbMediaProperty, string> data)
        {
            string title;
            string artist;
            string album;
            string albumArtist;
            string duration;
            string position;
            string state;
            data.TryGetValue(KbMediaProperty.Title, out title);
            data.TryGetValue(KbMediaProperty.Artist, out artist);
            data.TryGetValue(KbMediaProperty.Album, out album);
            data.TryGetValue(KbMediaProperty.AlbumArtist, out albumArtist);
            data.TryGetValue(KbMediaProperty.Position, out position);
            data.TryGetValue(KbMediaProperty.Length, out duration);
            data.TryGetValue(KbMediaProperty.Status, out state);

            this.Title = title;
            this.Artist = artist;
            this.Album = album;
            this.AlbumArtist = albumArtist;

            long d = 0;
            long.TryParse(duration, out d);
            this.Milliseconds = d;

            try
            {
                this.State = EnumFinder.PlayStateByValue(state);
            }
            catch (Exception)
            {
                this.State = KbMediaPlayState.Stop;
            }

            this.PlayedTime = DateTime.Now;
        }

        public TimeSpan GetDurationSpan()
        {
            return new TimeSpan(Milliseconds * 10000);
        }

        public bool EqualsMedia(PropertyData data)
        {
            if (data == null)
                return false;

            if (this.Title == data.Title &&
                this.Artist == data.Artist &&
                this.Album == data.Album)
                return true;
            else
                return false;
        }

    }
}

using ScrobblerForKbMediaPlayer.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;



namespace ScrobblerForKbMediaPlayer
{
    [Serializable()]
    public class Settings : AbstractSettings
    {
        /// <summary>�E�B���h�E�ʒu</summary>
        public Point MainFormLocation { get; set; }

        /// <summary>Last.fm�̃Z�b�V����ID</summary>
        public string LastFmSessionId { get; set; } = "";

        /// <summary>Update Now Playing���g�p</summary>
        public bool UseUpdateNowPlaying { get; set; } = true;
        /// <summary>Scrobble���g�p</summary>
        public bool UseScrobble { get; set; } = true;
        /// <summary>Scrobble���s���Đ����Ԋ���</summary>
        public int ScrobbleTimeRate { get; set; } = 50;
        /// <summary>Scrobble�ɍĐ��b�����g�p</summary>
        public bool UseScrobbleTimeSeconds { get; set; } = false;
        /// <summary>Scrobble���s���Đ��b��</summary>
        public int ScrobbleTimeSeconds { get; set; } = 240;

        /// <summary>Scrobble�f�[�^���X�g.</summary>
        public List<PropertyData> ScrobbleList { get; set; } = new List<PropertyData>();

    }
    
}



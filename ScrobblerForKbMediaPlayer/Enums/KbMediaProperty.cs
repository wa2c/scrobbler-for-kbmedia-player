using System;
using System.Linq;



namespace ScrobblerForKbMediaPlayer.Enums
{
    /// <summary>
    /// プロパティ情報.
    /// </summary>
    public enum KbMediaProperty
    {
        /// <summary>再生状態</summary>
        [DdeCommandAttribute("status")]
        Status,
        /// <summary>再生位置</summary>
        [DdeCommandAttribute("position")]
        Position,
        /// <summary>タイトル</summary>
        [DdeCommandAttribute("title")]
        Title,
        /// <summary>アーティスト</summary>
        [DdeCommandAttribute("artist")]
        Artist,
        /// <summary>アルバム</summary>
        [DdeCommandAttribute("album")]
        Album,
        /// <summary>ジャンル</summary>
        [DdeCommandAttribute("genre")]
        Genre,
        /// <summary>日付</summary>
        [DdeCommandAttribute("date")]
        Date,
        /// <summary>コメント</summary>
        [DdeCommandAttribute("comment")]
        Comment,
        /// <summary>アルバムアーティスト</summary>
        [DdeCommandAttribute("albumartist")]
        AlbumArtist,
        /// <summary>ビットレート</summary>
        [DdeCommandAttribute("bitrate")]
        Bitrate,
        /// <summary>トラック番号</summary>
        [DdeCommandAttribute("tracknumber")]
        TrackNumber,
        /// <summary>ディスク番号</summary>
        [DdeCommandAttribute("discnumber")]
        DiscNumber,
        /// <summary>トラック数</summary>
        [DdeCommandAttribute("tracktotal")]
        TrackTotal,
        /// <summary>ディスク数</summary>
        [DdeCommandAttribute("disctotal")]
        DiscTotal,

        /// <summary>トラックゲイン</summary>
        [DdeCommandAttribute("replaygain_track_gain")]
        ReplayGainTrackGain,
        /// <summary>トラックゲイン(ピーク)</summary>
        [DdeCommandAttribute("replaygain_track_peak")]
        ReplayGainTrackPeak,
        /// <summary>アルバムゲイン</summary>
        [DdeCommandAttribute("replaygain_album_gain")]
        ReplayGainAlbumGain,
        /// <summary>アルバムゲイン(ピーク)</summary>
        [DdeCommandAttribute("replaygain_album_peak")]
        ReplayGainAlbumPeak,

        /// <summary>長さ(ミリ秒)</summary>
        [DdeCommandAttribute("length")]
        Length,
        
        /// <summary>ファイル名</summary>
        [DdeCommandAttribute("filename")]
        FileName,
        /// <summary>リストファイル名</summary>
        [DdeCommandAttribute("listfilename")]
        ListFileName,
        /// <summary>リスト曲数</summary>
        [DdeCommandAttribute("listcount")]
        ListCount,

        /// <summary>対応メディア形式</summary>
        [DdeCommandAttribute("supportext")]
        SupportExt,
        /// <summary>対応アーカイブ形式</summary>
        [DdeCommandAttribute("supportarc")]
        SupportArc,
        /// <summary>KbMedia Player実行ファイルパス</summary>
        [DdeCommandAttribute("exename")]
        ExeName,
        /// <summary>KbMedia Playerバージョン</summary>
        [DdeCommandAttribute("version")]
        Version,
    }


    /// <summary>
    /// DDEコマンド属性.
    /// </summary>
    public class DdeCommandAttribute : Attribute
    {
        /// <summary>
        /// コマンド.
        /// </summary>
        private string command;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="command">コマンド.</param>
        public DdeCommandAttribute(string command)
        {
            this.command = command;
        }

        /// <summary>
        /// コマンドの取得.
        /// </summary>
        public string Command
        {
            get { return this.command; }
        }
    }

    /// <summary>
    /// KbMediaPropertyの拡張メソッド.
    /// </summary>
    public static class KbMediaPropertyExtension
    {
        /// <summary>
        /// コマンドを取得.
        /// </summary>
        /// <param name="property">MediaProperty</param>
        /// <returns></returns>
        public static string GetDdeCommand(this KbMediaProperty property)
        {
            Type enumType = property.GetType();
            string name = Enum.GetName(enumType, property);
            DdeCommandAttribute[] attributes = (DdeCommandAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(DdeCommandAttribute), false);
            return attributes.FirstOrDefault().Command;
        }
    }

}

using System;
using System.Linq;



namespace ScrobblerForKbMediaPlayer.Enums
{
    public enum KbMediaPlayState
    {
        /// <summary>演奏中</summary>
        [KbMediaPlayStateAttribute("Playing")]
        Playing,
        /// <summary>演奏停止</summary>
        [KbMediaPlayStateAttribute("Stop")]
        Stop,
        /// <summary>一時停止</summary>
        [KbMediaPlayStateAttribute("Pause")]
        Pause,
        /// <summary>シーク中</summary>
        [KbMediaPlayStateAttribute("Seeking")]
        Seeking,
    }
    

    /// <summary>
    /// 再生状態属性.
    /// </summary>
    public class KbMediaPlayStateAttribute : Attribute
    {
        /// <summary>再生状態</summary>
        private string value;

        /// <summary>
        /// コンストラクタ.
        /// </summary>
        /// <param name="v">再生状態.</param>
        public KbMediaPlayStateAttribute(string v)
        {
            this.value = v;
        }

        /// <summary>再生状態の取得.</summary>
        public string State
        {
            get { return this.value; }
        }
    }

    /// <summary>
    /// PlayState.
    /// </summary>
    public static class KbMediaPlayStateExtension
    {
        /// <summary>
        /// 状態値を取得.
        /// </summary>
        /// <param name="state">PlayState</param>
        /// <returns></returns>
        public static string GetStateValue(this KbMediaPlayState state)
        {
            Type enumType = state.GetType();
            string name = Enum.GetName(enumType, state);
            KbMediaPlayStateAttribute[] attributes = (KbMediaPlayStateAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(KbMediaPlayStateAttribute), false);
            return attributes.FirstOrDefault().State;
        }
    }

}

using System;



namespace ScrobblerForKbMediaPlayer.Enums
{
    /// <summary>
    /// Enum型に変換する拡張メソッド
    /// </summary>
    public static class EnumFinder
    {
        /// <summary>
        /// 値からEnumを取得
        /// </summary>
        /// <param name="value">変換元の値。</param>
        /// <returns>変換後のEnum値。</returns>
        public static KbMediaProperty PropertyByValue(string value)
        {
            foreach (KbMediaProperty type in Enum.GetValues(typeof(KbMediaProperty)))
            {
                if (type.GetDdeCommand() == value)
                    return type;
            }

            throw new NotSupportedException("Enum Not Found");
        }

        /// <summary>
        /// 値からEnumを取得
        /// </summary>
        /// <param name="value">変換元の値。</param>
        /// <returns>変換後のEnum値。</returns>
        public static KbMediaPlayState PlayStateByValue(string value)
        {
            foreach (KbMediaPlayState type in Enum.GetValues(typeof(KbMediaPlayState)))
            {
                if (type.GetStateValue() == value)
                    return type;
            }

            throw new NotSupportedException("Enum Not Found");
        }

    }
}

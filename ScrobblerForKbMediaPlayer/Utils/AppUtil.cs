using System;
using System.Security.Cryptography;
using System.Text;



namespace ScrobblerForKbMediaPlayer.Utils
{
    static class AppUtil
    {
        /// <summary>
        /// アプリケーション名を取得.
        /// </summary>
        /// <returns>アプリケーション名.</returns>
        public static string GetAppName()
        {
            System.Reflection.AssemblyTitleAttribute asmttl =
                (System.Reflection.AssemblyTitleAttribute)Attribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(System.Reflection.AssemblyTitleAttribute));
            return asmttl.Title;
        }

        /// <summary>
        /// アプリケーションバージョンを取得.
        /// </summary>
        /// <returns>アプリケーションバージョン.</returns>
        public static string GetVersion()
        {
            return System.Windows.Forms.Application.ProductVersion;
        }


        /// <summary>
        /// テキストを暗号化.
        /// </summary>
        /// <param name="sourceText">プレーンテキスト.</param>
        /// <param name="password">パスワード.</param>
        /// <returns>暗号化テキスト.</returns>
        public static string EncryptString(string sourceText, string password)
        {
            try
            {
                using (RijndaelManaged rijndael = new RijndaelManaged())
                {
                    byte[] key, iv;
                    GenerateKeyFromPassword(password, rijndael.KeySize, out key, rijndael.BlockSize, out iv);
                    rijndael.Key = key;
                    rijndael.IV = iv;
                    byte[] strBytes = System.Text.Encoding.UTF8.GetBytes(sourceText);
                    using (ICryptoTransform encryptor = rijndael.CreateEncryptor())
                    {
                        byte[] encBytes = encryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);
                        return Convert.ToBase64String(encBytes);
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// テキストを復号.
        /// </summary>
        /// <param name="sourceString">暗号化テキスト.</param>
        /// <param name="password">パスワード.</param>
        /// <returns>プレーンテキスト.</returns>
        public static string DecryptString(string sourceString, string password)
        {
            try
            {
                using (RijndaelManaged rijndael = new RijndaelManaged())
                {
                    byte[] key, iv;
                    GenerateKeyFromPassword(password, rijndael.KeySize, out key, rijndael.BlockSize, out iv);
                    rijndael.Key = key;
                    rijndael.IV = iv;
                    byte[] strBytes = System.Convert.FromBase64String(sourceString);
                    using (ICryptoTransform decryptor = rijndael.CreateDecryptor())
                    {
                        byte[] decBytes = decryptor.TransformFinalBlock(strBytes, 0, strBytes.Length);
                        return Encoding.UTF8.GetString(decBytes);
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// パスワードから共有キーと初期化ベクタを生成.
        /// </summary>
        private static void GenerateKeyFromPassword(string password, int keySize, out byte[] key, int blockSize, out byte[] iv)
        {
            byte[] salt = Encoding.UTF8.GetBytes("Scrobbler");
            Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(password, salt);
            deriveBytes.IterationCount = 1000;
            key = deriveBytes.GetBytes(keySize / 8);
            iv = deriveBytes.GetBytes(blockSize / 8);
        }

    }
}

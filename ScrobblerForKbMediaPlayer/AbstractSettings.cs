using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.ComponentModel;



namespace ScrobblerForKbMediaPlayer
{
    /// <summary>
    /// アプリケーションの設定情報を操作するクラス。
    /// </summary>
    /// <remarks>
    /// 設定の保持及び、設定の書き出し、読み込みを行う。<br />
    /// 設定の保存形式は、INIファイル形式、レジストリ形式が使用できる。<br />
    /// 設定及び初期値。必ず初期値を与えること。
    /// </remarks>
    abstract public class AbstractSettings
    {
        #region 設定情報

        /// <summary>セクション名。</summary>
        private readonly string SectionName;
        /// <summary>設定情報のフィールド(派生クラスのpublicインスタンスフィールド)。</summary>
        private readonly PropertyInfo[] SettingsProperties;
        /// <summary>呼び出し元のアセンブリパス。</summary>
        private readonly string ExecPath;

        /// <summary>
        /// 新しいインスタンスを初期化する。
        /// </summary>
        public AbstractSettings()
        {
            // 設定情報
            SectionName = this.GetType().Name;
            SettingsProperties =  this.GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.GetProperty);
            // パス情報
            ExecPath = Assembly.GetExecutingAssembly().Location;
            DirPath = Path.GetDirectoryName(ExecPath);
            FileName = Path.GetFileName(ExecPath);
        }

        /// <summary> ディレクトリのパスを取得または設定する。</summary>
        [Browsable(false)]
        public string DirPath { get; set; }

        /// <summary> 拡張子を除くファイル名を取得または設定する。</summary>
        [Browsable(false)]
        public string FileName { get; set; }

        #endregion



        #region INIファイル

        /// <summary>INIファイルのパスを取得する。</summary>
        [Browsable(false)]
        public string IniPath
        {
            get { return Path.Combine(DirPath, FileName) + ".ini"; }
        }

        /// <summary>
        /// INIファイルから設定を読み込む。
        /// </summary>
        public void ReadIni()
        {
            string path = IniPath;
            if (!File.Exists(path)) return;

            foreach (PropertyInfo field in SettingsProperties)
            {
                // プリミティブ型またはString型以外の値は無視
                if (!field.PropertyType.IsPrimitive &&
                    field.PropertyType != typeof(string))
                    continue;

                // INIファイルの読み込み
                StringBuilder value = new StringBuilder(256);
                GetPrivateProfileString(
                        SectionName, field.Name, "", value, (uint)value.Capacity, path);
                if (value.Length > 0)
                    field.SetValue(this, Convert.ChangeType(value.ToString(), field.PropertyType, null));
            }
        }

        /// <summary>
        /// INIファイルに設定を書き込む。
        /// </summary>
        public void WriteIni()
        {
            string path = IniPath;

            foreach (PropertyInfo field in SettingsProperties)
            {
                // プリミティブ型またはString型意外の値は無視
                if (!field.PropertyType.IsPrimitive &&
                    field.PropertyType != typeof(string))
                    continue;

                // INIファイルの書き込み
                string value = field.GetValue(this).ToString();
                if (field.PropertyType == typeof(string))
                    value = "\"" + value + "\"";
                WritePrivateProfileString(
                        SectionName, field.Name, value, path);
            }
        }

        /// <summary>
        /// INIファイルを削除する。
        /// </summary>
        public void DeleteIni()
        {
            string path = IniPath;
            File.Delete(path);
        }

        /// <summary>
        /// INIファイル読み込み関数宣言。（Win32API）
        /// </summary>
        /// <param name="lpApplicationName">セクション名。</param>
        /// <param name="lpEntryName">キー名。</param>
        /// <param name="lpDefault">デフォルト値。</param>
        /// <param name="lpReturnedString">値。</param>
        /// <param name="nSize">値のサイズ。</param>
        /// <param name="lpFileName">INIファイルパス。</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        protected static extern uint GetPrivateProfileString(
                string lpApplicationName,
                string lpEntryName,
                string lpDefault,
                StringBuilder lpReturnedString,
                uint nSize,
                string lpFileName);

        /// <summary>
        /// INIファイル書き込み関数宣言。（Win32API）
        /// </summary>
        /// <param name="lpApplicationName">セクション名。</param>
        /// <param name="lpEntryName">キー名。</param>
        /// <param name="lpEntryString">値。</param>
        /// <param name="lpFileName">INIファイルパス。</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        protected static extern uint WritePrivateProfileString(
                string lpApplicationName,
                string lpEntryName,
                string lpEntryString,
                string lpFileName);

        #endregion



        #region XMLファイル

        /// <summary>XMLファイルのパスを取得する。</summary>
        [Browsable(false)]
        public string XmlPath
        {
            get { return Path.Combine(DirPath, FileName) + ".xml"; }
        }

        /// <summary>
        /// XMLファイルから設定を読み込む。
        /// </summary>
        public void ReadXml()
        {
            string path = XmlPath;
            if (!File.Exists(path)) return;

            // XMLファイルの読み込み
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (FileStream inputStream = new FileStream(path, FileMode.Open))
            {
                Object set = serializer.Deserialize(inputStream);
                foreach (PropertyInfo field in SettingsProperties)
                {
                    if (field.CanWrite)
                    field.SetValue(this, Convert.ChangeType(field.GetValue(set), field.PropertyType, null));
                }
            }
        }

        /// <summary>
        /// XMLファイルに設定を書き込む。
        /// </summary>
        public void WriteXml()
        {
            string path = XmlPath;

            // XMLファイルの書き込み
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (FileStream outputStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                outputStream.SetLength(0);
                serializer.Serialize(outputStream, this);
            }
        }

        /// <summary>
        /// XMLファイルを削除する。
        /// </summary>
        public void DeleteXml()
        {
            string path = XmlPath;
            File.Delete(path);
        }

        #endregion



        #region レジストリ

        /// <summary>
        /// レジストリのキーを取得する。
        /// </summary>
        [Browsable(false)]
        public string RegistryPath
        {
            get {
                Assembly thisAssembly = Assembly.GetExecutingAssembly();
                AssemblyTitleAttribute titleAttribute = Attribute.GetCustomAttribute(thisAssembly, typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;
                string title = titleAttribute.Title;
                return "Software\\" + "\\" + title + "\\" + SectionName;
            }
        }

        /// <summary>
        /// レジストリから設定を読み込む。
        /// </summary>
        public void ReadRegistry()
        {
            string path = RegistryPath;

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(path, false))
            {
                if (key == null) return;

                foreach (PropertyInfo field in SettingsProperties)
                {
                    // プリミティブ型またはString型以外の値は無視
                    if (!field.PropertyType.IsPrimitive &&
                        field.PropertyType != typeof(string))
                        continue;

                    // レジストリの読み込み
                    object value = key.GetValue(field.Name);
                    if (value != null)
                        field.SetValue(this, Convert.ChangeType(value, field.PropertyType, null));
                }
            }
        }

        /// <summary>
        /// レジストリに設定を書き込む。
        /// </summary>
        public void WriteRegistry()
        {
            string path = RegistryPath;

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(path))
            {
                foreach (PropertyInfo field in SettingsProperties)
                {
                    // プリミティブ型またはString型意外の値は無視
                    if (!field.PropertyType.IsPrimitive &&
                        field.PropertyType != typeof(string))
                        continue;

                    // レジストリの書き込み
                    string value = field.GetValue(this).ToString();
                    key.SetValue(field.Name, field.GetValue(this));
                }
            }
        }

        /// <summary>
        /// レジストリを削除する。
        /// </summary>
        public void DeleteRegistry(string path)
        {
            string paht = RegistryPath;
            Registry.CurrentUser.DeleteSubKeyTree(path);
        }

        #endregion
    }

}

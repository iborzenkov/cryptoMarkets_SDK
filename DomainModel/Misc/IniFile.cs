using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace DomainModel.Misc
{
    internal class IniFile
    {
        private readonly string _path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder retVal, int size, string filePath);

        public IniFile(string iniPath)
        {
            _path = new FileInfo(iniPath).FullName;
        }

        public string Read(string section, string key)
        {
            var retVal = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", retVal, 255, _path);
            return retVal.ToString();
        }

        public void Write(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, _path);
        }

        public bool KeyExists(string key, string section = null)
        {
            return Read(section, key).Length > 0;
        }

        public void DeleteKey(string key, string section = null)
        {
            Write(section, key, null);
        }
    }
}
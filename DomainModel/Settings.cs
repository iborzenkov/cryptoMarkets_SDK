using System;
using System.IO;
using DomainModel.Misc;

namespace DomainModel
{
    public class Settings
    {
        private const string Filename = "settings.ini";

        private static Settings _instance;
        private readonly IniFile _iniFile;

        private Settings()
        {
            var path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            _iniFile = new IniFile(Path.Combine(path, Filename));
        }

        public static Settings Instance => _instance ?? (_instance = new Settings());

        public void Write(string category, string name, string value)
        {
            _iniFile.Write(category, name, value);
        }

        public string Read(string category, string name)
        {
            return _iniFile.Read(category, name);
        }

        public void Delete(string category, string name)
        {
            _iniFile.DeleteKey(name, category);
        }
    }
}
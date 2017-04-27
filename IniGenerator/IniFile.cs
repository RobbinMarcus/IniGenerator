using System.IO;
using IniParser;
using IniParser.Model;

namespace IniGenerator
{
    public class IniFile
    {
        private readonly FileIniDataParser parser;
        private readonly IniData data;
        private readonly string path;

        public bool FileExists => File.Exists(path);
        public IniData Data => data;

        public IniFile(string filePath)
        {
            parser = new FileIniDataParser();
            path = filePath;
            data = FileExists ? parser.ReadFile(filePath) : new IniData();
        }

        public void Save()
        {
            parser.WriteFile(path, data);
        }

        public void Merge(IniData newData)
        {
            data.Merge(newData);
        }

        public string GetValue(string key, string name)
        {
            return data[key][name];
        }

        public void SetValue(string key, string name, string value)
        {
            data[key][name] = value;
        }
    }
}

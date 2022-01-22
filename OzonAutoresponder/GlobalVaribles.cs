using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzonAutoresponder
{
    public static class GlobalVaribles
    {
        private static SettingsData? _settings;
        private static readonly string? _projectDirecotory = $@"{Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent}\"; 
        public static string ProjectDirectory
        {
            get
            {
                if(_projectDirecotory == null)
                {
                    return string.Empty;
                }
                else
                {
                    return _projectDirecotory;
                }
            }
        }
        public static string? TemplatesDirectory
        {
            get
            {
                return $@"{_projectDirecotory}templates\";
            }
        }
        public static string ProfileJsonFile => "profile.json";

        public static SettingsData Settings
        {
            get
            {
                if(_settings == null)
                {
                    string content = File.ReadAllText($"{ProjectDirectory}settings.json");
                    _settings = JToken.Parse(content).ToObject<SettingsData>();
                }
                return _settings;
            }
        }
    }
}

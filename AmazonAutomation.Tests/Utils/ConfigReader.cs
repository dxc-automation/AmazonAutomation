using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AmazonAutomation.Tests.Utils
{
    public static class ConfigReader
    {
        private static readonly JObject _config;

        static ConfigReader()
        {
            var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            if (!File.Exists(file))
            {
                // fallback to project file location
                file = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            }
            var text = File.ReadAllText(file);
            _config = JObject.Parse(text);
        }

        public static string GetString(string key, string @default = null)
        {
            return _config[key]?.ToString() ?? @default;
        }

        public static int GetInt(string key, int @default = 0)
        {
            var t = _config[key]?.ToString();
            return int.TryParse(t, out var v) ? v : @default;
        }
    }
}
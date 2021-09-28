using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WebAPIAutomation.APIConfig
{
    public class Config
    {
        private static string path = "C:/Users/ajang/Desktop/log.txt";
        private static string key = "713ffff76af04f9a611ef72f25c497ce";
        private static string url = "http://api.exchangeratesapi.io";

        public static string APIKey
        {
            get
            {
                return key;
            }
        }
        public static string ExchangeRate
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }
        public static string LogPath 
        { 
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        } 

        public string GetFilePathFromDirectory()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var replacedBin = currentDirectory.Replace("bin","Log").Replace("Debug", "logger.txt").Replace("net5.0", "").Remove(78).Remove(77);
            return replacedBin;
        }
    }
}

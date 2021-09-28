using System.IO;
using System.Reflection;

namespace WebAPIAutomation.APIConfig
{
    public static class Config
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
    }
}

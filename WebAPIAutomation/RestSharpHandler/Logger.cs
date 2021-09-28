using System;
using System.Configuration;
using System.IO;
using WebAPIAutomation.APIConfig;
using WebAPIAutomation.RestSharpHandler.Interface;

namespace WebAPIAutomation.RestSharpHandler
{
    public class Logger : ILogger
    {
        public void WriteLog(string message)
        {
            string logPath = Config.LogPath;
            using(StreamWriter writer = new StreamWriter(logPath,true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}

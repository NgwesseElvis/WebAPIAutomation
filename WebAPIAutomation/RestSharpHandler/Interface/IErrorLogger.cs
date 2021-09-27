using RestSharp;
using System;

namespace WebAPIAutomation.RestSharpHandler.Interface
{
    public interface IErrorLogger
    {
        void LogError(Exception ex, string infoMessage);
        void LogError(Uri BaseUrl, IRestRequest request, IRestResponse response);
        void TimeoutCheck(Uri BaseUrl,IRestRequest request, IRestResponse response);
    }
}

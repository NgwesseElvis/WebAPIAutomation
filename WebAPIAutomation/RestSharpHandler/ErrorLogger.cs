using RestSharp;
using System;
using System.Linq;
using WebAPIAutomation.RestSharpHandler.Interface;

namespace WebAPIAutomation.RestSharpHandler
{
    public class ErrorLogger: IErrorLogger
    {


        public void LogError(Exception ex, string infoMessage)
        {
            throw new Exception(infoMessage, ex.InnerException);
        }

        public void LogError(Uri BaseUrl, IRestRequest request, IRestResponse response)
        {
            string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

            string info = "Request to " + BaseUrl.AbsoluteUri
                           + request.Resource + " failed with status code "
                           + response.StatusCode + ", parameters: "
                           + parameters + ", and content: " + response.Content;

            Exception ex;
            if (response != null && response.ErrorException != null)
            {
                ex = response.ErrorException;
            }
            else
            {
                ex = new Exception(info);
                info = string.Empty;
            }
            this.LogError(ex,info);
        }

        public void TimeoutCheck(Uri BaseUrl,IRestRequest request, IRestResponse response)
        {
            if (response.StatusCode == 0)
            {
                LogError(BaseUrl, request, response);
            }
        }
    }
}

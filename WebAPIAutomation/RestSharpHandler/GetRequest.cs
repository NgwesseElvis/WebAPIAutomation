using RestSharp;
using System;
using WebAPIAutomation.APIConfig;
using WebAPIAutomation.IOC;
using WebAPIAutomation.RestSharpHandler.Interface;

namespace WebAPIAutomation.RestSharpHandler
{
    public class GetRequest : IGetRequest
    {
        
        protected static string Url = Config.ExchangeRate;
        protected static Uri url = new(Url);
        protected RestClient client = new(url);
        private IGetResponse _getResponse;
        protected ICacheService _cache;
        protected IErrorLogger _errorLogger;

        public IRestResponse GetExchangeRate(string currency)
        {
            _getResponse = UnityWrapper.Resolve<IGetResponse>();
            _cache = UnityWrapper.Resolve<ICacheService>();
            _errorLogger = UnityWrapper.Resolve<IErrorLogger>();


            RestRequest request = new("/v1/latest", Method.GET);
            request.AddParameter("access_key", Config.APIKey);
            request.AddUrlSegment("currency", currency);
            request.AddHeader("cache-control", "no-cache");
            var responseResults = _getResponse.GetAsyncResponse<object>(client, url, request).GetAwaiter().GetResult();
            return responseResults;
        }

        public IRestResponse GetExchangeRateFromCache(string currency, string cacheKey)
        {
            _getResponse = UnityWrapper.Resolve<IGetResponse>();
            _cache = UnityWrapper.Resolve<ICacheService>();
            _errorLogger = UnityWrapper.Resolve<IErrorLogger>();


            RestRequest request = new("/v1/latest", Method.GET);
            request.AddHeader("API_KEY", Config.APIKey);
            request.AddUrlSegment("currency", currency);
            request.AddHeader("cache-control", "no-cache");
            var responseResults = _getResponse.GetAsyncResponse<object>(client, url, request).GetAwaiter().GetResult();
            return responseResults;
        }
    }
}

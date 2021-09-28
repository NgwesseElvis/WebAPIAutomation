using RestSharp;

namespace WebAPIAutomation.RestSharpHandler
{
    public interface IGetRequest
    {
        IRestResponse GetExchangeRate(string currency);
        object GetExchangeRateFromCache(string currency, string cacheKey);
    }
}

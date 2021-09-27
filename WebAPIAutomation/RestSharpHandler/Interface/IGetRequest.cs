using RestSharp;

namespace WebAPIAutomation.RestSharpHandler
{
    public interface IGetRequest
    {
        IRestResponse GetExchangeRate(string currency);
        IRestResponse GetExchangeRateFromCache(string currency, string cacheKey);
    }
}

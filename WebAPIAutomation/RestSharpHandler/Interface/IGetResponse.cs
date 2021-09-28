using RestSharp;
using System;
using System.Threading.Tasks;

namespace WebAPIAutomation.RestSharpHandler.Interface
{
    public interface IGetResponse
    {
        Task<IRestResponse<T>> GetAsyncResponse<T>(RestClient client, Uri BaseUrl,IRestRequest request) where T : class, new();
        Task<T> GetAsyncResponseFromCache<T>(RestClient client, Uri BaseUrl, IRestRequest request, string cacheKey) where T : class, new();
    }
}

using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using WebAPIAutomation.IOC;
using WebAPIAutomation.RestSharpHandler.Interface;

namespace WebAPIAutomation.RestSharpHandler
{
    public class GetResponse : IGetResponse
    {
        protected IErrorLogger _errorLogger;
        protected ICacheService _cacheService;

        public async Task<IRestResponse<T>> GetAsyncResponse<T>(RestClient client, Uri BaseUrl,IRestRequest request) where T : class, new()
        {
            _errorLogger = UnityWrapper.Resolve<IErrorLogger>();
            var taskCompleteSourse = new TaskCompletionSource<IRestResponse<T>>();
            var restresults = await client.ExecuteAsync<T>(request);
            {
                _errorLogger.TimeoutCheck(BaseUrl,request,restresults);
                taskCompleteSourse.SetResult(restresults);
            };

            return await taskCompleteSourse.Task;
        }

        public async Task<T> GetAsyncResponseFromCache<T>(RestClient client, Uri BaseUrl, IRestRequest request,string cacheKey) where T : class, new()
        {
            _errorLogger = UnityWrapper.Resolve<IErrorLogger>();
            _cacheService = UnityWrapper.Resolve<ICacheService>();

            var item = _cacheService.Get<T>(cacheKey);

            if (item == null) 
            {
                var restresults = await client.ExecuteAsync<T>(request);

                if (restresults.StatusCode == HttpStatusCode.OK)
                {
                    _cacheService.Set(cacheKey, restresults.Data); 
                    item = restresults.Data;
                }
                else
                {
                    _errorLogger.LogError(BaseUrl, request, restresults);
                    return default;
                }
            }
            return item;
        }
    }
}

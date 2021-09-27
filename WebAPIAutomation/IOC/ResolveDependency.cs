using WebAPIAutomation.RestSharpHandler;
using WebAPIAutomation.RestSharpHandler.Interface;

namespace WebAPIAutomation.IOC
{
    public static class ResolveDependency
    {
        public static void RegisterAndResolveDependencies()
        {
            UnityWrapper.Register<IGetRequest, GetRequest>();
            UnityWrapper.Register<IGetResponse, GetResponse>();
            UnityWrapper.Register<ICacheService, CacheService>();
            UnityWrapper.Register<IErrorLogger, ErrorLogger>();
        }
    }
}

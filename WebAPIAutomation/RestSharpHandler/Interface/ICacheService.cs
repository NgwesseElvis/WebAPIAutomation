namespace WebAPIAutomation.RestSharpHandler.Interface
{
    public interface ICacheService
    {
        T Get<T>(string cacheKey) where T : class;
        void Set(string cacheKey, object item, int minutes);
    }
}

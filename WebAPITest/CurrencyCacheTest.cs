using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using WebAPIAutomation.Hooks;
using WebAPIAutomation.IOC;
using WebAPIAutomation.RestSharpHandler;
using WebAPIAutomation.RestSharpHandler.Interface;

namespace WebAPITest
{
    public class CurrencyCacheTest : StartIOCContainer
    {
        protected IGetRequest _getRequest;
        protected ILogger _logger;

        [OneTimeSetUp]
        public void Setup()
        {
            _getRequest = UnityWrapper.Resolve<IGetRequest>();
            _logger = UnityWrapper.Resolve<ILogger>();
        }

        [Test,Category("Get EUR from Cache")]
        public void VerifyStatusCode()
        {
            var response = _getRequest.GetExchangeRateFromCache("EUR","euro");
            var responseObject = JsonConvert.SerializeObject(response);
            var jsonObject = JObject.Parse(responseObject);
            var success = jsonObject["success"].ToString();
            Assert.AreEqual(success, "True");
        }

        [Test, Category("Get EUR from Cache")]
        public void VerifyExchangeRate()
        {
            var response = _getRequest.GetExchangeRateFromCache("EUR", "euros");
            var responseObject = JsonConvert.SerializeObject(response);
            var jsonObject = JObject.Parse(responseObject);
            var rates = jsonObject["rates"];
            var exchangeRate = rates["EUR"];
            var results = $"EUR : {exchangeRate}";
            _logger.WriteLog(results);
        }
    }
}
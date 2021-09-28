using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using WebAPIAutomation.Hooks;
using WebAPIAutomation.IOC;
using WebAPIAutomation.RestSharpHandler;
using WebAPIAutomation.RestSharpHandler.Interface;

namespace WebAPITest
{
    public class CurrencyTest : StartIOCContainer
    {
        protected IGetRequest _getRequest;
        protected ILogger _logger;

        [OneTimeSetUp]
        public void Setup()
        {
            _getRequest = UnityWrapper.Resolve<IGetRequest>();
            _logger = UnityWrapper.Resolve<ILogger>();
        }

        [Test,Category("Get USD")]
        public void VerifyStatusCode()
        {
            var response = _getRequest.GetExchangeRate("USD");
            var statusCode = response.StatusCode.ToString();
            Assert.AreEqual(statusCode,"OK");
        }

        [Test, Category("Get USD")]
        public void VerifyStatusCodea()
        {
            var response = _getRequest.GetExchangeRate("USD");
            var content = response.Content;
            var jsonObject = JObject.Parse(content);
            var success = jsonObject["success"].ToString();
            Assert.AreEqual(success,"True");
            var rates = jsonObject["rates"];
            var dollarRate = rates["USD"].ToString();
            var message = $"USD : {dollarRate}";
            _logger.WriteLog(message);

        }
    }
}
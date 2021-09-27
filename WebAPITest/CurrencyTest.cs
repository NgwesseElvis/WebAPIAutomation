using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using WebAPIAutomation.Hooks;
using WebAPIAutomation.IOC;
using WebAPIAutomation.RestSharpHandler;

namespace WebAPITest
{
    public class CurrencyTest : StartIOCContainer
    {
        protected IGetRequest _getRequest;

        [OneTimeSetUp]
        public void Setup()
        {
            _getRequest = UnityWrapper.Resolve<IGetRequest>();
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
            var bases = jsonObject["base"].ToString();
            Assert.AreEqual(bases, "EUR");
            var rates = jsonObject["rates"];
            var currency = rates["AED"].ToString();
            var intCurrency = Convert.ToInt64(Math.Floor(Convert.ToDouble(currency)));
            Assert.NotZero(intCurrency);
        }
    }
}
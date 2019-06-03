using NUnit.Framework;
using RestSharp;
using System.Configuration;

namespace FWRun
{
    public abstract class BaseApiTest
    {
        private RestClient _restClient;
        private string baseUrl = ConfigurationManager.AppSettings["restClientUrl"];

        [OneTimeSetUp]
        public void SetUp()
        {
            _restClient = new RestClient(baseUrl);
        }

        protected RestClient RestClient => _restClient;
    }
}

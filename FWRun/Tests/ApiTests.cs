using FWRun.ApiEndpoints;
using FWRun.ApiServices.Models.Users;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Net;

namespace FWRun.Tests
{
    [TestFixture]
    public class ApiTests : BaseApiTest
    {
        [Test]
        public void ApiTest()
        {
            RestRequest request = Endpoints.GetListUsers(2);

            IRestResponse response = RestClient.Execute(request);
            var result = JsonConvert.DeserializeObject<UsersPageInfo>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

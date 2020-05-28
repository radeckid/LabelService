using LabelService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LabelServiceTests
{
    [TestFixture]
    public class LabelControllerTests
    {
        HttpClient _client;
        TestServer _server;

        [SetUp]
        public void SetUp()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public void CreateLabel()
        {
            string uri = "http://localhost:58765/Label/generate";
            string jsonBody = "{\"SenderCompany\": \"\",\"SenderName\": \"Damian\", \"SenderSurname\": \"Radecki\",\"SenderStreet\": \"Sztos\", \"SenderHomeNo\": \"1\", \"SenderZip\": \"12345\", \"SenderCity\": \"Zgol\", \"ReceiverCompany\": \"Actimelki\", \"ReceiverName\": \"Mateusz\", \"ReceiverSurname\": \"Komar\", \"ReceiverStreet\": \"Dymki\", \"ReceiverHomeNo\": \"2\", \"ReceiverZip\": \"54321\", \"ReceiverCity\": \"Jelenia Góra\", \"DeliveryIns\": \"Please do not throwing a         shipment.\", \"Price\": \"1\", \"Currency\": \"PLN\",\"Weight\": \"2\" }";

            var response = _client.PostAsync(uri, new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            var status = response.Result.StatusCode;

            Assert.AreEqual(HttpStatusCode.OK, status);
        }

        [Test]
        public async Task CreateLabel_CheckLabel()
        {
            string uri = "http://localhost:58765/Label/generate";
            string jsonBody = "{\"SenderCompany\": \"\",\"SenderName\": \"Damian\", \"SenderSurname\": \"Radecki\",\"SenderStreet\": \"Sztos\", \"SenderHomeNo\": \"1\", \"SenderZip\": \"12345\", \"SenderCity\": \"Zgol\", \"ReceiverCompany\": \"Actimelki\", \"ReceiverName\": \"Mateusz\", \"ReceiverSurname\": \"Komar\", \"ReceiverStreet\": \"Dymki\", \"ReceiverHomeNo\": \"2\", \"ReceiverZip\": \"54321\", \"ReceiverCity\": \"Jelenia Góra\", \"DeliveryIns\": \"Please do not throwing a         shipment.\", \"Price\": \"1\", \"Currency\": \"PLN\",\"Weight\": \"2\" }";

            var response = _client.PostAsync(uri, new StringContent(jsonBody, Encoding.UTF8, "application/json"));

            var responseString = await GetResponseString(response);

            Assert.AreEqual("", responseString);
        }

        private async Task<string> GetResponseString(Task<HttpResponseMessage> response)
        {
            var contents = await response.Result.Content.ReadAsStringAsync();

            return contents;
        }
    }
}

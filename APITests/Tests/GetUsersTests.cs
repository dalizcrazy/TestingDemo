using NUnit.Framework;
using APITests.Helpers;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TestUtilities;

namespace APITests.Tests
{
    [TestFixture]
    public class GetUsersTests
    {
        private ApiClient _api;

        [SetUp]
        public void Setup() => _api = new ApiClient("https://reqres.in/api");

        [Test]
        public async Task GetUsers_ReturnsSuccess()
        {
            var test = ExtentManager.CreateTest("GetUsers_ReturnsSuccess", "Verifica que GET /users?page=2 retorna 200 OK");
            var response = await _api.GetAsync("/users?page=2");
            test.Info("GET /users?page=2 ejecutado");

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            test.Pass("Código 200 OK recibido");

            var json = JObject.Parse(response.Content);
            Assert.That(json["data"], Is.Not.Null);
            test.Pass("Body contiene 'data'");
        }

        [OneTimeTearDown]
        public void Cleanup() => ExtentManager.Flush();
    }
}
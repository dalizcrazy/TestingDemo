using NUnit.Framework;
using APITests.Helpers;
using APITests.Models;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using TestUtilities;

namespace APITests.Tests
{
    [TestFixture]
    public class CreateUserTests
    {
        private ApiClient _api;

        [SetUp]
        public void Setup() => _api = new ApiClient("https://reqres.in/api");

        [Test]
        public async Task CreateUser_ReturnsCreated()
        {
            var test = ExtentManager.CreateTest("CreateUser_ReturnsCreated", "Verifica que POST /users retorna 201 Created");
            var user = new User { name = "morpheus", job = "leader" };
            

            var response = await _api.PostAsync("/users", user);
            test.Info("POST /users ejecutado");

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.Created));
            test.Pass("Código 201 Created recibido");

            var json = JObject.Parse(response.Content);
            Assert.That(json["id"], Is.Not.Null);
            test.Pass("Respuesta contiene 'id'");
        }

        [OneTimeTearDown]
        public void Cleanup() => ExtentManager.Flush();
    }
}
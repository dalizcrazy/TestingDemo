using NUnit.Framework;
using OpenQA.Selenium;
using UITests.Drivers;
using UITests.Pages;
using TestUtilities;

namespace UITests.Tests
{
    [TestFixture]
    public class LoginTests : IDisposable
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup() => _driver = new WebDriverSetup().CreateDriver();

        [Test]
        public void Login_ValidUser_ShouldLoginSuccessfully()
        {
            var test = ExtentManager.CreateTest("Login_ValidUser_ShouldLoginSuccessfully", "Login exitoso con credenciales válidas");

            var loginPage = new LoginPage(_driver);
            loginPage.NavigateTo();
            test.Info("Navegando a página de login");

            loginPage.Login("tomsmith", "SuperSecretPassword!");
            test.Info("Credenciales enviadas");

            Assert.That(_driver.PageSource.Contains("You logged into a secure area!"));
            test.Pass("Login exitoso — mensaje encontrado en la página");

        }

        [TearDown]
        public void Cleanup()
        {
            ExtentManager.Flush();
            _driver.Quit();
            
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
        
    }
}
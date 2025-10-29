using OpenQA.Selenium;

namespace UITests.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver) => _driver = driver;

        private IWebElement UsernameInput => _driver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.CssSelector("button[type='submit']"));

        public void NavigateTo() => _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

        public void Login(string user, string pass)
        {
            UsernameInput.SendKeys(user);
            PasswordInput.SendKeys(pass);
            LoginButton.Click();
        }
    }
}
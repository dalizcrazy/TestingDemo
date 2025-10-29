using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITests.Drivers
{
    public class WebDriverSetup
    {
        public IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
using OpenQA.Selenium;

namespace Ki.Automation.Tests.Factories
{
    public interface IWebDriverFactory
    {
        public IWebDriver GetChrome();
        public IWebDriver GetFirefox();
    }
}

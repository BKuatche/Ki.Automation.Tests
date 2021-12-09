using Ki.Automation.Tests.Helpers;
using OpenQA.Selenium;

namespace Ki.Automation.Tests.Factories
{
    public class BrowserFactory
    {
        private readonly IWebDriverFactory _driverFactory;

        public BrowserFactory()
        {
            _driverFactory = new LocalWebDriverFactory();
        }


        public bool IsChrome = ConfigurationHelper.Browser.Equals("Chrome");

        public bool IsFirefox = ConfigurationHelper.Browser.Equals("Firefox");



        public IWebDriver GetBrowser()
        {
            IWebDriver driver;

            if (IsChrome)
            {
                driver = _driverFactory.GetChrome();
            }
            else if (IsFirefox)
            {
                driver = _driverFactory.GetFirefox();
            }
            else
            {
                throw new WebDriverArgumentException("Browser is not supported");
            }

            return driver;
        }
    }
}

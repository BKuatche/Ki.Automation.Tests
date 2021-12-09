using Ki.Automation.Tests.Factories;
using Ki.Automation.Tests.Helpers;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Ki.Automation.Tests.Hook
{
    [Binding]
    public sealed class SpecflowHook
    {

        private readonly ScenarioContext _scenarioContext;

        public SpecflowHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = new BrowserFactory().GetBrowser();
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(driver);

            driver.Navigate().GoToUrl(ConfigurationHelper.BaseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigurationHelper.ElementTimeout);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(ConfigurationHelper.PageLoadTimeout);


          
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _scenarioContext.ScenarioContainer.Resolve<IWebDriver>();

            driver?.Quit();
            driver?.Dispose();
        }
    }
}
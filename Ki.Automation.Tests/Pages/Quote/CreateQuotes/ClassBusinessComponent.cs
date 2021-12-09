using Ki.Automation.Tests.Extensions;
using OpenQA.Selenium;

namespace Ki.Automation.Tests.Pages
{
    public class ClassBusinessComponent
    {
        private readonly IWebDriver _driver;
        private readonly IWebElement _container;

        public ClassBusinessComponent(IWebDriver driver)
        {
            _driver = driver;
            _container = _driver.FindElement(_classBusinessLocator);
        }

        #region Locator
        private readonly By _classBusinessLocator = By.CssSelector("div[role='radiogroup']");
        private readonly By _cyberBtnLocator = By.CssSelector("div[data-value='Cyber'][role='radio']");
        private readonly By _energyBtnLocator = By.CssSelector("div[data-value='Energy'][role='radio']");
        private readonly By _propertyBtnLocator = By.CssSelector("div[data-value='Property'][role='radio']");
        #endregion


        private IWebElement CyberBtn => _container.FindElement(_cyberBtnLocator);
        private IWebElement EnergyBtn => _container.FindElement(_energyBtnLocator);
        private IWebElement PropertyBtn => _container.FindElement(_propertyBtnLocator);
        private IWebElement CyberField => _container.FindElement(By.CssSelector("div#i13>div:nth-child(3)>div"));


        public void Cyber() => CyberField.RetryClick();

        public void Energy() => EnergyBtn.Click();

        public void Property() => PropertyBtn.Click();




    }
}

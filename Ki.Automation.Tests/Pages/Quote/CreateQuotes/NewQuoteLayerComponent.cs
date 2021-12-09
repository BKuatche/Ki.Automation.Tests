using OpenQA.Selenium;

namespace Ki.Automation.Tests.Pages.Quote
{
    public class NewQuoteLayerComponent
    {

        private readonly IWebDriver _driver;

        public NewQuoteLayerComponent(IWebDriver driver)
        {
            _driver = driver;
        }


        #region Locator
        private readonly By _dateLocator = By.CssSelector("input[type='date']");
        private readonly By _premiumFieldLocator = By.CssSelector("div.freebirdFormviewerViewItemList>div:nth-child(4)>div>div>div:nth-child(2)>div>div:nth-child(1)>div>div:nth-child(1)>input");
        private readonly By _pageTitleLocator = By.CssSelector("div.freebirdMaterialHeaderbannerPagebreakText");
        private readonly By _valueLocator = By.CssSelector("div.freebirdFormviewerViewItemList>div:nth-child(3)>div>div>div:nth-child(2)>div>div:nth-child(1)>div>div:nth-child(1)>input");
        #endregion


        private IWebElement DateField => _driver.FindElement(_dateLocator);
        private IWebElement PremiumField => _driver.FindElement(_premiumFieldLocator);
        private IWebElement ValueField => _driver.FindElement(_valueLocator);
        private IWebElement PageTitle => _driver.FindElement(_pageTitleLocator);


        public NewQuoteLayerComponent AddDate(string date)
        {
            DateField.SendKeys(date);

            return this;
        }


        public string GetPageTitle() => PageTitle.Text;

        public void Premium(string premium)
        {
            PremiumField.SendKeys(premium);
        }

        public void Value(string value)
        {
            ValueField.SendKeys(value);
        }
    }
}

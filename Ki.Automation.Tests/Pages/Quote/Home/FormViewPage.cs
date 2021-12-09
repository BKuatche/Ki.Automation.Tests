using OpenQA.Selenium;

namespace Ki.Automation.Tests.Pages.Home
{
    public class FormViewPage
    {
        private readonly IWebDriver _driver;
        private readonly IWebElement _container;

        public FormViewPage(IWebDriver driver)
        {
            _driver = driver;
            _container = _driver.FindElement(_formViewContainerLocator);
        }


        #region Locator
        private readonly By _formViewContainerLocator = By.CssSelector("div[role='list']");
        private readonly By _createQuoteLocator = By.CssSelector("div[data-value='Create a new quote'][role='radio']");
        private readonly By _pendingQuoteLocator = By.CssSelector("div[data-value='See my pending quotes'][role='radio']");
        #endregion


        private IWebElement CreateQuoteBtn => _container.FindElement(_createQuoteLocator);
        private IWebElement PendingQuoteBtn => _container.FindElement(_pendingQuoteLocator);


        public FormViewPage CreateQuote()
        {
            CreateQuoteBtn.Click();

            return this;
        }

        public FormViewPage PendingQuote()
        {
            PendingQuoteBtn.Click();

            return this;
        }


        public bool IsQuoteDisplayed() => CreateQuoteBtn.Displayed;

    }
}

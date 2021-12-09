using OpenQA.Selenium;
using System.Collections.Generic;

namespace Ki.Automation.Tests.Pages.Quote.PendingQuotes
{
    public class PendingQuote
    {
        private readonly IWebDriver _driver;

        public PendingQuote(IWebDriver driver)
        {
            _driver = driver;
        }


        #region Locator
        private readonly By _pageheaderLocator = By.CssSelector("div.freebirdMaterialHeaderbannerPagebreakText");
        private By _companyLocator(int index) => By.CssSelector("div.freebirdFormviewerViewItemList>div:nth-child(" + index + ")>div div");
        #endregion


        private IWebElement PageTitleTxt => _driver.FindElement(_pageheaderLocator);
        private IEnumerable<IWebElement> CompanyDetails(int index) => _driver.FindElements(_companyLocator(index));

        public string PageTitle => PageTitleTxt.Text;

        public List<string> CompanyDetails()
        {
            var list = new List<string>();

            for (int i = 2; i < 5; i++)
            {
                foreach (var item in CompanyDetails(i))
                {
                    list.Add(item.Text);
                }
            }


            return list;
        }
    }
}

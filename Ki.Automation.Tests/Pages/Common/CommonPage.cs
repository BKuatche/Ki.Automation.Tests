using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Ki.Automation.Tests.Pages.Common
{
    public class CommonPage
    {
        private readonly IWebDriver _driver;

        public CommonPage(IWebDriver driver)
        {
            _driver = driver;
        }

        #region Locator
        private readonly By _buttonLocator = By.CssSelector("div[role ='button']");
        private readonly By _pageTtileLocator = By.CssSelector("div.freebirdMaterialHeaderbannerPagebreakTex");
        #endregion



        private IEnumerable<IWebElement> Buttons => _driver.FindElements(_buttonLocator);
        private IWebElement PageTitleField => _driver.FindElement(_pageTtileLocator);


        public void Next()
        {
            foreach (var button in from button in Buttons
                                   where button.Text.Contains("Next")
                                   select button)
            {
                button.Click();
                break;
            }
        }


        public void ClearForm()
        {
            foreach (var button in from button in Buttons
                                   where button.Text.Contains("Clear form")
                                   select button)
            {
                button.Click();
                break;
            }
        }


        public void Back()
        {
            foreach (var button in from button in Buttons
                                   where button.Text.Contains("Back")
                                   select button)
            {
                button.Click();
                break;
            }
        }


        public string GetPageTitle() => PageTitleField.Text;
    }
}

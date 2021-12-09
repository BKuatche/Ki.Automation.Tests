using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Ki.Automation.Tests.Pages.Helpers
{
    public class WaitHelpers
    {
        private readonly WebDriverWait _wait;

        public WaitHelpers(IWebDriver driver, int timeout = 20)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
        }

        public IEnumerable<T> WaitForAllElements<T>(Func<IWebDriver, IEnumerable<T>> expectedConditions) where T : IWebElement
        {
            try
            {
                _wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
                return _wait.Until(expectedConditions);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace Ki.Automation.Tests.Extensions
{
    public static class WebElementExtensions
    {
        public static SelectElement AsSelect(this IWebElement element)
            => new(element);

        public static Actions Actions(this IWebElement element)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            return new Actions(driver);

        }

        public static bool RetryClick(this IWebElement element)
        {
            bool result = false;
            int attempts = 0;
            Thread.Sleep(2000);
            while (attempts < 3)
            {
                try
                {
                    element.Click();
                    result = true;
                    break;
                }
                catch (StaleElementReferenceException)
                {
                }
                attempts++;
            }
            return result;
        }


        public static IEnumerable<IWebElement> IsElementsVisible(this IWebDriver driver, By by, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d =>
            {
                var elements = d.FindElements(by).Where(i => i.Displayed).ToList();
                return new ReadOnlyCollection<IWebElement>(elements);
            });
        }

        
    }
}

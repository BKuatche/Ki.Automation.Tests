using FluentAssertions;
using Ki.Automation.Tests.Extensions;
using Ki.Automation.Tests.Pages.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ki.Automation.Tests.Pages
{
    public class InsureInfoComponent
    {
        public readonly IWebDriver _driver;
        private readonly WaitHelpers _wait;
        public InsureInfoComponent(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WaitHelpers(_driver);
        }

        #region Locator
        private readonly By _primaryTextLocator = By.CssSelector("div.quantumWizMenuPaperselectOptionList");
        private readonly By _primaryCountryTextLocator = By.CssSelector("div.hasError>div:nth-child(2)>div>div:nth-child(1)>div:nth-child(1)>div:nth-child(1)>span");
        private readonly By _primaryInsuredTextLocator = By.CssSelector("div.freebirdFormviewerViewItemList>div:nth-child(3)>div>div>div:nth-child(2)>div>div:nth-child(1)>div:nth-child(1)>div:nth-child(1)>span");
        private readonly By _primaryCountryDropdownLocator = By.CssSelector("div.hasError>div:nth-child(2)>div>div:nth-child(2) div span");
        private readonly By _insuredDropdownLocator = By.CssSelector("div.freebirdFormviewerViewItemList>div:nth-child(3)>div>div>div:nth-child(2)>div>div:nth-child(2) div span");
        #endregion


        private IEnumerable<IWebElement> PrimaryField => _wait.WaitForAllElements(ExpectedConditions.PresenceOfAllElementsLocatedBy(_primaryTextLocator));
        private IEnumerable<IWebElement> CountryDropdownList => _driver.IsElementsVisible(_primaryCountryDropdownLocator, 20);
        private IEnumerable<IWebElement> InsuredDropdownList => _driver.FindElements(_insuredDropdownLocator);
        private IWebElement PrimaryInsured => _driver.FindElement(_primaryInsuredTextLocator);


        public InsureInfoComponent SelectCountryByText(string country)
        {
            if (PrimaryField.Count().Equals(2))
            {
                Thread.Sleep(2000);
                PrimaryField.FirstOrDefault()
                   .Actions()
                   .ClickAndHold(PrimaryField.FirstOrDefault())
                   .Release()
                   .Build()
                   .Perform();

                foreach (var element in from element in CountryDropdownList
                                        where element.Text.Equals(country)
                                        select element)
                {

                    if (element.Displayed)
                    {
                        element.RetryClick();
                        break;
                    }
                    break;
                }
            }

            return this;
        }


        public InsureInfoComponent SelectInsuredByText(string insured)
        {
            if (PrimaryField.Count().Equals(2))
            {
                Thread.Sleep(2000);

                PrimaryInsured.RetryClick();

                foreach (var element in from element in InsuredDropdownList
                                        where element.Text.Equals(insured)
                                        select element)
                {
                    if (element.Displayed)
                    {
                        element.Click();
                        break;
                    }
                    break;

                }
            }

            return this;
        }


        public ClassBusinessComponent WithClassBusiness() => new(_driver);
    }
}

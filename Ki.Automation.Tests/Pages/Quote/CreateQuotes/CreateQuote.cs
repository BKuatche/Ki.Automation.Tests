using OpenQA.Selenium;
using System;

namespace Ki.Automation.Tests.Pages.Quote
{
    public class CreateQuote
    {
        private readonly InsureInfoComponent _insureInfoComponent;

        private readonly NewQuoteLayerComponent _newQuoteLayer;

        public CreateQuote(IWebDriver driver)
        {
            _insureInfoComponent = new InsureInfoComponent(driver);
            _newQuoteLayer = new NewQuoteLayerComponent(driver);
        }


        public CreateQuote SetInsuredInfo(Action<InsureInfoComponent> insured)
        {
            insured.Invoke(_insureInfoComponent);

            return this;
        }

        public CreateQuote SetQuoteLayer(Action<NewQuoteLayerComponent> quote)
        {
            quote.Invoke(_newQuoteLayer);

            return this;
        }
    }
}

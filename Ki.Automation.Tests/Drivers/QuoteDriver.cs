using FluentAssertions;
using Ki.Automation.Tests.Models;
using Ki.Automation.Tests.Pages.Common;
using Ki.Automation.Tests.Pages.Home;
using Ki.Automation.Tests.Pages.Quote;
using System.Threading;

namespace Ki.Automation.Tests.Drivers
{
    public class QuoteDriver
    {
        private readonly CreateQuote _quote;
        private readonly CommonPage _commonPage;
        private readonly FormViewPage _formViewPage;
        public QuoteDriver(CreateQuote quote, CommonPage commonPage,
            FormViewPage formViewPage)
        {
            _quote = quote;
            _commonPage = commonPage;
            _formViewPage = formViewPage;
        }


        public void UserCreateQuote(Quote quote)
        {
            _formViewPage.CreateQuote();
            FillQuoteForm(quote);
        }

        public void QuotePageIsDisplayed()
            => _formViewPage.IsQuoteDisplayed().Should().BeTrue();

        public string QuoteIsSuccessfullyCreate() => _commonPage.GetPageTitle();

        public void UserGoToPendingQuote()
        {
            _formViewPage.PendingQuote();
            _commonPage.Next();
        }


        public void USerFillThePendingQuoteForm(Quote quote)
        {
            FillQuoteForm(quote);
        }


        private void FillQuoteForm(Quote quote)
        {
            _commonPage.Next();

            _quote.SetInsuredInfo(m =>
            {
                Thread.Sleep(2000);
                m.SelectCountryByText(quote.Country);
                m.SelectInsuredByText(quote.Insured);
                m.WithClassBusiness().Cyber();
            });

            _commonPage.Next();

            _quote.SetQuoteLayer(m =>
            {
                Thread.Sleep(2000);
                m.AddDate(quote.Date);
                m.Value(quote.Value);
                m.Premium(quote.Premiun);
            });

            _commonPage.Next();
        }

    }
}

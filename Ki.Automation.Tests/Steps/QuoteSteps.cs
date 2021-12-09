using FluentAssertions;
using Ki.Automation.Tests.Builders;
using Ki.Automation.Tests.Drivers;
using Ki.Automation.Tests.Pages.Quote.PendingQuotes;
using Ki.Automation.Tests.Ressoures;
using System.Linq;
using TechTalk.SpecFlow;

namespace Ki.Automation.Tests.Steps
{
    [Binding]
    public sealed class QuoteSteps
    {
        private readonly QuoteDriver _quote;
        private readonly CreateQuoteBuilder _builder;
        private readonly PendingQuote _pendingQuote;
        public QuoteSteps(QuoteDriver quote, CreateQuoteBuilder builder,
            PendingQuote pendingQuote)
        {
            _quote = quote;
            _builder = builder;
            _pendingQuote = pendingQuote;
        }


        [Given(@"the quote form is displayed")]
        public void GivenTheQuoteFormIsDisplayed()
        {
            _quote.QuotePageIsDisplayed();
        }


        [When(@"user creates a quote")]
        public void WhenUserCreatesAQuote()
        {
            _quote.UserCreateQuote(_builder.CreateQuoteInstance);
        }

        [When(@"user clicks on view my pending quote")]
        public void WhenUserClicksOnViewMyPendingQuote()
        {
            _quote.UserGoToPendingQuote();
        }

        [When(@"user continue filling the quote form")]
        public void WhenUserContinueFillingTheQuoteForm()
        {
            _quote.USerFillTheQuoteForm(_builder.CreateQuoteInstance);
        }



        [Then(@"user should be able to view ""(.*)"" message")]
        public void ThenUserShouldBeAbleToViewMessage(string message)
        {
            _quote.QuoteIsSuccessfullyCreate().Should().Contain(message);
        }

        [Then(@"the pending quotes should be displayed")]
        public void ThenThePendingQuotesShouldBeDisplayed()
        {
            var companyName = _builder.CompanyDetails.Keys.ToList();
            var insurranceDetails = _builder.CompanyDetails.Values.ToList();

            _pendingQuote.PageTitle.Should().Contain(Title.PendingQuote);

            _pendingQuote.CompanyDetails()[0].Should().Contain(companyName[0]);
            _pendingQuote.CompanyDetails()[1].Should().Contain(insurranceDetails[0]);
            _pendingQuote.CompanyDetails()[3].Should().Contain(companyName[1]);
            _pendingQuote.CompanyDetails()[4].Should().Contain(insurranceDetails[1]);
            _pendingQuote.CompanyDetails()[6].Should().Contain(companyName[2]);
            _pendingQuote.CompanyDetails()[7].Should().Contain(insurranceDetails[2]);
        }

    }
}

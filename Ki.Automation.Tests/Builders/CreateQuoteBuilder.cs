using AutoFixture;
using Ki.Automation.Tests.Models;
using System;
using System.Collections.Generic;

namespace Ki.Automation.Tests.Builders
{
    public class CreateQuoteBuilder
    {
        private readonly Fixture _fixture;

        public CreateQuoteBuilder()
        {
            _fixture = new Fixture();
        }


        public Quote CreateQuoteInstance =>
            _fixture
            .Build<Quote>()
            .With(m => m.Country, "France")
            .With(m => m.Insured, "Newco Ltd")
            .With(m => m.Date, DateTime.Today.ToString("dd/mm/yyyy"))
            .With(m => m.Value, "234")
            .With(m => m.Premiun, "200")
            .Create();


        public Dictionary<string, string> CompanyDetails =>
            new Dictionary<string, string> 
            {
                {"Service Tech Ltd","CLASS: Cyber // PREMIUM: $560K" },
                {"Logistics Worldwide Inc","CLASS: Property // PREMIUM: $2.4M" },
                {"XYZ Holdings PLC","CLASS: Energy // PREMIUM: $1.3M" }

            };
    }
}

using System;
using System.Data.Entity;
using EF.Entities;

namespace EF
{
    public class EFContextInitializer : DropCreateDatabaseIfModelChanges<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            //
            // ### RATES ###

            var rate1 = new RateEF
            {
                Time = DateTime.Today,
                Value = 2.0
            };

            var rate2 = new RateEF
            {
                Time = DateTime.Today,
                Value = 4.2
            };

            var rate3 = new RateEF
            {
                Time = DateTime.Today,
                Value = 1.9
            };

            var rate4 = new RateEF
            {
                Time = DateTime.Today,
                Value = 2.5
            };

            var rate5 = new RateEF
            {
                Time = DateTime.Today,
                Value = 2.2
            };

            var rate6 = new RateEF
            {
                Time = DateTime.Today,
                Value = 3.0
            };

            //
            // ### CURRENCIES ###

            var PLN = new CurrencyEF
            {
                Name = "PLN",
                LastUpdate = DateTime.Today,
                CurrentValue = 2.0,
            };

            var EUR = new CurrencyEF
            {
                Name = "EUR",
                LastUpdate = DateTime.Today,
                CurrentValue = 3.0,
            };

            PLN.Rates.Add(rate1);
            PLN.Rates.Add(rate2);
            PLN.Rates.Add(rate3);

            EUR.Rates.Add(rate4);
            EUR.Rates.Add(rate5);
            EUR.Rates.Add(rate6);

            //
            // saving changes

            context.Currencies.Add(PLN);
            context.Currencies.Add(EUR);
            context.SaveChanges();
        }
    }
}

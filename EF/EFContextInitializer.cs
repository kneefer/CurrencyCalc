using System;
using System.Data.Entity;
using EF.Entities;

namespace EF
{
    public class EFContextInitializer : DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext context)
        {
            //
            // ### RATES ###

            var rate01 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(0), Value = 0.32 };
            var rate02 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(1), Value = 0.23 };
            var rate03 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(2), Value = 0.25 };
            var rate04 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(3), Value = 0.33 };
            var rate05 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(4), Value = 0.35 };
            var rate06 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(5), Value = 0.30 };

            var rate07 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(0), Value = 1.53 };
            var rate08 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(1), Value = 1.26 };
            var rate09 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(2), Value = 1.36 };
            var rate10 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(3), Value = 1.48 };
            var rate11 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(4), Value = 1.31 };
            var rate12 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(5), Value = 1.28 };

            var rate13 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(0), Value = 1.13 };
            var rate14 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(1), Value = 1.01 };
            var rate15 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(2), Value = 1.23 };
            var rate16 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(3), Value = 1.37 };
            var rate17 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(4), Value = 1.22 };
            var rate18 = new RateEF { Time = DateTime.Today + TimeSpan.FromHours(5), Value = 1.25 };

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

            var CHF = new CurrencyEF
            {
                Name = "CHF",
                LastUpdate = DateTime.Today,
                CurrentValue = 3.2,
            };

            PLN.Rates.Add(rate01);
            PLN.Rates.Add(rate02);
            PLN.Rates.Add(rate03);
            PLN.Rates.Add(rate04);
            PLN.Rates.Add(rate05);
            PLN.Rates.Add(rate06);

            EUR.Rates.Add(rate07);
            EUR.Rates.Add(rate08);
            EUR.Rates.Add(rate09);
            EUR.Rates.Add(rate10);
            EUR.Rates.Add(rate11);
            EUR.Rates.Add(rate12);

            CHF.Rates.Add(rate13);
            CHF.Rates.Add(rate14);
            CHF.Rates.Add(rate15);
            CHF.Rates.Add(rate16);
            CHF.Rates.Add(rate17);
            CHF.Rates.Add(rate18);

            //
            // saving changes

            context.Currencies.Add(PLN);
            context.Currencies.Add(EUR);
            context.Currencies.Add(CHF);
            context.SaveChanges();
        }
    }
}

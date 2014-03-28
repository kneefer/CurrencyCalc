using System.Collections.Generic;
using CurrencyCalc.Utilities;

namespace CurrencyCalc.Pages
{
    public partial class Live
    {
        public Live()
        {
            InitializeComponent();

            var rest = new YahooXChangeRest();
            rest.TakeExchangesAsync(new List<string> {"USD", "EUR", "CHF"}, "PLN");
        }
    }
}

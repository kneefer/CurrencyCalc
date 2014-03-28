using System;
using System.Linq;
using CurrencyCalc.Infrastructure;
using EF;
using FirstFloor.ModernUI.Presentation;

namespace CurrencyCalc.ViewModels
{
    public partial class HistoryViewModel
    {
        private EFContext _context = new EFContext();

        public HistoryViewModel()
        {
            Currencies = _context.Currencies.ToLinksCollection();

            SelectedCurrencyLink = Currencies.Count > 0
                ? Currencies.First()
                : new Link
                {
                    DisplayName = "xD",
                    Source = new Uri("/Content/DefaultCurrencyHistory.xaml",
                        UriKind.RelativeOrAbsolute)
                };
        }
    }
}

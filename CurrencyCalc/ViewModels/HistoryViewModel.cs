using System;
using System.Linq;
using CurrencyCalc.Infrastructure;
using EF;
using FirstFloor.ModernUI.Presentation;
using GalaSoft.MvvmLight.Messaging;

namespace CurrencyCalc.ViewModels
{
    public partial class HistoryViewModel
    {
        private EFContext _context = new EFContext();

        public HistoryViewModel()
        {
            Currencies = _context.Currencies.ToLinksCollection();

            SelectedCurrencyLink = Currencies.Count > 0
                ? Currencies.First().Source
                : new Uri("/Content/DefaultCurrencyHistory.xaml",
                    UriKind.Relative);
        }

        private void SelectedCurrencyLinkChanged(Uri link)
        {
            string currencyName;
            link.ParseQueryString().TryGetValue("Name", out currencyName);

            var selectedCurrency = _context.Currencies.FirstOrDefault(x => x.Name == currencyName);

            if (selectedCurrency != null)
                Messenger.Default.Send(selectedCurrency);
        }
    }
}

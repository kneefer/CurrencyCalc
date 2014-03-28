using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using CurrencyCalc.Infrastructure;
using EF;
using EF.Entities;
using FirstFloor.ModernUI.Presentation;
using GalaSoft.MvvmLight.Messaging;
using System.Threading.Tasks;

namespace CurrencyCalc.ViewModels
{
    public partial class HistoryViewModel
    {
        private EFContext _context = App.Context;
        private readonly Task _initializingTask;

        public HistoryViewModel()
        {
            _initializingTask = LoadCurrencies();
        }

        private async Task LoadCurrencies()
        {
            Currencies = (await _context.Currencies.ToListAsync()).ToLinksCollection();

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

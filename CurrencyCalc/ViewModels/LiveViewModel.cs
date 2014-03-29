using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using CurrencyCalc.Infrastructure;
using CurrencyCalc.Utilities;
using EF;
using EF.Entities;
using FirstFloor.ModernUI.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace CurrencyCalc.ViewModels
{
    public partial class LiveViewModel
    {
        private readonly EFContext _context = App.Context;
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private const int IntervalOfUpdateInMinutes = 20;
        
        public LiveViewModel()
        {
            InitializeCommands();
            Currencies = new ObservableCollection<CurrencyEF>(_context.Currencies);

            // selecting default currency
            BaseCurrency = Currencies.FirstOrDefault();

            _timer.Interval = TimeSpan.FromMinutes(IntervalOfUpdateInMinutes);
            _timer.Tick += async (sender, args) => await UpdateCurrencies();
            _timer.Start();
        }

        private async void AddNewCurrency()
        {
            IsBusy = true;
            if (_context.Currencies.FirstOrDefault(x => x.Name.Equals(
                NewCurrencyName, StringComparison.CurrentCultureIgnoreCase)) == null)
            {
                if (string.IsNullOrEmpty(NewCurrencyName))
                {
                    IsBusy = false;
                    return;
                }
                var rest = new YahooXChangeRest();
                var foundCurrency = await rest.CheckIfCurrencyExistsAsync(NewCurrencyName, BaseCurrency.Name);

                if (foundCurrency == null)
                {
                    new ModernDialog
                    {
                        Title = "Error",
                        Content = "No currency with symbol: " + NewCurrencyName.ToUpper()
                    }.Show();

                    NewCurrencyName = String.Empty;
                    IsBusy = false;
                    return;
                }

                var res = foundCurrency.MapToEntity();
                _context.Currencies.Add(res);
                await _context.SaveChangesAsync();

                // adding to an observable collections
                Messenger.Default.Send(res, "newCurrencyMsg");
                Currencies.Add(res);
            }
            else
            {
                new ModernDialog
                {
                    Title = "Error",
                    Content = "Following currency already exists: " + NewCurrencyName.ToUpper()
                }.Show();
            }

            NewCurrencyName = String.Empty;
            IsBusy = false;
        }
        
        private void SwapCurrencies()
        {
            var memory = MoneyCalcModel.OutputMoney;
            var memory2 = MoneyCalcModel.OutputCurrency;

            MoneyCalcModel.OutputMoney = MoneyCalcModel.InputMoney;
            MoneyCalcModel.InputMoney = memory;

            MoneyCalcModel.OutputCurrency = MoneyCalcModel.InputCurrency;
            MoneyCalcModel.InputCurrency = memory2;
        }

        private async void BaseCurrencyChanged()
        {
            await UpdateCurrencies();
            MoneyCalcModel.OutputMoney = MoneyCalcModel.CalculateOutput();
        }

        private async Task UpdateCurrencies()
        {
            IsBusy = true;
            var rest = new YahooXChangeRest();
            var currencies = await rest.TakeExchangesAsync(
                Currencies.ToListOfString(),
                BaseCurrency.Name);

            if (currencies == null)
            {
                new ModernDialog
                {
                    Title = "Error",
                    Content = "Connection problems"
                }.Show();
            }
            else
            {
                Currencies.Update(currencies);
            }
            IsBusy = false;
        }

        private void InputChanged(string str)
        {
            MoneyCalcModel.OutputMoney = MoneyCalcModel.CalculateOutput(str);
        }
    }
}

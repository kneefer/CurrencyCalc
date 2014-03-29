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
            _timer.Tick += (sender, args) => UpdateCurrencies();
            _timer.Start();
        }

        private async void AddNewCurrency()
        {
            if (_context.Currencies.FirstOrDefault(x => x.Name.Equals(
                NewCurrencyName, StringComparison.CurrentCultureIgnoreCase)) == null)
            {
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
            var rest = new YahooXChangeRest();
            var currencies = await rest.TakeExchangesAsync(
                Currencies.ToListOfString(),
                BaseCurrency.Name);

            Currencies.Update(currencies);
        }

        private void InputChanged(string str)
        {
            MoneyCalcModel.OutputMoney = MoneyCalcModel.CalculateOutput(str);
        }
    }
}

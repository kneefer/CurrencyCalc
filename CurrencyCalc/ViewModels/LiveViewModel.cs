using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
        private EFContext _context = App.Context;
        
        public LiveViewModel()
        {
            InitializeCommands();
            Currencies = new ObservableCollection<CurrencyEF>(_context.Currencies);

            MoneyCalcModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName.Equals("InputMoney")) ProceedCalculation();
            };
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

                    return;
                }

                var res = foundCurrency.MapToEntity();
                _context.Currencies.Add(res);
                await _context.SaveChangesAsync();

                // adding to observable collections
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

        private void ProceedCalculation()
        {
            //throw new System.NotImplementedException();
        }
        
        private void SwapCurrencies()
        {
            var memory = MoneyCalcModel.OutputMoney;
            var memory2 = MoneyCalcModel.OutputCurrSymbol;

            MoneyCalcModel.OutputMoney = MoneyCalcModel.InputMoney;
            MoneyCalcModel.InputMoney = memory;

            MoneyCalcModel.OutputCurrSymbol = MoneyCalcModel.InputCurrSymbol;
            MoneyCalcModel.InputCurrSymbol = memory2;
        }

        private async void BaseCurrencyChanged()
        {
            await UpdateCurrencies();
        }

        private async Task UpdateCurrencies()
        {
            var rest = new YahooXChangeRest();
            var currencies = await rest.TakeExchangesAsync(
                Currencies.ToListOfString(),
                BaseCurrency.Name);


        }
    }
}

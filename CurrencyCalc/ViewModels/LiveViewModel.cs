using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CurrencyCalc.Utilities;
using EF;
using EF.Entities;

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

                if (foundCurrency != null)
                {
                    var res = foundCurrency.MapToEntity();
                    MessageBox.Show("DUPA");
                }
            }
        }

        private void ProceedCalculation()
        {
            //throw new System.NotImplementedException();
        }
        
        private void ReverseCurrencies()
        {
            var memory = MoneyCalcModel.OutputMoney;

            MoneyCalcModel.OutputMoney = MoneyCalcModel.InputMoney;
            MoneyCalcModel.InputMoney = memory;
        }
        
    }
}

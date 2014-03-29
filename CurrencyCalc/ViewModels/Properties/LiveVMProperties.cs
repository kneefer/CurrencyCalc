using System.Collections.ObjectModel;
using CurrencyCalc.Models;
using EF.Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CurrencyCalc.ViewModels
{
    public partial class LiveViewModel : ViewModelBase
    {
        public RelayCommand ReverseCurrenciesCommand { get; set; }
        public RelayCommand AddNewCurrencyCommand { get; set; }

        private ObservableCollection<CurrencyEF> _currencies;
        private MoneyCalcModel _moneyCalcModel = new MoneyCalcModel();
        private CurrencyEF _selectedCurrencyEF;
        private CurrencyEF _baseCurrency;
        private string _newCurrencyName;

        public CurrencyEF SelectedCurrency
        {
            get { return _selectedCurrencyEF; }
            set
            {
                if (value != _selectedCurrencyEF)
                {
                    _selectedCurrencyEF = value;
                    RaisePropertyChanged("SelectedCurrency");
                    ProceedCalculation();
                }
            }
        }
        public CurrencyEF BaseCurrency
        {
            get { return _baseCurrency; }
            set
            {
                if (value != _baseCurrency)
                {
                    _baseCurrency = value;
                    RaisePropertyChanged("BaseCurrency");
                    ProceedCalculation();
                }
            }
        }
        public MoneyCalcModel MoneyCalcModel
        {
            get { return _moneyCalcModel; }
            set
            {
                if (value != _moneyCalcModel)
                {
                    _moneyCalcModel = value;
                    RaisePropertyChanged("MoneyCalcModel");
                    ProceedCalculation();
                }
            }
        }
        public ObservableCollection<CurrencyEF> Currencies
        {
            get { return _currencies; }
            set
            {
                if (value != _currencies)
                {
                    _currencies = value;
                    RaisePropertyChanged("Currencies");
                }
            }
        }
        public string NewCurrencyName
        {
            get { return _newCurrencyName; }
            set
            {
                if (value != _newCurrencyName)
                {
                    _newCurrencyName = value;
                    RaisePropertyChanged("NewCurrencyName");
                }
            }
        }

        private void InitializeCommands()
        {
            ReverseCurrenciesCommand = new RelayCommand(ReverseCurrencies);
            AddNewCurrencyCommand = new RelayCommand(AddNewCurrency);
        }
    }
}

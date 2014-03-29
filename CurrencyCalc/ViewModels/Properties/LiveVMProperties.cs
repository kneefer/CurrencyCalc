using System;
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
        public RelayCommand<string> InputChangedCommand { get; set; }

        private ObservableCollection<CurrencyEF> _currencies;
        private MoneyCalcModel _moneyCalcModel = new MoneyCalcModel();
        private CurrencyEF _selectedCurrencyEF;
        private CurrencyEF _baseCurrency;
        private string _newCurrencyName;
        private bool _isBusy;

        public CurrencyEF SelectedCurrency
        {
            get { return _selectedCurrencyEF; }
            set
            {
                if (value != _selectedCurrencyEF)
                {
                    _selectedCurrencyEF = value;
                    RaisePropertyChanged("SelectedCurrency");
                    MoneyCalcModel.InputCurrency = value;
                    MoneyCalcModel.OutputCurrency = BaseCurrency;
                    MoneyCalcModel.OutputMoney = MoneyCalcModel.CalculateOutput();
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
                    MoneyCalcModel.InputCurrency = SelectedCurrency;
                    MoneyCalcModel.OutputCurrency = value;
                    BaseCurrencyChanged();
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
                }
            }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                if (value != _isBusy)
                {
                    _isBusy = value;
                    RaisePropertyChanged("IsBusy");
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
            ReverseCurrenciesCommand = new RelayCommand(SwapCurrencies);
            AddNewCurrencyCommand = new RelayCommand(AddNewCurrency);
            InputChangedCommand = new RelayCommand<string>(InputChanged);
        }
    }
}

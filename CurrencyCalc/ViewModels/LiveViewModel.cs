using System;
using System.Collections.ObjectModel;
using System.Windows;
using EF.Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CurrencyCalc.ViewModels
{
    public class LiveViewModel : ViewModelBase
    {
        public RelayCommand ReverseCurrenciesCommand { get; set; }
        private ObservableCollection<CurrencyEF> _currencies;
        private string _inputMoney;
        private string _outputMoney;

        public string InputMoney
        {
            get { return _inputMoney; }
            set
            {
                if (value != _inputMoney)
                {
                    _inputMoney = value;
                    ProceedCalculation();
                    RaisePropertyChanged("InputMoney");
                }
            }
        }
        public string OutputMoney
        {
            get { return _outputMoney; }
            set
            {
                if (value != _outputMoney)
                {
                    _outputMoney = value;
                    RaisePropertyChanged("OutputMoney");
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
        
        public LiveViewModel()
        {
            ReverseCurrenciesCommand = new RelayCommand(ReverseCurrencies);
        }

        private void ProceedCalculation()
        {
            //throw new System.NotImplementedException();
        }
        
        
        

        private void ReverseCurrencies()
        {
            var memory = OutputMoney;

            OutputMoney = InputMoney;
            InputMoney = memory;
        }
        
    }
}

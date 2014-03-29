using System;
using EF.Entities;
using FirstFloor.ModernUI.Presentation;

namespace CurrencyCalc.Models
{
    public class MoneyCalcModel : NotifyPropertyChanged
    {
        private double _inputMoney;
        private double _outputMoney;
        private CurrencyEF _inputCurrency;
        private CurrencyEF _outputCurrency;

        public double InputMoney
        {
            get { return _inputMoney; }
            set
            {
                if (value != _inputMoney)
                {
                    _inputMoney = value;
                    OnPropertyChanged("InputMoney");
                }
            }
        }
        public double OutputMoney
        {
            get { return _outputMoney; }
            set
            {
                if (value != _outputMoney)
                {
                    _outputMoney = value;
                }
                _outputMoney = value;
                OnPropertyChanged("OutputMoney");
            }
        }

        public CurrencyEF InputCurrency
        {
            get { return _inputCurrency; }
            set
            {
                if (value != _inputCurrency)
                {
                    _inputCurrency = value;
                    OnPropertyChanged("InputCurrency");
                }
            }
        }
        public CurrencyEF OutputCurrency
        {
            get { return _outputCurrency; }
            set
            {
                if (value != _outputCurrency)
                {
                    _outputCurrency = value;
                    OnPropertyChanged("OutputCurrency");
                }
            }
        }

        public double CalculateOutput(string str = null)
        {
            try
            {
                if (str == null)
                {
                    return Math.Round((InputMoney * InputCurrency.CurrentValue) / OutputCurrency.CurrentValue, 4);
                }
                else
                {
                    str = str.Replace(".", ",");
                    return Math.Round((Double.Parse(str)*InputCurrency.CurrentValue)/OutputCurrency.CurrentValue, 4);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}

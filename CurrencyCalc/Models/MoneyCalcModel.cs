using FirstFloor.ModernUI.Presentation;

namespace CurrencyCalc.Models
{
    public class MoneyCalcModel : NotifyPropertyChanged
    {
        private double _inputMoney;
        private double _outputMoney;
        private string _inputCurrSymbol;
        private string _outputCurrSymbol;

        public double InputMoney
        {
            get { return _inputMoney; }
            set
            {
                _inputMoney = value;
                OnPropertyChanged("InputMoney");
            }
        }
        public double OutputMoney
        {
            get { return _outputMoney; }
            set
            {
                _outputMoney = value;
                OnPropertyChanged("OutputMoney");
            }
        }
        public string InputCurrSymbol
        {
            get { return _inputCurrSymbol; }
            set
            {
                _inputCurrSymbol = value;
                OnPropertyChanged("InputCurrSymbol");
            }
        }
        public string OutputCurrSymbol
        {
            get { return _outputCurrSymbol; }
            set
            {
                _outputCurrSymbol = value;
                OnPropertyChanged("OutputCurrSymbol");
            }
        }
    }
}

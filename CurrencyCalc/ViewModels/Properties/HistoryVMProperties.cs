using FirstFloor.ModernUI.Presentation;
using GalaSoft.MvvmLight;

namespace CurrencyCalc.ViewModels
{
    public partial class HistoryViewModel : ViewModelBase
    {
        private LinkCollection _currencies;
        public LinkCollection Currencies
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

        private Link _selectedCurrencyLink;

        public Link SelectedCurrencyLink
        {
            get { return _selectedCurrencyLink; }
            set
            {
                if (value != _selectedCurrencyLink)
                {
                    _selectedCurrencyLink = value;
                    RaisePropertyChanged("SelectedCurrencyLink");
                }
            }
        }
        
    }
}

using System;
using EF.Entities;
using FirstFloor.ModernUI.Presentation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

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

        private Uri _selectedCurrencyLink;
        public Uri SelectedCurrencyLink
        {
            get { return _selectedCurrencyLink; }
            set
            {
                if (value != _selectedCurrencyLink)
                {
                    _selectedCurrencyLink = value;
                    RaisePropertyChanged("SelectedCurrencyLink");
                    SelectedCurrencyLinkChanged(value);
                }
            }
        }
    }
}

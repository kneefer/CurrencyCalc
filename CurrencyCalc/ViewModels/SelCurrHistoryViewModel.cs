using EF.Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace CurrencyCalc.ViewModels
{
    public class SelCurrHistoryViewModel : ViewModelBase
    {
        private CurrencyEF _currency;
        public CurrencyEF Currency
        {
            get { return _currency; }
            set
            {
                if (value != _currency)
                {
                    _currency = value;
                    RaisePropertyChanged("Currency");
                }
            }
        }

        public SelCurrHistoryViewModel()
        {
            Messenger.Default.Register<CurrencyEF>(this, Handle);
        }

        private void Handle(CurrencyEF currency)
        {
            Currency = currency;
        }
    }
}

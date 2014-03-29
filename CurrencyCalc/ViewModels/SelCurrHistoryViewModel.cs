using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EF.Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace CurrencyCalc.ViewModels
{
    public class SelCurrHistoryViewModel : ViewModelBase
    {
        private const int LimitOfPoints = 10;

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

        public IEnumerable<RateEF> Rates
        {
            get { return _currency.Rates.Take(LimitOfPoints); }
        }

        public SelCurrHistoryViewModel()
        {
            Messenger.Default.Register<CurrencyEF>(this, x =>
            {
                Currency = x;
                ReloadChart();
            });
        }

        private void ReloadChart()
        {
            //throw new System.NotImplementedException();
        }
    }
}

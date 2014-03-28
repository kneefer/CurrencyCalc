using System.Windows;
using EF;
using GalaSoft.MvvmLight;
using System.Data.Entity;

namespace CurrencyCalc.ViewModels
{
    public class HistoryViewModel : ViewModelBase
    {
        private EFContext _context = new EFContext();

        public HistoryViewModel()
        {
            App.Context.Currencies.LoadAsync();
            MessageBox.Show(string.Join(", ", _context.Currencies));
        }
    }
}

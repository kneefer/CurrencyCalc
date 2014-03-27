using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CurrencyCalc.ViewModels
{
    public class LiveViewModel : ViewModelBase
    {
        public RelayCommand ButtonCommand { get; set; }
        public LiveViewModel()
        {
            ButtonCommand = new RelayCommand(OKFunc);
        }

        private void OKFunc()
        {
            MessageBox.Show("ok");
        }
        
    }
}

using CurrencyCalc.ViewModels;
using FirstFloor.ModernUI.Windows.Controls;

namespace CurrencyCalc.Pages
{
    public partial class History
    {
        public History()
        {
            InitializeComponent();
        }

        private void ModernTab_OnSelectedSourceChanged(object sender, SourceEventArgs e)
        {
            var vm = DataContext as HistoryViewModel;
            if (vm != null)
            {
                vm.(null);
            }
        }
    }
}

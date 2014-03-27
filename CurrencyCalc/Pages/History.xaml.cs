using CurrencyCalc.ViewModels;

namespace CurrencyCalc.Pages
{
    public partial class History
    {
        public History()
        {
            InitializeComponent();
            DataContext = new HistoryViewModel();
        }
    }
}

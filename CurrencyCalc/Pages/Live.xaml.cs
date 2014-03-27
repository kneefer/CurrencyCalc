using CurrencyCalc.ViewModels;

namespace CurrencyCalc.Pages
{
    public partial class Live
    {
        public Live()
        {
            InitializeComponent();
            DataContext = new LiveViewModel();
        }
    }
}

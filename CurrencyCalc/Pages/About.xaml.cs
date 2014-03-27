using CurrencyCalc.ViewModels;

namespace CurrencyCalc.Pages
{
    public partial class About
    {
        public About()
        {
            InitializeComponent();
            DataContext = new AboutViewModel();
        }
    }
}

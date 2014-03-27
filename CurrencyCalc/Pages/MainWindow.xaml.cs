using CurrencyCalc.ViewModels;

namespace CurrencyCalc.Pages
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}

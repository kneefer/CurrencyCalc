using System.Data.Entity;
using System.Windows;
using EF;
using FirstFloor.ModernUI.Presentation;

namespace CurrencyCalc
{
    public partial class App : Application
    {
        public static EFContext Context { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Database.SetInitializer(new EFContextInitializer());
            Context = new EFContext();

            AppearanceManager.Current.FontSize = FontSize.Large;
        }
    }
}

using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using EF;

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
        }
    }
}

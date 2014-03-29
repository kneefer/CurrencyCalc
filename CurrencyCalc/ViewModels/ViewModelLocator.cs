using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace CurrencyCalc.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<LiveViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register<HistoryViewModel>(true);
            SimpleIoc.Default.Register<SelCurrHistoryViewModel>(true);
        }

        public LiveViewModel Live
        {
            get
            {
                
                return ServiceLocator.Current.GetInstance<LiveViewModel>();
            }
        }

        public AboutViewModel About
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutViewModel>();
            }
        }

        public HistoryViewModel History
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HistoryViewModel>();
            }
        }

        public SelCurrHistoryViewModel SelCurrHistory
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelCurrHistoryViewModel>();
            }
        }
        
        public static void Cleanup()
        {
        }
    }
}
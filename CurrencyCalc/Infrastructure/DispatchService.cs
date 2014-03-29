using System;
using System.Windows;

namespace CurrencyCalc.Infrastructure
{
    public static class DispatchService
    {
        public static void Invoke(Action action)
        {
            var dispatchObject = Application.Current.Dispatcher;
            if (dispatchObject == null || dispatchObject.CheckAccess())
            {
                action();
            }
            else
            {
                dispatchObject.Invoke(action);
            }
        }
    }
}

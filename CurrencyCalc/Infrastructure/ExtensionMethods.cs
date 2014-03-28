using System;
using System.Collections;
using System.Collections.Generic;
using EF.Entities;
using FirstFloor.ModernUI.Presentation;

namespace CurrencyCalc.Infrastructure
{
    public static class ExtensionMethods
    {
        public static LinkCollection ToLinksCollection(this IEnumerable<CurrencyEF> currencies)
        {
            var toReturn = new LinkCollection();

            foreach (var currency in currencies)
            {
                toReturn.Add(new Link
                {
                    DisplayName = currency.Name,
                    Source = new Uri(
                        "/Content/SelectedCurrencyHistory.xaml?Name=" + currency.Name,
                        UriKind.RelativeOrAbsolute)
                });
            }

            return toReturn;
        }
    }
}

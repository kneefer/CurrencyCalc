using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using EF.Entities;
using FirstFloor.ModernUI.Presentation;

namespace CurrencyCalc.Infrastructure
{
    public static class ExtensionMethods
    {
        private static readonly Regex _regex = new Regex(@"[?|&](\w+)=([^?|^&]+)");

        public static IReadOnlyDictionary<string, string> ParseQueryString(this Uri uri)
        {
            var match = _regex.Match(uri.OriginalString);
            var paramaters = new Dictionary<string, string>();
            while (match.Success)
            {
                paramaters.Add(match.Groups[1].Value, match.Groups[2].Value);
                match = match.NextMatch();
            }
            return paramaters;
        }

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
                        UriKind.Relative)
                });
            }

            return toReturn;
        }
    }
}

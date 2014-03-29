using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using CurrencyCalc.Models;
using CurrencyCalc.Utilities;
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
                toReturn.Add(currency.ToLink());
            }

            return toReturn;
        }

        public static Link ToLink(this CurrencyEF currency)
        {
            return new Link()
            {
                DisplayName = currency.Name,
                Source = new Uri(
                    "/Content/SelectedCurrencyHistory.xaml?Name=" + currency.Name,
                    UriKind.Relative)
            };
        }

        public static IEnumerable<string> ToListOfString(this IEnumerable<CurrencyEF> currencies)
        {
            return currencies.Select(x => x.Name);
        }

        public static void Update(this IEnumerable<CurrencyEF> currencies, IEnumerable<rate> newCurrencies)
        {
            foreach (var currency in currencies)
            {
                currency.CurrentValue = newCurrencies.First(x => x.Id.Substring(0, 3) == currency.Name).Rate.MapTheDouble();
            }
        } 
    }
}

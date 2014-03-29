using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyCalc.Models;
using RestSharp;
using RestSharp.Extensions;

namespace CurrencyCalc.Utilities
{
    public class YahooXChangeRest
    {
        private const string BaseUrl = @"http://query.yahooapis.com/v1/public/";
        private readonly RestClient _client;
        public YahooXChangeRest()
        {
            _client = new RestClient(BaseUrl) {Timeout = 2000};
        }

        public Task<IEnumerable<rate>> TakeExchangesAsync(IEnumerable<string> currencies, string baseCurrency, IEnumerable<string> columnsList = null)
        {
            // if there weren't any selections - default parameter
            if (columnsList == null) columnsList = new List<string> {"*"};

            currencies = currencies.Select(x => x += baseCurrency);

            // provides async result in the caller
            var tcs = new TaskCompletionSource<IEnumerable<rate>>();

            var resource = String.Format(@"yql?q=select {3} from yahoo.finance.xchange {0}{1}{2}",
                                          "where pair in (%22" + currencies.Aggregate((a, b) => String.Format("{0}%22,%22{1}", a, b)) + "%22)",
                                          "&format=json",
                                          "&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys",
                                          columnsList.Aggregate((a, b) => a + "," + b))
                .HtmlDecode();

            var request = new RestRequest(resource, Method.GET);

            _client.ExecuteAsync<RootObject>(request, result => tcs.SetResult(result.ResponseStatus == ResponseStatus.TimedOut
                ? null
                : result.Data.Query.Results.Rate));

            return tcs.Task;
        }

        public async Task<rate> CheckIfCurrencyExistsAsync(string currencyName, string baseCurrency)
        {
            var found = await TakeExchangesAsync(new List<string> {currencyName}, baseCurrency);
            if (found == null) return null;

            var foundList = found as IList<rate> ?? found.ToList();
            if (foundList.First().Rate != "0.00")
            {
                return foundList.First();
            }
            return null;
        }
    }
}

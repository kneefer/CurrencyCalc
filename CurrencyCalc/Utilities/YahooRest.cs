using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
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
            _client = new RestClient(BaseUrl);
        }

        public Task<IEnumerable<Rate>> DoXChangeRequestAsync(IEnumerable<string> currencies, IEnumerable<string> columnsList = null)
        {
            // if there weren't any selections - default parameter
            if (columnsList == null) columnsList = new List<string> {"*"};

            // provides async result in the caller
            var tcs = new TaskCompletionSource<IEnumerable<Rate>>();

            var resource = String.Format(@"yql?q=select {3} from yahoo.finance.xchange {0}{1}{2}",
                                          "where pair in (%22" + currencies.Aggregate((a, b) => String.Format("{0}%22%2C%22{1}", a, b)) + "%22)",
                                          "&format=json",
                                          "&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys",
                                          columnsList.Aggregate((a, b) => a + "," + b))
                .HtmlDecode();

            var request = new RestRequest(resource, Method.GET);
            _client.ExecuteAsync<RootObject>(request, result => tcs.SetResult(result.Data.Query.Results.Rate));

            return tcs.Task;
        }
    }
}

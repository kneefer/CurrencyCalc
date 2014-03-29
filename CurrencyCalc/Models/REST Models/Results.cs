using System.Collections.Generic;
using RestSharp.Serializers;

namespace CurrencyCalc.Models
{
    public class Results
    {
        public List<rate> Rate { get; set; }
    }
}

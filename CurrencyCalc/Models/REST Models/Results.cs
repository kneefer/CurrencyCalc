using System.Collections.Generic;
using RestSharp.Serializers;

namespace CurrencyCalc.Models
{
    public class Results
    {
        [SerializeAs(Name = "Rate")]
        public List<Rate> Rates { get; set; }
    }
}

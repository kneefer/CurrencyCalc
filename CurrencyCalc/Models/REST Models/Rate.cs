using RestSharp.Serializers;

namespace CurrencyCalc.Models
{
    public class Rate
    {
        [SerializeAs(Name = "Rate")]
        public string RateValue { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Ask { get; set; }
        public string Bid { get; set; }
    }
}

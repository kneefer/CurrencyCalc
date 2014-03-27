using RestSharp.Serializers;

namespace CurrencyCalc.Models
{
    public class Query
    {
        [SerializeAs(Name = "Lang")]
        public string Language { get; set; }
        public int Count { get; set; }
        public string Created { get; set; }   
        public Results Results { get; set; }
    }
}

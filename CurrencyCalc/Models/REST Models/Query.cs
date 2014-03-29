using RestSharp.Serializers;

namespace CurrencyCalc.Models
{
    public class Query
    {
        public string Lang { get; set; }
        public int Count { get; set; }
        public string Created { get; set; }   
        public Results Results { get; set; }
    }
}

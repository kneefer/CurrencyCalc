﻿using RestSharp.Serializers;

namespace CurrencyCalc.Models
{
    public class rate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Rate { get; set; }
        public string Ask { get; set; }
        public string Bid { get; set; }
    }
}

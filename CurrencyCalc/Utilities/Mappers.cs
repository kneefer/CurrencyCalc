using System;
using System.Windows;
using CurrencyCalc.Models;
using EF.Entities;

namespace CurrencyCalc.Utilities
{
    public static class Mappers
    {
        public static CurrencyEF MapToEntity(this Rate rate)
        {
            return new CurrencyEF
            {
                Name = rate.Id.Substring(0, 3),
                LastUpdate = MapTheDate(rate.Date, rate.Time),
                //CurrentValue = rate.RateValue
            };
        }

        private static DateTime MapTheDate(string date, string time)
        {
            var toReturn = DateTime.Parse("date");
            MessageBox.Show("dupa");
            return toReturn;
        }
    }
}

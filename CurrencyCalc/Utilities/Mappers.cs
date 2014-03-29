using System;
using System.Globalization;
using System.Windows;
using CurrencyCalc.Models;
using EF.Entities;

namespace CurrencyCalc.Utilities
{
    public static class Mappers
    {
        public static CurrencyEF MapToEntity(this rate rate)
        {
            return new CurrencyEF
            {
                Name = rate.Id.Substring(0, 3),
                LastUpdate = MapTheDate(rate.Date, rate.Time),
                CurrentValue = rate.Rate.MapTheDouble()
            };
        }

        public static DateTime MapTheDate(string date, string time)
        {
            var toReturnDate = DateTime.ParseExact(date, "M/d/yyyy", new CultureInfo("en-US"));
            var toReturnTime = DateTime.Parse(time);
            toReturnDate = toReturnDate.AddHours(toReturnTime.Hour);
            toReturnDate = toReturnDate.AddMinutes(toReturnTime.Minute);
            return toReturnDate;
        }

        public static double MapTheDouble(this string dbl)
        {
            return Double.Parse(dbl, NumberFormatInfo.InvariantInfo);
        }
    }
}

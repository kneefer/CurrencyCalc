using System;

namespace EF.Entities
{
    public class RateEF
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime Time { get; set; }

        public override string ToString()
        {
            return String.Format("Id: {0}, Value: {1}, Time: {2}", Id, Value, Time);
        }
    }
}

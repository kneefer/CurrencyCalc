using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EF.Entities
{
    public class CurrencyEF
    {
        public CurrencyEF()
        {
            Rates = new ObservableCollection<RateEF>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }
        public double CurrentValue { get; set; }
        public virtual ObservableCollection<RateEF> Rates { get; private set; }

        public override string ToString()
        {
            var str = new StringBuilder();
            Rates.ToList().ForEach(x => str.Append((x)));

            return String.Format("Id: {0}, Name: {1}, LastUpdate: {2}," +
                "CurrentValue: {3}, Rates: {4}",
                Id, Name, LastUpdate, CurrentValue, str);
        }
    }
}

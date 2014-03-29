using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace EF.Entities
{
    public class CurrencyEF : INotifyPropertyChanged
    {
        private DateTime _lastUpdate;
        private double _currentValue;

        public CurrencyEF()
        {
            Rates = new ObservableCollection<RateEF>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set
            {
                if (value != _lastUpdate)
                {
                    _lastUpdate = value;
                    OnPropertyChanged("LastUpdate");
                }
            }
        }

        public double CurrentValue
        {
            get { return _currentValue; }
            set
            {
                if (value != _currentValue)
                {
                    _currentValue = value;
                    OnPropertyChanged("CurrentValue");
                }
            }
        }
        public virtual ObservableCollection<RateEF> Rates { get; private set; }

        public override string ToString()
        {
            var str = new StringBuilder();
            Rates.ToList().ForEach(x => str.Append((x)));

            return String.Format("Id: {0}, Name: {1}, LastUpdate: {2}," +
                "CurrentValue: {3}, Rates: {4}",
                Id, Name, LastUpdate, CurrentValue, str);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

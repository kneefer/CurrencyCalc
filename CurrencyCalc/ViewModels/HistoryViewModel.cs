using System.Collections.ObjectModel;

namespace CurrencyCalc.ViewModels
{
    public class HistoryViewModel
    {
        public ObservableCollection<TestClass> Errors { get; private set; }

        public HistoryViewModel()
        {
            Errors = new ObservableCollection<TestClass>
            {
                new TestClass() {Category = "Globalization", Number = 75},
                new TestClass() {Category = "Features", Number = 2},
                new TestClass() {Category = "ContentTypes", Number = 12},
                new TestClass() {Category = "Correctness", Number = 83},
                new TestClass() {Category = "Best Practices", Number = 29}
            };
        }

        private object _selectedItem = null;
        public object SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                // selected item has changed
                _selectedItem = value;
            }
        }
    }

    // class which represent a data point in the chart
    public class TestClass
    {
        public string Category { get; set; }

        public int Number { get; set; }
    }
}

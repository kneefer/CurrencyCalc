using System;
using System.Windows.Controls;
using CurrencyCalc.ViewModels;

namespace CurrencyCalc.Pages
{
    public partial class Live
    {
        public Live()
        {
            InitializeComponent();
        }

        private void TextBoxInput_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = (DataContext as LiveViewModel);
            if (vm != null)
            {
                vm.InputChangedCommand.Execute(TextBoxInput.Text);
            }
        }
    }
}

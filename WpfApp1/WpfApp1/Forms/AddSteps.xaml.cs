using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{

    /// <summary>
    /// Logique d'interaction pour AddSteps.xaml
    /// </summary>
    public partial class AddSteps : Window
    {
        AddStepsViewModel vm;
        public AddSteps(AddStepsViewModel vm)
        {
            this.vm = vm;
            this.DataContext = this.vm;
            this.InitializeComponent();
        }
        private void SaveButtonClick(object sender, RoutedEventArgs e)
            => this.vm.SendToBDD();
        private void RemoveButtonClick(object sender, RoutedEventArgs e)
            => this.vm.RemoveLast();
        private void AddButtonClick(object sender, RoutedEventArgs e)
            => this.vm.AddEmpty();
    }
}

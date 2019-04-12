using System.Windows;
using System.Data;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UCTabRecette.xaml
    /// </summary>
    public partial class UCTabRecette : System.Windows.Controls.UserControl
    {
        public UCTabRecette()
        {
            InitializeComponent();
            ObservableCollection<Recipes> colRecipes = new ObservableCollection<Recipes>(DataAccess.getAllRecipes());
            lvMain.ItemsSource = colRecipes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRecipes newRecipes = new AddRecipes();
            newRecipes.Show();
        }

    }
}

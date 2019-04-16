using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UCTabRecette.xaml
    /// </summary>
    public partial class UCTabRecette : System.Windows.Controls.UserControl
    {
        private ObservableCollection<Recipes> listRecipes;
        public UCTabRecette()
        {
            InitializeComponent();
            listRecipes = new ObservableCollection<Recipes>(DataAccess.Dal.getAllRecipes());
            lvMain.ItemsSource = listRecipes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRecipes newRecipes = new AddRecipes(listRecipes);
            newRecipes.Show();
        }

    }
}

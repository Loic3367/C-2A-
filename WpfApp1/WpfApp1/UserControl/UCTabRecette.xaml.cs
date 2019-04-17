using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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

        private void HandleDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Recette sélectionnée sans la liste Ingredients liés et sans la liste d'étapes
            Recipes selRecipe = (Recipes)((ListViewItem)sender).Content;

            DataAccess.Dal.GetListIngre(selRecipe);
            DataAccess.Dal.GetListSteps(selRecipe);
            ShowSelRecipe recipeForm = new ShowSelRecipe(selRecipe);
            recipeForm.Show();
        }
    }
}

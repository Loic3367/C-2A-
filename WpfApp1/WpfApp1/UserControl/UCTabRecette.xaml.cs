using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UCTabRecette.xaml
    /// </summary>
    public partial class UCTabRecette : System.Windows.Controls.UserControl
    {
        private ObservableCollection<RecipeViewModel> listRecipes;
        public UCTabRecette()
        {
            InitializeComponent();
            //listRecipes = new ObservableCollection<RecipeViewModel>(DataAccess.Dal.getAllRecipes());
            listRecipes = new ObservableCollection<RecipeViewModel>(DataAccess.Dal.getAllRecipesAvailable());
            lvMain.ItemsSource = listRecipes;
            //Gérer le filtre
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvMain.ItemsSource);
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(tbFilter.Text))
                return true;
            else
                return ((RecipeViewModel)item).Name.IndexOf(tbFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRecipes newRecipes = new AddRecipes(new RecipeViewModel(listRecipes));
            newRecipes.Show();
        }

        private void HandleDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Recette sélectionnée sans la liste Ingredients liés et sans la liste d'étapes
            RecipeViewModel selRecipe = (RecipeViewModel)((ListViewItem)sender).Content;

            DataAccess.Dal.GetListIngre(selRecipe);
            DataAccess.Dal.GetListSteps(selRecipe);
            ShowSelRecipe recipeForm = new ShowSelRecipe(selRecipe);
            recipeForm.Show();
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {           
             CollectionViewSource.GetDefaultView(lvMain.ItemsSource).Refresh();        
        }
    }
}

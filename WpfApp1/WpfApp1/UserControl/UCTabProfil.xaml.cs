using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UCTabProfil.xaml
    /// </summary>
    public partial class UCTabProfil : UserControl
    {
        private ObservableCollection<RecipeViewModel> listRecipe;
        private Profil p { get; set; }
        public UCTabProfil()
        {
            InitializeComponent();
            //Condition sur le type de profil connecté afin de voir ce que on affiche ou pas
            if(Profil.CurrentProfil.isAdmin == 1)
            {
                lblProfilName.Content = Profil.CurrentProfil.Nom + "(compte administrateur)";
                btnCreatePfl.Visibility = Visibility.Visible;
                listRecipe = new ObservableCollection<RecipeViewModel>(DataAccess.Dal.getAllRecipes());
            }
            else
            {
                lblProfilName.Content = Profil.CurrentProfil.Nom + "(compte utilisateur)";
                btnCreatePfl.Visibility = Visibility.Hidden;
                listRecipe = new ObservableCollection<RecipeViewModel>(DataAccess.Dal.getRecipesbyUser(Profil.CurrentProfil.ID));
            }
            
            lvRecipesUser.ItemsSource = listRecipe;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvRecipesUser.ItemsSource);
            view.Filter = UserFilter;
        }
    
    
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(tbFilter.Text))
                return true;
            else
                return ((RecipeViewModel)item).Name.IndexOf(tbFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void ChangePassword_Click(object sender, System.Windows.RoutedEventArgs e)
            {
                ChangePWDForm changePWD = new ChangePWDForm(Profil.CurrentProfil);
                changePWD.Show();
            }

        private void HandleDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {  
            //Recette sélectionnée sans la liste Ingredients liés et sans la liste d'étapes
            RecipeViewModel selRecipe = (RecipeViewModel)((ListViewItem)sender).Content;

            if(selRecipe.IsActive == 1)
            {
                selRecipe.IsActive = 0;
                DataAccess.Dal.UpdateRecipeAvailability(selRecipe);
                MessageBox.Show("La recette a été désactivée");
            }
            else {
                selRecipe.IsActive = 1;
                DataAccess.Dal.UpdateRecipeAvailability(selRecipe);
                MessageBox.Show("La recette a été ré-activée");
            }
           
        }

        private void CreateProfilAdmin_Click(object sender, RoutedEventArgs e)
        {
            p = new Profil();
            p.isAdmin = 1;
            CreateUserForm createUserForm = new CreateUserForm(p);
            createUserForm.Show();
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvRecipesUser.ItemsSource).Refresh();
        }
    }
}

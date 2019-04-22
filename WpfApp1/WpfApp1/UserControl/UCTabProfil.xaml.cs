using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UCTabProfil.xaml
    /// </summary>
    public partial class UCTabProfil : UserControl
    {
        private ObservableCollection<RecipeViewModel> listRecipe;
        public UCTabProfil()
        {
            InitializeComponent();
            lblProfilName.Content = Profil.CurrentProfil.Nom;
            listRecipe = new ObservableCollection<RecipeViewModel>(DataAccess.Dal.getRecipesbyUser(Profil.CurrentProfil.ID));
            lvRecipesUser.ItemsSource = listRecipe;
        }

        private void ChangePassword_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ChangePWDForm changePWD = new ChangePWDForm(Profil.CurrentProfil);
            changePWD.Show();
        }
    }
}

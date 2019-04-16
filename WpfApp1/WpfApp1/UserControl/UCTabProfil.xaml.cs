using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UCTabProfil.xaml
    /// </summary>
    public partial class UCTabProfil : UserControl
    {
        public UCTabProfil()
        {
            InitializeComponent();
            lblProfilName.Content = Profil.CurrentProfil.Nom;
        }

        private void ChangePassword_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ChangePWDForm changePWD = new ChangePWDForm(Profil.CurrentProfil);
            changePWD.Show();
        }
    }
}

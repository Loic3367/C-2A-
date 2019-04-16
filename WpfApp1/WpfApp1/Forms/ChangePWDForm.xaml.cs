using System;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour ChangePWDForm.xaml
    /// </summary>
    public partial class ChangePWDForm : Window
    {
        private Profil pfl;
        public ChangePWDForm()
        {
            InitializeComponent();
        }
        public ChangePWDForm(Profil p)
        {
            InitializeComponent();
            pfl = p;
        }

        private void ChangePWD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //On check si l'ancien mdp inscrit correspond à celui de la BDD
                Profil prlDB = HandlePassword.GetProfilHash(oldPwd.Password, pfl);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }

            if (newPwd.Password != newPwd2.Password)
            {
                MessageBox.Show("Votre nouveau mot de passe ne correspond pas");
            }

            HandlePassword.UpdateProfil(newPwd2.Password, pfl);
        }
    }
}

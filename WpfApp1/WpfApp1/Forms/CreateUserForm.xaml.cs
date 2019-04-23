using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour CreateUserForm.xaml
    /// </summary>
    public partial class CreateUserForm : Window
    {
        private Profil pfl = new Profil();
        public CreateUserForm()
        {
            InitializeComponent();
            pfl.isAdmin = 0;

        }
        public CreateUserForm(Profil p)
        {
            pfl = p;
            InitializeComponent();
        }
        private void CreateProfil_click(object sender, RoutedEventArgs e)
        {
            if (pwbox.Password != pwbox2.Password)
            {
                MessageBox.Show("Votre mot de passe est différent");
                return;
            }        
            pfl.Nom = tbIdentifiant.Text;
            
            HandlePassword.HashProfil(this.pwbox2.Password, pfl);
            MessageBox.Show("Le profil a bien été crée");
            this.Close();
        }
    }
}

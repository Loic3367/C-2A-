using System;
using System.Security.Cryptography;
using System.Windows;
namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public LoginWindow()
        {
            InitializeComponent();
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Profil pfl = new Profil();
            
            
            if (String.IsNullOrWhiteSpace(Identifiant.Text) == true)
            {
                MessageBox.Show("Veuillez entrer un identifiant");
                return;
            }
            else
            {
                pfl.Nom = this.Identifiant.Text;
            }

            if (String.IsNullOrWhiteSpace(inputPwd.Password) == true)
            {
                MessageBox.Show("Veuillez entrer un mot de passe");
                return;
            }
            try
            {
                Profil pflDB = HandlePassword.GetProfilHash(this.inputPwd.Password, pfl);
                MainPage mainPage = new MainPage(pflDB);
                mainPage.Show();
                Application.Current.MainWindow = mainPage;
                this.Close();
            }  
            catch {
                MessageBox.Show("Votre identifiant/mot de passe n'est pas valide");
            }
                
            
        }

        private void openFormCreateLogin(object sender, RoutedEventArgs e)
        {
            CreateUserForm newUser = new CreateUserForm();
            newUser.Show();
        }

        
    }
}

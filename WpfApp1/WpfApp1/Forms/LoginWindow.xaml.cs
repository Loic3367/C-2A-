using System;
using System.Windows;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Windows.Documents;
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
            Profil pflDB = new Profil();
            pfl.Salt = new byte[6];
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

            byte[] salt = new byte[25000];
            rngCsp.GetBytes(salt);
            pfl.Salt = salt;
            HandlePassword.HashProfil(this.inputPwd.Password, pfl);
            HandlePassword.GetProfilHash(this.inputPwd.Password, pfl);
            /*
            https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rngcryptoserviceprovider?redirectedfrom=MSDN&view=netframework-4.7.2
            pflDB = DataAccess.GetProfil(pfl);
            var pwdInput = this.inputPwd.Password;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(pwdInput);
            byte[] hash;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                mySHA256.TransformBlock(passwordBytes, 0, passwordBytes.Length, null, 0);
                mySHA256.TransformFinalBlock(salt, 0, salt.Length);
                hash = mySHA256.Hash;
            }

            if (hash.SequenceEqual(pflDB.HashPassword))
            {
                MessageBox.Show("Password correspondent");
            }
            */
            //DataAccess.GetProfil(pfl);

            /* Méthode pour ouvrir une nouvelle page et la définir en tant que Main page, puis fermer l'autre
            MainPage newWindow = new MainPage();
            newWindow.Show();
            Application.Current.MainWindow = newWindow;
            this.Close();
            */
            this.Close();
        }

        private void openFormCreateLogin(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello !");
        }

        
    }
}

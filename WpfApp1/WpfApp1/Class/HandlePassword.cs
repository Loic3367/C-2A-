using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace WpfApp1
{
    public class HandlePassword
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public static void HashProfil(string input,Profil pfl)
        {
            byte[] salt = new byte[25000];
            rngCsp.GetBytes(salt);
            pfl.Salt = salt;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                mySHA256.TransformBlock(passwordBytes, 0, passwordBytes.Length, null, 0);
                mySHA256.TransformFinalBlock(pfl.Salt, 0, pfl.Salt.Length);
                hash = mySHA256.Hash;
                pfl.HashPassword = hash;
            }
            DataAccess.InsertProfil(pfl);
        }

        public static void GetProfilHash(string input,Profil pfl)
        {
            byte[] salt = new byte[25000];
            rngCsp.GetBytes(salt);
            pfl.Salt = salt;
            Profil pflDB = DataAccess.GetProfil(pfl);
            var pwdInput = input;
            byte[] passwordBytes = Encoding.UTF8.GetBytes(pwdInput);
            byte[] hash;
            using (SHA256 mySHA256 = SHA256.Create())
            {
                mySHA256.TransformBlock(passwordBytes, 0, passwordBytes.Length, null, 0);
                mySHA256.TransformFinalBlock(pfl.Salt, 0, pfl.Salt.Length);
                hash = mySHA256.Hash;
            }

            if (hash.SequenceEqual(pflDB.HashPassword))
            {
                MessageBox.Show("Password correspondent");
            }
        }

    }
}

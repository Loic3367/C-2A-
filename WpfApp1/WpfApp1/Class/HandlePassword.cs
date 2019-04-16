using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace WpfApp1
{
    public class HandlePassword
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[25000];
            rngCsp.GetBytes(salt);
            return salt;
        }

        public static byte[] CEstCommeCaQuOnFaitUlysssssse(string pwd, byte[] salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(pwd);
            using (SHA256 mySHA256 = SHA256.Create())
            {
                mySHA256.TransformBlock(passwordBytes, 0, passwordBytes.Length, null, 0);
                mySHA256.TransformFinalBlock(salt, 0, salt.Length);
                return mySHA256.Hash;
            }
        }

        public static void HashProfil(string input, Profil pfl)
        {
            pfl.Salt = GenerateSalt();
            pfl.HashPassword = CEstCommeCaQuOnFaitUlysssssse(input, pfl.Salt);
            DataAccess.Dal.InsertProfil(pfl);
        }

        public static Profil GetProfilHash(string input, Profil pfl)
        {
            pfl.Salt = GenerateSalt();
            Profil pflDB = DataAccess.Dal.GetProfil(pfl);
            byte[] hash = CEstCommeCaQuOnFaitUlysssssse(input, pflDB.Salt);

            if (hash.SequenceEqual(pflDB.HashPassword))
            {
                return pflDB;
            }
            else
            {
                throw new Exception("Votre mot de passe ne correspond pas");
            }
        }

        public static void UpdateProfil(string input, Profil pfl)
        {
            pfl.Salt = GenerateSalt();
            pfl.HashPassword = CEstCommeCaQuOnFaitUlysssssse(input, pfl.Salt);
            DataAccess.Dal.UpdateProfil(pfl);
        }
    }
}

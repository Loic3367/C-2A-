using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Profil
    {
        public string Nom { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] Salt { get; set; }
    }
}

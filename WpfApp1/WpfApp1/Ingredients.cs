using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace WpfApp1
{
    [Table(Name = "Ingredients")]
    class Ingredients { 
        
        [Column(Name ="Nom",DbType = "NVarChar(30) NOT NULL")]
        private String _Nom { get; set; }
        //[Column(Name ="DatePeremption",DbType ="INT")]
        //private DateTime _DatePeremption { get; set; }
        
        public enum TypeIngredient { unité,litres, grammes}
        [Column(Name = "UniteMesure")]
        public int UniteMesure { get; set; }
        public String Nom { get => _Nom; set => _Nom = value; }

        //public DateTime DatePeremption { get => _DatePeremption; set => _DatePeremption = value; }

        
    }
}

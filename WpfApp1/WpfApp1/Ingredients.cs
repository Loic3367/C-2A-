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
    public enum TypeIngredient { A_L_Unitée, litres, grammes }
    [Table(Name = "Ingredients")]
    public class Ingredients
    {
        [Column(Name = "Id", IsPrimaryKey = true, DbType = "INT", IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }
        [Column(Name = "Nom", DbType = "VarChar(30)", CanBeNull = false)]
        public String Nom { get; set; }
        [Column(Name = "DatePeremption", DbType = "BIGINT", CanBeNull = false)]
        private long _datePeremption;
        public DateTime DatePeremption
        {
            get => Fonction.SQLTimetoDateTime(this._datePeremption);
            set => this._datePeremption = Fonction.DateTimeToSQLTime(value);
        }
        [Column(Name = "UniteMesure", DbType = "INT", CanBeNull = false)]
        public TypeIngredient UniteMesure { get; set; }
    }
}

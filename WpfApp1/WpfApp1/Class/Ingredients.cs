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
    #region
    public enum MeasureIngredient { A_L_Unitée, litres, grammes }
    struct IngredientMeasure
    {
        public MeasureIngredient IngreType;

        public override string ToString()
        {
            switch (IngreType)
            {
                case MeasureIngredient.A_L_Unitée:
                    return "A l'unité";

                case MeasureIngredient.grammes:
                    return "Grammes";

                case MeasureIngredient.litres:
                    return "Litres";

                default:
                    throw new ArgumentOutOfRangeException(nameof(IngreType));
            }

        }
    }
    #endregion
    [Table(Name = "Ingredients")]
    public class Ingredients
    {
        [Column(Name = "Id", IsPrimaryKey = true, DbType = "INT", IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }
        [Column(Name = "Nom", DbType = "VarChar(30)", CanBeNull = false)]
        public String Name { get; set; }
        [Column(Name = "DatePeremption", DbType = "BIGINT", CanBeNull = false)]
        private long _expirationDate;
        public DateTime ExpirationDate
        {
            get => Function.SQLTimetoDateTime(this._expirationDate);
            set => this._expirationDate = Function.DateTimeToSQLTime(value);
        }
        [Column(Name = "UniteMesure", DbType = "INT", CanBeNull = false)]
        public MeasureIngredient MeasureUnit { get; set; }
        public Ingredients()
        {

        }
        public Ingredients(String myName,DateTime myExpiraDate, MeasureIngredient myUnit)
        {
            this.Name = myName;
            this.ExpirationDate = myExpiraDate;
            this.MeasureUnit = myUnit;
        }
    }
}

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
    public struct IngredientMeasure
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
    public class Ingredient
    {
        [Column(Name = "Id", IsPrimaryKey = true, DbType = "BIGINT", IsDbGenerated = true, CanBeNull = false)]
        public long Id { get; set; }
        [Column(Name = "Nom", DbType = "Text", CanBeNull = false)]
        public String Name { get; set; }
      
        
        public string ExpirationDate { get; set; }
        public int Quantite { get; set; }
        [Column(Name = "UniteMesure", DbType = "BIGINT", CanBeNull = false)]
        public MeasureIngredient MeasureUnit { get; set; }
        public Ingredient()
        {

        }
        public Ingredient(String myName,string myExpiraDate, MeasureIngredient myUnit)
        {
            this.Name = myName;
            this.ExpirationDate = myExpiraDate;
            this.MeasureUnit = myUnit;
        }

        public override string ToString()
        {
            return Name +" ("+ MeasureUnit+")";
        }
    }
}

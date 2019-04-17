using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;

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
    
    public class Ingredient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public long Id { get; set; }     
        private string name { get; set; }     
        private string expirationDate { get; set; }
        private long quantite { get; set; }     
        public MeasureIngredient measureUnit { get; set; }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (value != name)
                {
                    name = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Nom"));
                    }
                }
            }
        }

        public string ExpirationDate
        {
            get
            {
                return expirationDate;
            }

            set
            {
                if (value != expirationDate)
                {
                    expirationDate = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Date d'expiration"));
                    }
                }
            }
        }

        public long Quantite
        {
            get
            {
                return quantite;
            }

            set
            {
                if (value != quantite)
                {
                    quantite = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Quantité"));
                    }
                }
            }
        }

        public MeasureIngredient MeasureUnit
        {
            get
            {
                return measureUnit;
            }

            set
            {
                if (value != measureUnit)
                {
                    measureUnit = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Indice de mesure"));
                    }
                }
            }
        }



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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;

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
    
    public class Ingredient 
    {
        
        public long Id { get; set; }     
        public string Name { get; set; }     
        public string ExpirationDate { get; set; }
        public long Quantite { get; set; }     
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

    public class IngredientViewModel : ViewModelBase
    {
        long id;
        long quantite;
        public long Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.NotifyPropertyChanged();
            }
        }
        public long Quantite
        {
            get { return this.quantite; }
            set
            {
                this.quantite = value;
                this.NotifyPropertyChanged();
            }
        }
        public IngredientViewModel()
        {
            
        }
        
    }
    public class AddIngredientsViewModel : ViewModelBase
    {
        public ObservableCollection<IngredientViewModel> listIngre { get; }
            = new ObservableCollection<IngredientViewModel>();
        Recipes current;
        ObservableCollection<Recipes> allRecipies;
        ObservableCollection<Ingredient> li = new ObservableCollection<Ingredient>(DataAccess.Dal.SelectAllIngredients());
        public AddIngredientsViewModel(Recipes current, ObservableCollection<Recipes> allRecipies)
        {
            this.current = current;
            this.allRecipies = allRecipies;
            //At least one by default.
            this.AddEmpty();
        }
        public void AddEmpty()
        {
            this.listIngre.Add(new IngredientViewModel());
        }
        public void RemoveLast()
        {
            this.listIngre.RemoveAt(this.listIngre.Count - 1);
        }
        
    }
}

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
            return Name;
        }
    }

    public class IngredientViewModel : ViewModelBase
    {
        public ObservableCollection<Ingredient> li { get; } = new ObservableCollection<Ingredient>(DataAccess.Dal.SelectAllIngredients());
        long id;
        long quantite;
        string name;
        string expirationDate;
        MeasureIngredient measureUnit;
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
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.NotifyPropertyChanged();
            }
        }
        public string ExpirationDate
        {
            get { return this.expirationDate; }
            set
            {
                this.expirationDate = value;
                this.NotifyPropertyChanged();
            }
        }
        public MeasureIngredient MeasureUnit
        {
            get { return this.measureUnit; }
            set
            {
                this.measureUnit = value;
                this.NotifyPropertyChanged();
            }
        }
        public IngredientViewModel()
        {
            
        
        }
        
    }
    public class AddIngredientsViewModel : ViewModelBase
    {
        public ObservableCollection<IngredientViewModel> listIngre { get; set; }
            = new ObservableCollection<IngredientViewModel>();
        RecipeViewModel current;
        ObservableCollection<RecipeViewModel> allRecipies;
        
        public ObservableCollection<Ingredient> li { get; } = new ObservableCollection<Ingredient>(DataAccess.Dal.SelectAllIngredients());
        long id;
        long quantite;
        string name;
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
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.NotifyPropertyChanged();
            }
        }
        public AddIngredientsViewModel(RecipeViewModel current, ObservableCollection<RecipeViewModel> allRecipies)
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

        public RecipeViewModel GetListIngre(RecipeViewModel rvm)
        {
            rvm.ListIngredients = this.listIngre;
            foreach(IngredientViewModel i in rvm.ListIngredients)
            {
                DataAccess.Dal.InsertListIngredients(rvm.ID, i);
            }
            return rvm;
        }
        public AddIngredientsViewModel GoToStepsForm()
        {
            return this;
        }
    }
}

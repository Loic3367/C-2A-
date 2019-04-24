using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1
{
    #region
    public enum MeasureIngredient {[Description("A l'Unitée")] Unités, [Description("litres")] litres, [Description("grammes")] grammes }

    public struct IngredientMeasure
    {
        public MeasureIngredient IngreType;

        public override string ToString()
        {
            switch (IngreType)
            {
                case MeasureIngredient.Unités:
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
        public Ingredient(String myName, string myExpiraDate, MeasureIngredient myUnit)
        {
           
            this.Name = myName;
            this.ExpirationDate = myExpiraDate;
            this.MeasureUnit = myUnit;
        }
        public Ingredient(long id,String myName,string myExpiraDate, MeasureIngredient myUnit)
        {
            this.Id = id;
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
        public ObservableCollection<Ingredient> li { get; } = new ObservableCollection<Ingredient>();//Lors d'un appel de IngredientViewModel, il passera ici
        long id;
        long quantite;
        string name;
        string expirationDate;
        MeasureIngredient measureUnit;
        Ingredient selected;
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
        public Ingredient Selected
        {
            get { return this.selected; }
            set {
                this.selected = value;
                this.NotifyPropertyChanged();
                this.MeasureUnit = value.MeasureUnit;
                this.Quantite = Quantite;
            }
        }
        public MeasureIngredient MeasureUnit
        {
            get { return this.measureUnit;  }
            set
            {
                this.measureUnit = value;
                this.NotifyPropertyChanged();
            }
        }
        public IngredientViewModel()
        {
            li = new ObservableCollection<Ingredient>(DataAccess.Dal.SelectAllIngredients());

        }
        public IngredientViewModel(long id, string myName, long qtt)
        {
            this.Id = id;
            this.Name = myName;
            this.Quantite = qtt;
        }
        public IngredientViewModel(long id,String myName, string myExpiraDate, MeasureIngredient myUnit)
        {
     
            this.Id = id;
            this.Name = myName;
            this.ExpirationDate = myExpiraDate;
            this.MeasureUnit = myUnit;
        }

        public IngredientViewModel(String myName, string myExpiraDate, MeasureIngredient myUnit)
        {
            this.Name = myName;
            this.ExpirationDate = myExpiraDate;
            this.MeasureUnit = myUnit;
        }
       

    }

    public class AddIngredientsViewModel : ViewModelBase
    {
        public ObservableCollection<IngredientViewModel> listIngre { get; set; }
            = new ObservableCollection<IngredientViewModel>();
        RecipeViewModel current;
        ObservableCollection<RecipeViewModel> allRecipies;
        
        public ObservableCollection<Ingredient> li { get; } = new ObservableCollection<Ingredient>(DataAccess.Dal.SelectAllIngredients());
   
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
            
            return rvm;
        }
        public AddIngredientsViewModel GoToStepsForm()
        {
            return this;
        }
    }
}

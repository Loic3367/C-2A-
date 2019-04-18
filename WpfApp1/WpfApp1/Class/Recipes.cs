using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    public enum Difficultee { Très_facile, Facile, Moyen, Difficile, Très_difficile }
    public enum Cout {Bon_Marché, Coût_Moyen, Chère }
    public enum Categorie { [Description("Italien")]Italien,Français,Américain,Asiatique, Méditeranéen }//Epicé Vegan Végétarien
    //Structures pour gérer les strings des enums
    #region
    public struct Cost
    {
        public Cout valeur;

        public override string ToString()
        {
            switch (valeur)
            {
                case Cout.Bon_Marché:
                    return "Bon Marché";
                    
                case Cout.Coût_Moyen:
                    return "Coût Moyen";
                    
                case Cout.Chère:
                    return "Recette Chère";
                    
                default:
                    throw new ArgumentOutOfRangeException(nameof(valeur));
                    
            }

        }
    }
    public struct Difficulty
    {
        public Difficultee value;
        public override string ToString()
        {
            switch (value)
            {
                case Difficultee.Très_facile:
                    return "Très facile";
                case Difficultee.Facile:
                    return "Facile";
                case Difficultee.Moyen:
                    return "Moyen";
                case Difficultee.Difficile:
                    return "Difficile";
                case Difficultee.Très_difficile:
                    return "Très difficile";
                default:
                    throw new ArgumentOutOfRangeException(nameof(value));

            }
        }
    }

    public struct Category
    {
        public Categorie value;
        public override string ToString()
        {
            switch(value)
            {
                case Categorie.Américain:
                    return "Nourriture américaine";
                case Categorie.Asiatique:
                    return "Nourriture asiatique";
                case Categorie.Français:
                    return "Nourriture française";
                case Categorie.Italien:
                    return "Nourriture italienne";
                case Categorie.Méditeranéen:
                    return "Nourriture méditerranéenne";
                default:
                    throw new ArgumentOutOfRangeException(nameof(value));

            }
        }
    }
    #endregion
     public class Recipes
    {
        
        public long ID { get; set; }
        public string Nom { get; set; }
        public List<Ingredient> ListIngredients { get; set; }
        public List<Steps> ListSteps { get; set; }
        public Difficulty Difficulty { get; set; }
        public long PrepTime { get; set; } 
        public long CookTime { get; set; }
        public long NbrPeople { get; set; }  
        public string DateCreation { get; set; }
        public Cost Cost { get; set; }     
        public Category Categorie { get; set; }
        public long CreateurId { get; set; }
        public Recipes() { }
        public Recipes(string name,List<Ingredient> myIngredients, List<Steps> mySteps, Difficulty myDiff, long myTimePrep, long myTimeCook, long myPeopleNbr, Cost myCosts,Category myCategories)
        {
            this.Nom = name;
            this.ListIngredients = myIngredients;
            this.ListSteps = mySteps;
            this.Difficulty = myDiff;
            this.PrepTime = myTimePrep;
            this.CookTime = myTimeCook;
            this.NbrPeople = myPeopleNbr;
            this.Cost = myCosts;
            this.Categorie = myCategories;
        }
        
    }

    public class RecipeViewModel : ViewModelBase
    {
        #region
        static ObservableCollection<Cost> GetCosts()
        {
            ObservableCollection<Cost> ret = new ObservableCollection<Cost>();
            foreach (Cout cost in Enum.GetValues(typeof(Cout)))
                ret.Add(new Cost() { valeur = cost });
            return ret;
        }
        static ObservableCollection<Difficulty> GetDifficulty()
        {
            ObservableCollection<Difficulty> ret = new ObservableCollection<Difficulty>();
            foreach (Difficultee diff in Enum.GetValues(typeof(Difficultee)))
                ret.Add(new Difficulty() { value = diff });
            return ret;
        }

        static ObservableCollection<Category> getCategories()
        {
            ObservableCollection<Category> ret = new ObservableCollection<Category>();
            foreach (Categorie cate in Enum.GetValues(typeof(Categorie)))
                ret.Add(new Category() { value = cate });
            return ret;
        }
        #endregion
        public AddIngredientsViewModel model { get; set; }
        public ObservableCollection<Difficulty> Diff { get; } = GetDifficulty();
        public ObservableCollection<Cost> EnumCost { get; } = GetCosts();
        public ObservableCollection<Category> category { get; } = getCategories();
        public ObservableCollection<RecipeViewModel> allRecipies;

        public long ID { get; set; }
        string name { get; set; }
        ObservableCollection<IngredientViewModel> listIngredients { get; set; }
        List<Steps> listSteps { get; set; }
        Difficulty difficulty { get; set; }
        long prepTime { get; set; }
        long cookTime { get; set; }
        long nbrPeople { get; set; }
        string dateCreation { get; set; }
        Cost cost { get; set; }
        Category categorie { get; set; }
        long creatorId { get; set; }

        byte[] comments { get; set; }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.NotifyPropertyChanged();
            }
        }

        public ObservableCollection<IngredientViewModel> ListIngredients
        {
            get { return this.listIngredients; }
            set
            {
                this.listIngredients = value;
                this.NotifyPropertyChanged();
            }
        }

        public List<Steps> ListSteps
        {
            get { return this.listSteps; }
            set
            {
                this.listSteps = value;
                this.NotifyPropertyChanged();
            }
        }
        public Difficulty Difficulty
        {
            get { return this.difficulty; }
            set
            {
                this.difficulty = value;
                this.NotifyPropertyChanged();
            }
        }
        public long PrepTime
        {
            get { return this.prepTime; }
            set
            {
                this.prepTime = value;
                this.NotifyPropertyChanged();
            }
        }
        public long CookTime
        {
            get { return this.cookTime; }
            set
            {
                this.cookTime = value;
                this.NotifyPropertyChanged();
            }
        }
        public long NbrPeople
        {
            get { return this.nbrPeople; }
            set
            {
                this.nbrPeople = value;
                this.NotifyPropertyChanged();
            }
        }
        public string DateCreation
        {
            get { return this.dateCreation; }
            set
            {
                this.dateCreation = value;
                this.NotifyPropertyChanged();
            }
        }
        public Cost Cost
        {
            get { return this.cost; }
            set
            {
                this.cost = value;
                this.NotifyPropertyChanged();
            }
        }
        public Category Categorie
        {
            get { return this.categorie; }
            set
            {
                this.categorie = value;
                this.NotifyPropertyChanged();
            }
        }
        public long CreatorId
        {
            get { return this.creatorId; }
            set
            {
                this.creatorId = value;
                this.NotifyPropertyChanged();
            }
        }
        public byte[] Comments
        {
            get { return this.comments; }
            set
            {
                this.comments = value;
                this.NotifyPropertyChanged();
            }
        }
        public RecipeViewModel()
        {

        }
 

        public RecipeViewModel(ObservableCollection<RecipeViewModel> allRecipies)
        {
            this.allRecipies = allRecipies;
        }

        public RecipeViewModel ShowListIngreForm()
        {
            return this;
        }
        
    }
}

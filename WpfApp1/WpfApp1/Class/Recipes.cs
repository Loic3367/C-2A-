using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    public enum Difficultee { Très_facile, Facile, Moyen, Difficile, Très_difficile }
    enum Cout {Bon_Marché, Coût_Moyen, Chère }
    enum Categorie { Italien,Français,Américain,Epicé,Asiatique, Végétarien,Vegan,Méditeranéen}
    //Structures pour gérer les strings des enums
    #region
    struct Cost
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
    struct Difficulty
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
    #endregion
     public class Recipes
    {
        public List<Ingredients> ListIngredients { get; set; }
        public List<Steps> ListSteps { get; set; }
        public int Difficulty { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public int NbrPeople { get; set; }
        public int Cost { get; set; }
        public string Categorie { get; set; }

        public Recipes() { }
        public Recipes(List<Ingredients> myIngredients, List<Steps> mySteps,int Diff, int TimePrep, int TimeCook, int PeopleNbr, int Costs)
        {
            this.ListIngredients = myIngredients;
            this.ListSteps = mySteps;
            this.Difficulty = Diff;
            this.PrepTime = TimePrep;
            this.CookTime = TimeCook;
            this.NbrPeople = PeopleNbr;
            this.Cost = Costs;
        }
    }



}

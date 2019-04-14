﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.ComponentModel;

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



}

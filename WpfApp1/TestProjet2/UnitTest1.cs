using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;

namespace TestProjet2
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]     
        public void AddIngreToBDD()
        {
            //Etat initial
            Ingredient ingre = new Ingredient("Bananes", "28/04/2019", MeasureIngredient.Unités);

            //Lorsque
            DataAccess.Dal.InsertIngredient(ingre);
            List<Ingredient> listIngre = DataAccess.Dal.SelectAllIngredients();
            //Alors
            Assert.IsTrue(listIngre.Any(x => x.Name == ingre.Name));
           
        }
        [TestMethod]
        public void AddRecipeToBDD()
        {
            RecipeViewModel rvm = new RecipeViewModel("PouletTest", 15, 20, 5, 2, 1);
            Cost c = new Cost();
            c.valeur = Cout.Chère;         
            rvm.Cost = c;
            Difficulty d = new Difficulty();
            d.value = Difficultee.Moyen;
            rvm.Difficulty = d;
            Steps s = new Steps();
            s.Number = 1;
            s.Description = "Première étape";
            Steps s2 = new Steps();
            s2.Number = 2;
            s2.Description = "Deuxième étape";
            List<Steps> ls = new List<Steps>();
            ls.Add(s);
            ls.Add(s2);
            rvm.ListSteps = ls;
            
            ObservableCollection<IngredientViewModel> li = new ObservableCollection<IngredientViewModel>();
            li.Add(new IngredientViewModel("Poulet", "28/04/2019", MeasureIngredient.Unités));
            li.Add(new IngredientViewModel("Patates douces", "25/05/2019", MeasureIngredient.Unités));
            li.Add(new IngredientViewModel("Betteraves", "02/05/2019", MeasureIngredient.grammes));
            li.Add(new IngredientViewModel("Pesto", "22/07/2019", MeasureIngredient.grammes));
            rvm.ListIngredients = li;

            DataAccess.Dal.InsertRecipe(rvm);
            ObservableCollection<RecipeViewModel> listrvm = new ObservableCollection<RecipeViewModel>(DataAccess.Dal.getAllRecipes());
           
            Assert.IsTrue(listrvm.Any(x => x.Name == rvm.Name));
        }
        [TestMethod]
        public void AddProfilToBDD()
        {
            Profil pfl = new Profil();
            pfl.Nom = "ProfilTest2";
            string pwdPasChiffre = "test";
            HandlePassword.HashProfil(pwdPasChiffre,pfl);

            Profil pfldb = HandlePassword.GetProfilHash(pwdPasChiffre, pfl);

            //Lorsque GetProfilHash fail, il renvoie déjà une exception
        }
    }
    
}

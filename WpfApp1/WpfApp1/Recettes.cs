using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp1
{
    public enum Difficultee { Très_facile, Facile, Moyen, Difficile, Très_difficile }
    enum Cout {[Description("Bon Marché")]BonMarché, [Description("Coût Moyen")] Coût_Moyen, [Description("Recette chère")] Chère }

    public class Recettes
    {
        public List<Ingredients> ListIngredients { get; set; }

        public List<Etapes> ListEtapes { get; set; }
        public int Difficulte { get; set; }
        public int TempsPreparation { get; set; }
        public int TempsCuisson { get; set; }
        public int NbrPersonnes { get; set; }
        public int Cout { get; set; }

        public Recettes(List<Ingredients> mesIngredients, List<Etapes> mesEtapes,int Difficulte, int TpsPrep, int TpsCuisson, int NbPers, int Cout)
        {
            this.ListIngredients = mesIngredients;
            this.ListEtapes = mesEtapes;
            this.Difficulte = Difficulte;
            this.TempsPreparation = TpsPrep;
            this.TempsCuisson = TpsCuisson;
            this.NbrPersonnes = NbPers;
            this.Cout = Cout;
        }
    }



}

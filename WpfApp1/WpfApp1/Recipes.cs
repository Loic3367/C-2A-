using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Recipes
    {
        List<Ingredients> ListIngredients { get; set; }

        private int Difficulte { get; set; }
        enum Difficultee { Très_facile, facile, moyen, difficile, très_difficile }

        private int TempsPreparation { get; set; }
        private int TempsCuisson { get; set; }
        private int NbrPersonnes { get; set; }
        
        public int _TempsPreparation { get => TempsPreparation; set => TempsPreparation = value; }
        public int _Difficulte { get => Difficulte; set => Difficulte = value; }
        public int _TempsCuisson { get => TempsCuisson; set => TempsCuisson = value; }
        public int _NbrPersonnes { get => NbrPersonnes; set => NbrPersonnes = value; }
        
    }

    

    class Steps
    {
        private int NumEtape;
        private String Description;

        public int _NumEtape { get => NumEtape; set => NumEtape = value; }
        public String _Description { get => Description; set => Description = value; }
    }
}

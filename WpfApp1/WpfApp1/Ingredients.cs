using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WpfApp1
{
    
    class Ingredients
    {
        
        String Nom { get; set; }
        DateTime DatePeremption { get; set; }
        int NbCalories { get; set; }

        enum TypeIngredient { unité,litres, grammes}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Linq;
using System.Diagnostics;


namespace WpfApp1
{
    public class DataAccess
    {
        public static void SelectInBDD()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db");
            conn.Open();
            DataContext db = new DataContext(conn);
            Table<Ingredients> Customers = db.GetTable<Ingredients>();

            IEnumerable<Ingredients> scoreQuery =
                from score in Customers
                //where score.Nom == "Tomates"
                select score;
            foreach (var ing in scoreQuery)
            {
                Debug.Print($"id = {ing.Nom}, Mesure ? = {ing.UniteMesure}, date = {ing.DatePeremption}");
            }
          
        }

        private void insertIngredient()
        {

        }

        private void insertRecipes()
        {

        }
    }
}

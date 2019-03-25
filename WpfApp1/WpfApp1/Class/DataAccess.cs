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
            List<String> ImportedFiles = new List<string>();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                
                conn.Open();
                string stm = "SELECT * FROM Ingredients";
                
                using (SQLiteCommand cmd = new SQLiteCommand(stm, conn))
                {
                    SQLiteDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        Console.WriteLine("Id :" + rdr["Id"]);
                    /*
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Console.WriteLine(rdr.GetInt32(0) + " "
                                + rdr.GetString(1) + " " + rdr.GetInt32(2));
                        }
                    }
                    */
                }
                
                
            }
            

          
        }

        public static string InsertIngredient(Ingredients ingre)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                String query = "INSERT INTO Ingredients (Id,Nom,DatePeremption,UniteMesure) VALUES (@id,@name,@peremptiondate, @measureunit)";

                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", 2);
                    command.Parameters.AddWithValue("@name", ingre.Name);
                    command.Parameters.AddWithValue("@peremptiondate", ingre.ExpirationDate);
                    command.Parameters.AddWithValue("@measureunit", ingre.MeasureUnit);

                    conn.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }

            }
            return "Ingrédients bien ajoutées";
        }

        private void insertRecipe()
        {

        }
    }
}

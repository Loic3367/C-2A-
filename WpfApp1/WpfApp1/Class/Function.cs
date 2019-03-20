using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WpfApp1
{
    class Function
    {
        
        public static long DateTimeToSQLTime(DateTime dt)
        {
            if (dt.Kind == DateTimeKind.Unspecified)
                throw new ArgumentException("Il faut spécifier le type de date", nameof(dt));
            return dt.Ticks;
        }

        public static DateTime SQLTimetoDateTime(long SQLTime)
        {
            return new DateTime(SQLTime, DateTimeKind.Utc);
        }

        public static string InsertIngredient(Ingredients ingre)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                String query = "INSERT INTO Ingredients (Id,Nom,DatePeremption,UniteMesure) VALUES (@id,@name,@peremptiondate, @measureunit)";
                
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", 1);
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
    }
}

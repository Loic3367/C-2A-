using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace WpfApp1
{
    public class DataAccess
    {
        public static DataAccess Dal { get; } = new DataAccess();

        SQLiteConnection conn;
        public DataAccess()
        {
            this.conn = new SQLiteConnection(@"Data Source=DataBase.db");
            this.conn.Open();
        }
        public List<Ingredient> SelectAllIngredients()
        {
            List<Ingredient> ImportedIngredients = new List<Ingredient>();
            string query = "SELECT * FROM Ingredients";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Ingredient ingre = new Ingredient();
                    ingre.Id = (long)rdr["Id"];
                    ingre.Name = (string)rdr["Nom"];

                    ingre.MeasureUnit = (MeasureIngredient)(Int64)rdr["UniteMesure"];//Droite to Gauche (Int --> MeasureIngredient)
                    ingre.ExpirationDate = (string)rdr["DatePeremption"];
                    ImportedIngredients.Add(ingre);
                }
            }
            return ImportedIngredients;
        }

        public string InsertIngredient(Ingredient ingre)
        {
            String query = "INSERT INTO Ingredients (Nom,DatePeremption,UniteMesure) VALUES (@name,@peremptiondate, @measureunit)";
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@name", ingre.Name);
                command.Parameters.AddWithValue("@peremptiondate", ingre.ExpirationDate);
                command.Parameters.AddWithValue("@measureunit", ingre.MeasureUnit);

                int result = command.ExecuteNonQuery();
                // Check Error
                if (result < 0)
                    Console.WriteLine("Error inserting data into Database!");
            }

            return "Ingrédients bien ajoutés";
        }

        public long InsertRecipe(Recipes recette)
        {
            String query = "INSERT INTO Recette (Nom,TempsCuisson,TempsPreparation, NombrePersonne,Cout,Categorie, DateCreation, Difficulte, Createur_ID)" +
                " VALUES (@name,@tempscuisson, @tempspreparation,@nombrepersonne,@cout,@categorie,@datecreation,@difficulte,@createurid);" +
                "SELECT last_insert_rowid()";

            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@name", recette.Nom);
                command.Parameters.AddWithValue("@tempscuisson", recette.CookTime);
                command.Parameters.AddWithValue("@tempspreparation", recette.PrepTime);
                command.Parameters.AddWithValue("@nombrepersonne", recette.NbrPeople);
                command.Parameters.AddWithValue("@cout", recette.Cost);
                command.Parameters.AddWithValue("@categorie", recette.Categorie);
                command.Parameters.AddWithValue("@datecreation", DateTime.Now);
                command.Parameters.AddWithValue("@difficulte", recette.Difficulty);
                command.Parameters.AddWithValue("@createurid", recette.CreateurId);


                return (long)command.ExecuteScalar();
            }
        }

        public void InsertListIngredients(long idRecette, Ingredient ingre)
        {
            string query = "INSERT INTO recette_ingredient (Idrecette, Idingredient,Quantite) VALUES (@idrece, @idingre,@quantite)";
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@idrece", idRecette);
                command.Parameters.AddWithValue("@idingre", ingre.Id);
                command.Parameters.AddWithValue("@quantite", ingre.Quantite);

                int result = command.ExecuteNonQuery();
            }
        }

        public void InsertSteps(long idRecette, Steps step)
        {
            string query = "INSERT INTO Etape (Idetape, Description,Idrecette) VALUES (@idetape, @description,@idrecette)";
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@idetape", step.Number);
                command.Parameters.AddWithValue("@description", step.Description);
                command.Parameters.AddWithValue("@idrecette", idRecette);

                int result = command.ExecuteNonQuery();
            }

        }

        public List<Recipes> getAllRecipes()
        {
            List<Recipes> listrec = new List<Recipes>();

            string query = "SELECT * FROM Recette";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Recipes rec = new Recipes();
                    rec.Nom = (string)rdr["Nom"];
                    rec.CookTime = (long)rdr["TempsCuisson"];
                    rec.PrepTime = (long)rdr["TempsPreparation"];
                    rec.NbrPeople = (long)rdr["NombrePersonne"];
                    rec.Cost = new Cost() { valeur = (Cout)(long)rdr["Cout"] };
                    rec.Categorie = new Category() { value = (Categorie)(long)rdr["Categorie"] };
                    //rec.DateCreation = (string)rdr["DateCreation"];
                    rec.Difficulty = new Difficulty() { value = (Difficultee)(long)rdr["Difficulte"] };
                    rec.CreateurId = (long)rdr["Createur_ID"];
                    listrec.Add(rec);

                }
            }
            return listrec;
        }

        public Profil GetProfil(Profil p)
        {
            Profil pflDB = new Profil();

            string query = "SELECT * FROM Profil WHERE Identifiant = @identifiant";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@identifiant", p.Nom);
                SQLiteDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        pflDB.ID = (long)rdr["Id"];
                        pflDB.Nom = (string)rdr["Identifiant"];
                        pflDB.HashPassword = (byte[])rdr["MotdePasse"];
                        pflDB.Salt = (byte[])rdr["Sel"];
                    }
                }
            }
            return pflDB;
        }

        public void InsertProfil(Profil p)
        {
            string query = "INSERT INTO Profil (Identifiant,Motdepasse,Sel) VALUES (@identifiant, @motdepasse,@sel)";
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {

                command.Parameters.AddWithValue("@identifiant", p.Nom);
                command.Parameters.AddWithValue("@motdepasse", p.HashPassword);
                command.Parameters.AddWithValue("@sel", p.Salt);

                int result = command.ExecuteNonQuery();
            }
        }

        public void UpdateProfil(Profil p)
        {
            string query = "UPDATE Profil SET Motdepasse = @motdepasse, Sel= @sel WHERE Identifiant = @identifiant";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@motdepasse", p.HashPassword);
                cmd.Parameters.AddWithValue("@sel", p.Salt);
                cmd.Parameters.AddWithValue("@identifiant", p.Nom);

                int result = cmd.ExecuteNonQuery();
            }
        }
    }
}

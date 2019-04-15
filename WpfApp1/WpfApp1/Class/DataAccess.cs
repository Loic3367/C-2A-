using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace WpfApp1
{
    public class DataAccess 
    {
        public static List<Ingredient> SelectAllIngredients()
        {          
            List<Ingredient> ImportedIngredients = new List<Ingredient>();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {            
                conn.Open();
                string stm = "SELECT * FROM Ingredients";        
                using (SQLiteCommand cmd = new SQLiteCommand(stm, conn))
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
            }
            return ImportedIngredients;
        }

        public static string InsertIngredient(Ingredient ingre)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                String query = "INSERT INTO Ingredients (Nom,DatePeremption,UniteMesure) VALUES (@name,@peremptiondate, @measureunit)";

                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                { 
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
            return "Ingrédients bien ajoutés";
        }

        public  static long InsertRecipe(Recipes recette)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                String query = "INSERT INTO Recette (Nom,TempsCuisson,TempsPreparation, NombrePersonne,Cout,Categorie, DateCreation, Difficulte)" +
                    " VALUES (@name,@tempscuisson, @tempspreparation,@nombrepersonne,@cout,@categorie,@datecreation,@difficulte);" +
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

                    conn.Open();
                   
                    return (long)command.ExecuteScalar(); 
                }

            }
           
        }

        public  static void InsertListIngredients(long idRecette,Ingredient ingre)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {

                string query = "INSERT INTO recette_ingredient (Idrecette, Idingredient,Quantite) VALUES (@idrece, @idingre,@quantite)";
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idrece", idRecette);
                    command.Parameters.AddWithValue("@idingre", ingre.Id);
                    command.Parameters.AddWithValue("@quantite", ingre.Quantite);
                    conn.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }

        public static void InsertSteps(long idRecette,Steps step)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {

                string query = "INSERT INTO Etape (Idetape, Description,Idrecette) VALUES (@idetape, @description,@idrecette)";
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@idetape", step.Number);
                    command.Parameters.AddWithValue("@description", step.Description);
                    command.Parameters.AddWithValue("@idrecette", idRecette);
                    conn.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }

        public static List<Recipes> getAllRecipes()
        {
            List<Recipes> listrec = new List<Recipes>();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                conn.Open();
                string stm = "SELECT * FROM Recette";
                using (SQLiteCommand cmd = new SQLiteCommand(stm, conn))
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
                        rec.Categorie =  new Category() { value = (Categorie)(long)rdr["Categorie"] };
                        //rec.DateCreation = (string)rdr["DateCreation"];
                        rec.Difficulty =  new Difficulty() { value = (Difficultee)(long)rdr["Difficulte"] };
                        listrec.Add(rec);

                    }
                }
            }
            return listrec;
            
        }

        public static Profil GetProfil(Profil p)
        {
            Profil pflDB = new Profil();
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                conn.Open();
                string stm = "SELECT Identifiant, Motdepasse, Sel FROM Profils WHERE Identifiant = '" + p.Nom+"'";
                using (SQLiteCommand cmd = new SQLiteCommand(stm, conn))
                {
                    SQLiteDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        pflDB.Nom = (string)rdr["Identifiant"];
                        pflDB.HashPassword = (byte[])rdr["MotdePasse"];
                        pflDB.Salt = (byte[])rdr["Sel"];
                    }
                }
            }
            return pflDB;
        }

        public static void InsertProfil(Profil p)
        {
            using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db"))
            {
                string query = "INSERT INTO Profils (Identifiant,Motdepasse,Sel) VALUES (@identifiant, @motdepasse,@sel)";
                using (SQLiteCommand command = new SQLiteCommand(query, conn))
                {
                    
                    command.Parameters.AddWithValue("@identifiant", p.Nom);
                    command.Parameters.AddWithValue("@motdepasse", p.HashPassword);
                    command.Parameters.AddWithValue("@sel", p.Salt);
                    conn.Open();
                    int result = command.ExecuteNonQuery();
                }
            }
        }
    }
}

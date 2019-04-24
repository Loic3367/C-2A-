using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace WpfApp1
{
    public class DataAccess
    {
        public static DataAccess Dal { get; } = new DataAccess();

        SQLiteConnection conn;
        public DataAccess()
        {
            //L'installateur de l'application permettra de set la DataBase dans C:/ProgramData/Guld_Recipies
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string fullpath = Path.Combine(path, "Guld_Recipies", "DataBase.db");
            this.conn = new SQLiteConnection(@"Data Source="+fullpath);
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
                    
                    Ingredient ingre = new Ingredient((long)rdr["Id"], (string)rdr["Nom"],
                        (string)rdr["DatePeremption"], (MeasureIngredient)(Int64)rdr["UniteMesure"]);
                    
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

        public long InsertRecipe(RecipeViewModel recette)
        {
            String query = "INSERT INTO Recette (Nom,TempsCuisson,TempsPreparation, NombrePersonne,Cout,Categorie, DateCreation, Difficulte, Createur_ID,isActive,Image)" +
                " VALUES (@name,@tempscuisson, @tempspreparation,@nombrepersonne,@cout,@categorie,@datecreation,@difficulte,@createurid,@isActive,@image);" +
                "SELECT last_insert_rowid()";

            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@name", recette.Name);
                command.Parameters.AddWithValue("@tempscuisson", recette.CookTime);
                command.Parameters.AddWithValue("@tempspreparation", recette.PrepTime);
                command.Parameters.AddWithValue("@nombrepersonne", recette.NbrPeople);
                command.Parameters.AddWithValue("@cout", recette.Cost);
                command.Parameters.AddWithValue("@categorie", recette.Categorie);
                command.Parameters.AddWithValue("@datecreation", DateTime.Now);
                command.Parameters.AddWithValue("@difficulte", recette.Difficulty);
                command.Parameters.AddWithValue("@createurid", recette.CreatorId);
                command.Parameters.AddWithValue("@isActive", recette.IsActive);
                command.Parameters.AddWithValue("@image", recette.Image);


                return (long)command.ExecuteScalar();
            }
        }

        public void InsertListIngredients(long idRecette, IngredientViewModel ingre)
        {
            string query = "INSERT INTO recette_ingredient (Idrecette, Idingredient,Quantite, Nom_Ingre) VALUES (@idrece, @idingre,@quantite,@nom)";
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {
                command.Parameters.AddWithValue("@idrece", idRecette);
                command.Parameters.AddWithValue("@idingre", ingre.Selected.Id);
                command.Parameters.AddWithValue("@quantite", ingre.Quantite);
                command.Parameters.AddWithValue("@nom", ingre.Selected.Name);

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

        public List<RecipeViewModel> getAllRecipes()
        {
            List<RecipeViewModel> listrec = new List<RecipeViewModel>();

            string query = "SELECT * FROM Recette";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RecipeViewModel rec = new RecipeViewModel();
                    rec.ID = (long)rdr["Id"];
                    rec.Name = (string)rdr["Nom"];
                    rec.CookTime = (long)rdr["TempsCuisson"];
                    rec.PrepTime = (long)rdr["TempsPreparation"];
                    rec.NbrPeople = (long)rdr["NombrePersonne"];
                    rec.Cost = new Cost() { valeur = (Cout)(long)rdr["Cout"] };
                    rec.Categorie = new Category() { value = (Categorie)(long)rdr["Categorie"] };
                    rec.DateCreation = (string)rdr["DateCreation"];
                    rec.Difficulty = new Difficulty() { value = (Difficultee)(long)rdr["Difficulte"] };
                    rec.CreatorId = (long)rdr["Createur_ID"];
                    rec.IsActive = (long)rdr["isActive"];
                    if (rdr["Image"] != System.DBNull.Value)
                    {
                        rec.Image = (byte[])rdr["Image"];
                    }
                    
                    listrec.Add(rec);

                }
            }
            return listrec;
        }
        public List<RecipeViewModel> getAllRecipesAvailable()
        {
            List<RecipeViewModel> listrec = new List<RecipeViewModel>();

            string query = "SELECT * FROM Recette";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RecipeViewModel rec = new RecipeViewModel();
                    rec.ID = (long)rdr["Id"];
                    rec.Name = (string)rdr["Nom"];
                    rec.CookTime = (long)rdr["TempsCuisson"];
                    rec.PrepTime = (long)rdr["TempsPreparation"];
                    rec.NbrPeople = (long)rdr["NombrePersonne"];
                    rec.Cost = new Cost() { valeur = (Cout)(long)rdr["Cout"] };
                    rec.Categorie = new Category() { value = (Categorie)(long)rdr["Categorie"] };
                    rec.DateCreation = (string)rdr["DateCreation"];
                    rec.Difficulty = new Difficulty() { value = (Difficultee)(long)rdr["Difficulte"] };
                    rec.CreatorId = (long)rdr["Createur_ID"];
                    rec.IsActive = (long)rdr["isActive"];
                    if (rdr["Image"] != System.DBNull.Value)
                    {
                        rec.Image = (byte[])rdr["Image"];
                    }
                    
                    //Condition pour savoir si la recette est active ou pas
                    if (rec.IsActive == 1)
                    {
                        listrec.Add(rec);
                    }
                    
                }
            }
            return listrec;
        }
        public List<RecipeViewModel> getRecipesbyUser(long creatorID)
        {
            List<RecipeViewModel> listrec = new List<RecipeViewModel>();

            string query = "SELECT * FROM Recette WHERE Createur_ID = @creatorID";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@creatorID", creatorID);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RecipeViewModel rec = new RecipeViewModel();
                    rec.ID = (long)rdr["Id"];
                    rec.Name = (string)rdr["Nom"];
                    rec.CookTime = (long)rdr["TempsCuisson"];
                    rec.PrepTime = (long)rdr["TempsPreparation"];
                    rec.NbrPeople = (long)rdr["NombrePersonne"];
                    rec.Cost = new Cost() { valeur = (Cout)(long)rdr["Cout"] };
                    rec.Categorie = new Category() { value = (Categorie)(long)rdr["Categorie"] };
                    rec.DateCreation = (string)rdr["DateCreation"];
                    rec.Difficulty = new Difficulty() { value = (Difficultee)(long)rdr["Difficulte"] };
                    rec.CreatorId = (long)rdr["Createur_ID"];
                    rec.Image = (byte[])rdr["Image"];
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
                        pflDB.isAdmin = (long)rdr["isAdmin"];
                    }
                }
            }
            return pflDB;
        }

        public void InsertProfil(Profil p)
        {
            string query = "INSERT INTO Profil (Identifiant,Motdepasse,Sel,isAdmin) VALUES (@identifiant, @motdepasse,@sel, @isadmin)";
            using (SQLiteCommand command = new SQLiteCommand(query, conn))
            {

                command.Parameters.AddWithValue("@identifiant", p.Nom);
                command.Parameters.AddWithValue("@motdepasse", p.HashPassword);
                command.Parameters.AddWithValue("@sel", p.Salt);
                command.Parameters.AddWithValue("@isadmin", p.isAdmin);
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

        public void GetListSteps(RecipeViewModel r)
        {
            string query = "SELECT Idetape, Description FROM Etape WHERE Idrecette = @idrecette";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                List<Steps> ls = new List<Steps>();
                cmd.Parameters.AddWithValue("@idrecette", r.ID);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {    
                    Steps s = new Steps();
                    s.Number = (long)rdr["Idetape"];
                    byte[] tb = (byte[])rdr["Description"];
                    s.Description = Encoding.UTF8.GetString(tb, 0, tb.Length);                
                    ls.Add(s);
                }

                r.ListSteps = ls;
            }
        }

        public void GetListIngre(RecipeViewModel r)
        {
            ObservableCollection<IngredientViewModel> li = new ObservableCollection<IngredientViewModel>();
            string query = "SELECT Idingredient, Quantite, Nom_Ingre FROM recette_ingredient WHERE Idrecette = @idrecette";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {               
                cmd.Parameters.AddWithValue("@idrecette", r.ID);
                SQLiteDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    IngredientViewModel i = new IngredientViewModel((long)rdr["Idingredient"], (string)rdr["Nom_Ingre"], (long)rdr["Quantite"]);
                    
                    li.Add(i);                    
                }
            }
            r.ListIngredients = li;
        }
        
        public void UpdateRecipeAvailability(RecipeViewModel r)
        {
            string query = "UPDATE Recette SET isActive = @isactive WHERE Id = @identifiant";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@isactive", r.IsActive); 
                cmd.Parameters.AddWithValue("@identifiant", r.ID);

                int result = cmd.ExecuteNonQuery();
            }
        }

        public RecipeViewModel GetRandomRecipes()
        {
            RecipeViewModel r = new RecipeViewModel();
            string query = "SELECT * FROM Recette ORDER BY RANDOM() LIMIT 1";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if(rdr.Read())
                {
                    r.ID = (long)rdr["Id"]; 
                    r.Name = (string)rdr["Nom"];
                    r.CookTime = (long)rdr["TempsCuisson"];
                    r.PrepTime = (long)rdr["TempsPreparation"];
                    r.NbrPeople = (long)rdr["NombrePersonne"];
                    r.Cost = new Cost() { valeur = (Cout)(long)rdr["Cout"] };
                    r.Categorie = new Category() { value = (Categorie)(long)rdr["Categorie"] };
                    r.DateCreation = (string)rdr["DateCreation"];
                    r.Difficulty = new Difficulty() { value = (Difficultee)(long)rdr["Difficulte"] };
                    r.CreatorId = (long)rdr["Createur_ID"];
                    r.IsActive = (long)rdr["isActive"];
                    if (rdr["Image"] != System.DBNull.Value)
                    {
                        r.Image = (byte[])rdr["Image"];
                    }
                    
                }
            }
                return r;
        }

        public RecipeViewModel GetLastRecipe()
        {
            RecipeViewModel r = new RecipeViewModel();
            string query = "SELECT * FROM Recette ORDER BY DateCreation DESC LIMIT 1;";
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                SQLiteDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    r.ID = (long)rdr["Id"];
                    r.Name = (string)rdr["Nom"];
                    r.CookTime = (long)rdr["TempsCuisson"];
                    r.PrepTime = (long)rdr["TempsPreparation"];
                    r.NbrPeople = (long)rdr["NombrePersonne"];
                    r.Cost = new Cost() { valeur = (Cout)(long)rdr["Cout"] };
                    r.Categorie = new Category() { value = (Categorie)(long)rdr["Categorie"] };
                    r.DateCreation = (string)rdr["DateCreation"];
                    r.Difficulty = new Difficulty() { value = (Difficultee)(long)rdr["Difficulte"] };
                    r.CreatorId = (long)rdr["Createur_ID"];
                    r.IsActive = (long)rdr["isActive"];
                    if (rdr["Image"] != System.DBNull.Value)
                    {
                        r.Image = (byte[])rdr["Image"];
                    }
                }
            }
            return r;
        }
    }

}

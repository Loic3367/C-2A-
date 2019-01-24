using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Xml.Linq;
using System.Data.Linq;
using System.Diagnostics;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
            LoginWindow myLogWindow = new LoginWindow();
            myLogWindow.Show();
            //Grid grid = new Grid();
            //Grid.SetColumn()
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=DataBase.db");
            conn.Open();
            DataContext db = new DataContext(conn);

            //var test = db.GetTable<Ingredients>();

            // Get a typed table to run queries.
            Table<Ingredients> Customers = db.GetTable<Ingredients>();
            /*
            IEnumerable<Ingredients> scoreQuery =
                from score in Customers
                where score.Nom == "Tomates"
                select score;
            /* Query for customers from London.
            var query =
                from ing in Customers
                where ing.Nom == "Tomates"
                select ing;
            */
            /*
            foreach (var ing in scoreQuery)
            {
                Debug.Print($"id = {ing.Nom}, Mesure ? = {ing.UniteMesure}, date = {ing.DatePeremption}");
            }
            */
            //
            // * CETTE SALOPERIE SORT DU SQL NON STANDART AVEC
            // * DES PUTAINS DE CROCHETS POUR ECHAPER LES NOM AU LIEU DES DOUBLES6QUOTES
            // * ET SCOPE8IDENTITY ALORS QUE LE CONSTRUCTEUR PREND N4IMPRORTEQUELLE
            // * IDBCONNECTION !!!!!!!!!!!!!!!!!!!
            db.Log = Console.Error;
            //Customers.InsertAllOnSubmit(new Ingredients[]
            Ingredients test = new Ingredients() { Nom = "Calvados", DatePeremption = new DateTime(999999999999, DateTimeKind.Local), UniteMesure = TypeIngredient.litres };
            Customers.InsertOnSubmit(test);
            /*
            Customers.InsertOnSubmit(new Ingredients[]
            {
                new Ingredients() { Nom = "Calvados", DatePeremption = new DateTime(999999999999, DateTimeKind.Local), UniteMesure = TypeIngredient.litres },
                new Ingredients() { Nom = "Calvados 2", DatePeremption  = new DateTime(1000000000000, DateTimeKind.Local), UniteMesure = TypeIngredient.litres },
            });
            */
            db.SubmitChanges();
            
            /*
            Ingredients _ingredient = new Ingredients();
            _ingredient.Nom = "Tomates";
            _ingredient.DatePeremption = new DateTime(2019, 1, 22);
            _ingredient.UniteMesure = Ingredients.TypeIngredient.unité.ToString();
            */

        }
    }
}

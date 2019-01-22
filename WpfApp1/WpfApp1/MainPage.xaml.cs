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
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=C:\Users\adai103\Documents\Projet_DotNet\WpfApp1\DataBase.db");
            conn.Open();
            DataContext db = new DataContext(conn);

            //var test = db.GetTable<Ingredients>();

            // Get a typed table to run queries.
            Table<Ingredients> Customers = db.GetTable<Ingredients>();

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
            
            foreach (var ing in scoreQuery)
            {
                Console.WriteLine("id = {0}, City = {1}", ing.Nom, ing.UniteMesure);
            }
                

            /*
            Ingredients _ingredient = new Ingredients();
            _ingredient.Nom = "Tomates";
            _ingredient.DatePeremption = new DateTime(2019, 1, 22);
            _ingredient.UniteMesure = Ingredients.TypeIngredient.unité.ToString();
            */

        }
    }
}

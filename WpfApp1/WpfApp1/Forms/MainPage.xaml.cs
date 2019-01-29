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

            //Le bon constructeur du DateTime est celui-ci dessous.
            Function.DateTimeToSQLTime(new DateTime(2019, 01, 28,00,00,00, DateTimeKind.Local));
            

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
                Debug.Print($"id = {ing.Name}, Mesure ? = {ing.MeasureUnit}, date = {ing.ExpirationDate}");
            }

            

            /*
            //Ingredients test = new Ingredients() { Nom = "Calvados", DatePeremption = new DateTime(999999999999, DateTimeKind.Local), UniteMesure = TypeIngredient.litres };
            //Customers.InsertOnSubmit(test);    
            Customers.InsertAllOnSubmit(new Ingredients[]
            {
                new Ingredients() { Nom = "Calvados", DatePeremption = new DateTime(999999999999, DateTimeKind.Local), UniteMesure = TypeIngredient.litres },
                new Ingredients() { Nom = "Calvados 2", DatePeremption  = new DateTime(1000000000000, DateTimeKind.Local), UniteMesure = TypeIngredient.litres },
            }); 
            db.SubmitChanges();
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddRecipes newPage = new AddRecipes();
            newPage.Show();
        }
    }
}

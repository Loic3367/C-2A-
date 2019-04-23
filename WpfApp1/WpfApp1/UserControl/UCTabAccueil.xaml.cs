using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Configuration;
using System.Windows.Media;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UCTabAccueil.xaml
    /// </summary>
    public partial class UCTabAccueil : System.Windows.Controls.UserControl
    {
        RecipeViewModel dailyRecipe;
        RecipeViewModel lastRecipe;
        public UCTabAccueil()
        {
            InitializeComponent();
            //Charger une recette random
            dailyRecipe = DataAccess.Dal.GetRandomRecipes();
            DataAccess.Dal.GetListIngre(dailyRecipe);
            DataAccess.Dal.GetListSteps(dailyRecipe);
            lblDailyRecipe.Content = dailyRecipe.Name;
            BitmapImage img = HandleImage.byteArrayToImage(dailyRecipe.Image);
            imgDailyRecipe.Source = img;
            lblDiffiRecipe.Content = dailyRecipe.Difficulty;

            //Charger la dernière recette ajoutée en BDD
            lastRecipe = DataAccess.Dal.GetLastRecipe();
            DataAccess.Dal.GetListIngre(lastRecipe);
            DataAccess.Dal.GetListSteps(lastRecipe);
            lblLastRecipe.Content = lastRecipe.Name;
            BitmapImage img2 = HandleImage.byteArrayToImage(lastRecipe.Image);
            imgLastRecipe.Source = img2;
            lblLastRecipeDiff.Content = lastRecipe.Difficulty;

            //Gérer la couleur
            var ColorName = ConfigurationManager.AppSettings["Color"];
            switch(ColorName)
            {
                case "Rouge":
                    mainGrid.Background = new SolidColorBrush(Color.FromRgb(255, 69, 0));
                    break;
                case "Bleu":
                    mainGrid.Background = new SolidColorBrush(Color.FromRgb(30, 144, 255));
                    break;
                case "Vert":
                    mainGrid.Background = new SolidColorBrush(Color.FromRgb(34, 139, 34));
                    break;
                case "Blanc":
                    mainGrid.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    break;
                default:
                    break;
            }
            
        }
  
        private void OpenDailyRecipe_Click(object sender, RoutedEventArgs e)
        {
            ShowSelRecipe showSelRecipe = new ShowSelRecipe(dailyRecipe);
            showSelRecipe.Show();
        }

        private void ChangeCouleur_Click(object sender, RoutedEventArgs e)
        {
            ChangeColorForm changeColorForm = new ChangeColorForm();
            changeColorForm.Show();
        }

        private void OpenLastRecipe_Click(object sender, RoutedEventArgs e)
        {
            ShowSelRecipe showSelRecipe = new ShowSelRecipe(lastRecipe);
            showSelRecipe.Show();
        }
    }
}

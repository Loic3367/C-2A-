using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;



namespace WpfApp1
{
    class DBConn
    {
        // Récupération du chemin vers notre fichier de base de données
        static string dbPath = @"..\Data\MyDatabase.db3";
        //SQLitePlatformWin32 _platform = new SQLitePlatformWin32();
        
        // Instanciation de notre connexion
        SQLiteConnection connection = new SQLiteConnection(dbPath);

    }
}

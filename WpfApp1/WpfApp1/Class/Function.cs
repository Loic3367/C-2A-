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

        
    }
}

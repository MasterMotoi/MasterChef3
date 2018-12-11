using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MasterChef3
{
    class connexion
    {

        public static ConnectionBDD()
        {

            //SQL Connection
            SqlConnection connexion = new SqlConnection();
            connexion.ConnectionString = @"data source=DESKTOP-S8MO9E1;initial catalog=default;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            return;

        }

        internal static void Open()
        {
            throw new NotImplementedException();
        }
    }

}


 
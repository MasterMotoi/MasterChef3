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
        private static SqlConnection connexion;

        public static SqlConnection Connexion { get => connexion; set => connexion = value; }

        public static void ConnectionBDD()
        {

            //SQL Connection
            Connexion = new SqlConnection();
            Connexion.ConnectionString = @"data source=DESKTOP-S8MO9E1;initial catalog=default;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            Connexion.Open();

        }

        public static List<string> nomRecettes
        {
            get
            {
                // Requête SQL
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.Connection = Connexion; // Connexion instanciée auparavant
                selectCommand.CommandText = "SELECT nom_recette FROM recette";
                selectCommand.CommandText = "SELECT prix_recette FROM recette";
                selectCommand.CommandText = "SELECT type_recette FROM recette";
                selectCommand.CommandText = "SELECT typeCuisinier FROM recette";
                selectCommand.CommandText = "SELECT temps_preparation FROM recette";
                selectCommand.CommandText = "SELECT temps_repos FROM recette";
                selectCommand.CommandText = "SELECT temps_cuisson FROM recette";

                SqlDataReader reader; // Permet de lire les données
                reader = selectCommand.ExecuteReader();

            }

            return;
        }

        private static void Close()
        {
            throw new NotImplementedException();
        }

        private static void Open()
        {
            throw new NotImplementedException();
        }
    }
}



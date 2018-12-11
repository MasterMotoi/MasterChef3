using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MasterChef3
{
    internal class connexion
    {
        public static SqlConnection cnn;

        public static void ConnectionBDD()
        {

            //SQL Connection
            cnn = new SqlConnection
            {
                ConnectionString = @"data source=DESKTOP-S8MO9E1;initial catalog=default;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"
            };
            cnn.Open();

        }

        public static List<Recette> nomRecettes()
        {
            // Requête SQL
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = cnn; // Connexion instanciée auparavant
            selectCommand.CommandText = "SELECT nom_recette, prix_recette, type_recette, preparateur_recette FROM recette";

            SqlDataReader reader; // Permet de lire les données
            reader = selectCommand.ExecuteReader();

            List<Recette> result = new List<Recette>();
            while (reader.Read())
            {
                Recette item = new Recette()
                {
                    nom_recette = reader["nom_recette"].ToString(),
                    prix_recette = (Decimal)reader["prix_recette"],
                    type_recette = reader["type_recette"].ToString(),
                    typeCuisinier = reader["preparateur_recette"].ToString(),
            
                };
                result.Add(item);
            }

            return result;
        }


        public static List<Table> NumberTable()
        {
            // Requête SQL
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = cnn; // Connexion instanciée auparavant
            selectCommand.CommandText = "SELECT numero_tablee, capacite_tablee FROM tablee";

            SqlDataReader reader; // Permet de lire les données
            reader = selectCommand.ExecuteReader();

            List<Table> result = new List<Table>();
            while (reader.Read())
            {
                Table item = new Table()
                {
                    numero_tablee = (Decimal)reader["numero_tablee"],
                    capacite_tablee = (Decimal)reader["capacite_tablee"],
                    

                };
                result.Add(item);
            }

            return result;
        }


        public static List<Materiel> Liste_Materiel()
        {
            // Requête SQL
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = cnn; // Connexion instanciée auparavant
            selectCommand.CommandText = "SELECT nom_materiel, nombre_materiel FROM materiel";

            SqlDataReader reader; // Permet de lire les données
            reader = selectCommand.ExecuteReader();

            List<Materiel> result = new List<Materiel>();
            while (reader.Read())
            {
                Materiel item = new Materiel()
                {
                    nom_materiel = reader["nom_materiel"].ToString,
                    nombre_materiel = (Decimal)reader["nombre_materiel"],


                };
                result.Add(item);
            }

            return result;
        }



        public static List<MaterielLavable> Liste_MaterielLavable()
        {
            // Requête SQL
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = cnn; // Connexion instanciée auparavant
            selectCommand.CommandText = "SELECT nom_materiel, nombre_materiel FROM materiel WHERE lavable = 1 ";

            SqlDataReader reader; // Permet de lire les données
            reader = selectCommand.ExecuteReader();

            List<MaterielLavable> result = new List<MaterielLavable>();
            while (reader.Read())
            {
                MaterielLavable item = new MaterielLavable()
                {
                    nom_materiel = reader["nom_materiel"].ToString,
                    nombre_materiel = (Decimal)reader["nombre_materiel"],


                };
                result.Add(item);
            }

            return result;
        }



        public static List<Cuisinier> Nom_Cuisinier()
        {
            // Requête SQL
            SqlCommand selectCommand = new SqlCommand();
            selectCommand.Connection = cnn; // Connexion instanciée auparavant
            selectCommand.CommandText = "SELECT nom_personnel, prenom_personnel FROM personnel WHERE metier_personnel = 'Chef de partie' ";

            SqlDataReader reader; // Permet de lire les données
            reader = selectCommand.ExecuteReader();

            List<Cuisinier> result = new List<Cuisinier>();
            while (reader.Read())
            {
                Cuisinier item = new Cuisinier()
                {
                    nom_personnel = reader["nom_personnel"].ToString,
                    prenom_personnel = reader["prenom_personnel"].ToString,

                };
                result.Add(item[1]+" "+item[0]);
            }

            return result;
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


 
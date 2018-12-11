using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterChef3
{
 
        public class MainController
        {
            public static List<Recette> recettes;
            public static List<Table> tables;
            public static List<Materiel> materiel;
            public static List<MaterielLavable> materielLavable;


        public static void remplirRecettes()
            {
            List<string> nomRecettes = connexion.nomrecettes();
            List<string> typeCuisinier = connexion.typeCuisinier();
            List<string> prixRecette = connexion.prixRecette();
            List<string> typeRecette = connexion.typerecettes();
            List<string> tempsPreparation = connexion.tempspreparations();
            List<string> tempsRepos = connexion.tempsrepos();
            List<string> tempsCuisson = connexion.tempscuissons();

            for (int i = 0; i < nomRecettes.Count; i++)
                {
                    Recette r = new Recette(nomRecettes[i], typeCuisinier[i], prixRecette[i], typeRecette[i], tempsPreparation[i], tempsRepos[i], tempsCuisson[i]);
                    recettes.Add(r);
                }

            }

        public static void remplirMateriel()
            {
            List<string> nomRecettes = connexion.nomrecettes();
        }

        
       
    }

    
}

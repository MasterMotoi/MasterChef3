using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class MainController
    {
        public static List<Recette> recettes;
        public static List<Table> tables;
        public static List<Materiel> materiel;
        public static List<MaterielLavable> materielLavable;
        public static ChefCuisine chefCuisine;
        public static ChefRang chefRang;
        public static List<Cuisinier> cuisiniers;
        public static MaitreHotel maitreHotel;
        public static Plongeur plongeur;
        public static Serveur serveur;
        public static List<GroupeClients> clients;

        public static void remplirRecettes()
        {
            /*je me connecte a la base de donnees et je remplis la liste des recettes*/
        }

        public static void remplirMateriel()
        {
            /*je me connct a la base donnees et je remplis la liste du meteriel*/
        }

        public static int tableTimer (int tableNumber)
        {
            foreach(GroupeClients gc in clients)
            {
                    if(gc.table.numero==tableNumber)
                {
                    return gc.temps;
                }
            }
            return 9;
        }

        public static void adding()
        {

            tables = new List<Table>();
            tables.Add(new Table(2, 1));
            tables.Add(new Table(4, 2));
            clients = new List<GroupeClients>();
            chefRang = new ChefRang(1);
            maitreHotel = new MaitreHotel();
        }

        public static int clientsArrivage(int nbClients)
        {
            GroupeClients gc = new GroupeClients(nbClients);
            clients.Add(gc);
            if (maitreHotel.donnerOrdreInstallerClients(chefRang, gc))
            {
                return nbClients;
            }
            clients.Remove(gc);
            return -nbClients;
        }
    }
}

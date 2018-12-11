using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class MainController
    {
        public static System.Timers.Timer aTimer;
        public static int time;
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
        public static Comptoir comptoir;

        public static void initTime()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true; ;
        }

        public static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            time++;
            serveur.faireQuelqueChose();
        }
        public static void remplirRecettes()
        {
            /*je me connecte a la base de donnees et je remplis la liste des recettes*/
        }

        public static void remplirMateriel()
        {
            /*je me connecte a la base donnees et je remplis la liste du meteriel*/
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
            return -1;
        }

        public static void adding()
        {
            tables = new List<Table>();
            tables.Add(new Table(2, 1));
            tables.Add(new Table(4, 2));
            clients = new List<GroupeClients>();
            chefRang = new ChefRang(1);
            maitreHotel = new MaitreHotel();
            comptoir = new Comptoir();
            recettes = new List<Recette>();
            chefCuisine = new ChefCuisine();

            recettes.Add(new Recette("salade", "entree", "Eric Blousot", 10, 10, 10, 25, 50));
            recettes.Add(new Recette("poulet", "plat", "Jean Ruchord", 10, 10, 10, 25, 50));
            recettes.Add(new Recette("gateau", "dessert", "Eric Blousot", 10, 10, 10, 25, 50));
            recettes.Add(new Recette("soupe", "entree", "Eric Blousot", 10, 10, 10, 25, 50));
            recettes.Add(new Recette("poisson", "plat", "Jean Ruchord", 10, 10, 10, 25, 50));
            recettes.Add(new Recette("mousse", "dessert", "Eric Blousot", 10, 10, 10, 25, 50));
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

        public static string getPositionCr(int number)
        {
            if (number == 0)
            {
                return chefRang.etat;
            }
            return chefRang.position;
        }
    }
}

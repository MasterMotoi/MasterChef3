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
        public static int caisse;

        public static void initTime()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
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
            serveur = new Serveur();
            chefCuisine = new ChefCuisine();
            plongeur = new Plongeur();
            materielLavable = new List<MaterielLavable>();
            cuisiniers = new List<Cuisinier>();

            cuisiniers.Add(new Cuisinier("Eric Blousot"));
            cuisiniers.Add(new Cuisinier("Jean Ruchord"));

            materielLavable.Add(new MaterielLavable("assiette", 150));
            materielLavable.Add(new MaterielLavable("couvert", 600));
            materielLavable.Add(new MaterielLavable("verre", 150));
            materielLavable.Add(new MaterielLavable("casserolle", 10));
            materielLavable.Add(new MaterielLavable("couteau cuisine", 5));
            materielLavable.Add(new MaterielLavable("poelle", 10));
            
            recettes.Add(new Recette("salade", "entree", "Eric Blousot", 1, 5, 1, 25, 50));
            recettes.Add(new Recette("poulet", "plat", "Jean Ruchord", 1, 5, 1, 25, 50));
            recettes.Add(new Recette("gateau", "dessert", "Eric Blousot", 1, 5, 1, 25, 50));
            recettes.Add(new Recette("soupe", "entree", "Eric Blousot", 1, 5, 1, 25, 50));
            recettes.Add(new Recette("poisson", "plat", "Jean Ruchord", 1, 5, 1, 25, 50));
            recettes.Add(new Recette("mousse", "dessert", "Eric Blousot", 1, 5, 1, 25, 50));
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

        public static string getPositionServeur(int number)
        {
            if (number == 0)
            {
                return serveur.etat;
            }
            return serveur.position;
        }

        public static void arreterTimers()
        {
            aTimer.Enabled = false;
            foreach(GroupeClients gc in clients)
            {
                gc.aTimer.Enabled = false;
            }
            plongeur.occupe.WaitOne();
            plongeur.aTimer.Enabled = false;
        }
        public static void reprendreTimers()
        {
            aTimer.Enabled = true;
            foreach (GroupeClients gc in clients)
            {
                if (gc.timeractif == true)
                {
                    gc.aTimer.Enabled = true;
                }
            }
            plongeur.occupe.Release();
            plongeur.aTimer.Enabled = true;
        }

        public static void fastForward()
        {
            aTimer.Interval /= 10;
            foreach (GroupeClients gc in clients)
            {
                gc.aTimer.Interval /= 10;
            }
            cuisiniers[0].aTimer.Interval /= 10;
            cuisiniers[1].aTimer.Interval /= 10;
            plongeur.aTimer.Interval /= 10;
        }

        public static string getCpState (int qui)
        {
            return cuisiniers[qui].etat;
        }

        public static void slowMo()
        {
            aTimer.Interval *= 10;
            foreach (GroupeClients gc in clients)
            {
                if (gc.timeractif == true)
                {
                    gc.aTimer.Interval *= 10;
                }
            }
            cuisiniers[0].aTimer.Interval *= 10;
            cuisiniers[1].aTimer.Interval *= 10;
            plongeur.aTimer.Interval *= 10;
        }

        public static List<string> getTableDetails(int numTable)
        {
            List<string> details = new List<string>();
            foreach (GroupeClients gc in clients)
            {
                if (gc.table.capacite > 0)
                {
                    if (gc.table.numero == numTable)
                    {
                        details.Add(gc.nombre + " clients installés sur une table de " + gc.table.capacite);

                        details.Add(gc.etat);

                        foreach(string s in gc.commande.getRecettes())
                        {
                            details.Add(s);
                        }
                        return details;
                    }
                }
            }
            return  null;
        }

        public static string getCcState()
        {
            return chefCuisine.etat;
        }

        public static int gratterLaYoutubeMoney()
        {
            return caisse;
        }
    }
}

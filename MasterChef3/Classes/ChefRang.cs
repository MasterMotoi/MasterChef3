using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using System.Threading;

namespace Classes
{
    public class ChefRang
    {
        public string etat;
        public Semaphore semEtat;
        public Semaphore semPosition;
        public string position;
        public int carre { set; get; }
        public GroupeClients clients { get; set; }
        public bool commandeTransmise { get; set; }

        /// <summary>
        /// initiate a new Chef de rang with his carre.
        /// </summary>
        public ChefRang(int carre)
        {
            this.semEtat = new Semaphore(1, 1);
            this.semPosition = new Semaphore(1, 1);
            this.carre = carre;
            this.semEtat.WaitOne();
            this.etat = "ne rien faire";
            this.semEtat.Release();
            this.semPosition.WaitOne();
            this.position = "A l'accueil";
            this.semPosition.Release();
            this.clients = new GroupeClients(1);
        }

        /// <summary>
        /// Brings a client group to their table
        /// </summary>
        public void placerClients(GroupeClients clients)
        {

            Console.WriteLine(this.etat);
            this.semEtat.WaitOne();
            this.etat = "placer un client";
            this.semEtat.Release();

            this.semPosition.WaitOne();
            this.position = "a la table " + clients.table.numero;
            this.semPosition.Release();
            clients.table.occupee = true;
            clients.place = true;
            Thread thread = new Thread(() => clients.choisirCommande(this));
            thread.Start();
        }

        /// <summary>
        /// Tell recipes to prepare to the chef de cuisine
        /// </summary>
        public void transmettreRecettesCommande(ChefCuisine cc)
        {
            this.semEtat.WaitOne();
            this.etat = "transmettre la commande";
            this.semEtat.Release();
            this.semPosition.WaitOne();
            this.position = "a la cuisine";
            this.semPosition.Release();
            foreach (Recette r in this.clients.commande.recettes)
            {
                if (cc.prendreEnCompteRecette(r) == true)
                {
                    this.clients.commande.recettesValidees.Add(r);
                }
            }
            if (this.clients.commande.recettesValidees.Count == this.clients.commande.recettes.Count)
            {
                this.clients.commandeTransmise = true;
                cc.dispatcherRecettes(this.clients.commande);
            }
            else
            {
                this.changerCommande();
            }
        }

        /// <summary>
        /// Set a table
        /// </summary>
        public void dresserTable(Table table)
        {
            this.semEtat.WaitOne();
            this.etat = "dresser une table";
            this.semEtat.Release();
            this.semPosition.WaitOne();
            this.position = "a la table " + table.numero;
            this.semPosition.Release();
            table.dressee = true;
        }

        /// <summary>
        /// invite clients to change recipes of their command
        /// </summary>
        public void changerCommande()
        {
            this.semEtat.WaitOne();
            this.etat = "changer une commande";
            this.semEtat.Release();
            this.semPosition.WaitOne();
            this.position = "a la table " + clients.table.numero;
            this.semPosition.Release();
            List<Recette> recettesIndisponibles = new List<Recette>();
            List<Recette> recettesExistantes = MainController.recettes;

            bool commande_changee = clients.changerCommande(recettesExistantes);
            while (commande_changee == true)
            {
                commande_changee = clients.changerCommande(recettesExistantes);
            }
            transmettreRecettesCommande(MainController.chefCuisine);
        }

        /// <summary>
        /// recover the command of the clients and ask them to change it until it is valid.
        /// </summary>
        public void prendreCommande(GroupeClients clients)
        {
            this.clients = clients;
            this.semEtat.WaitOne();
            this.etat = "prendre une commande";
            this.semEtat.Release();
            this.semPosition.WaitOne();
            this.position = "a la table " + clients.table.numero;
            this.semPosition.Release();
            this.clients.commandeTransmise = false;
            List<Recette> recettesExistantes = MainController.recettes;

            int recettes_changees = clients.changerRecettes(recettesExistantes);

            while(recettes_changees>0)
            {
                recettes_changees = clients.changerRecettes(recettesExistantes);
            }


            this.transmettreRecettesCommande(MainController.chefCuisine);
        }

        /// <summary>
        /// return the list of unavailable recipes in a list of recipes
        /// </summary>
        private List<Recette> trouverRecettesIndisponibles(List<Recette> listeRecettes)
        {
            List<Recette> listeRecettesIndisponibles = new List<Recette>();
            foreach (Recette r in listeRecettes)
            {
                if (r.restants == 0)
                {
                    listeRecettesIndisponibles.Add(r);
                }
            }
            return listeRecettesIndisponibles;
        }
    }
}

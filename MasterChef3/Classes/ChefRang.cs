using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Classes
{
    public class ChefRang
    {
        public int carre { set; get; }
        public GroupeClients clients { get; set; }
        public bool commandeTransmise { get; set; }

        /// <summary>
        /// initiate a new Chef de rang with his carre.
        /// </summary>
        public ChefRang(int carre)
        {
            this.carre = carre;
        }

        /// <summary>
        /// Brings a client group to their table
        /// </summary>
        public void placerClients(GroupeClients clients)
        {
            Console.WriteLine(clients.temps);
            clients.table.occupee = true;
            clients.place = true;
            clients.aTimer.Enabled = true;
        }

        /// <summary>
        /// Tell recipes to prepare to the chef de cuisine
        /// </summary>
        public void transmettreRecettesCommande(ChefCuisine cc)
        {
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
            table.dressee = true;
        }

        /// <summary>
        /// invite clients to change recipes of their command
        /// </summary>
        public void changerCommande()
        {
            List<Recette> recettesIndisponibles = new List<Recette>();
            List<Recette> recettesExistantes = MainController.recettes;

            bool commande_changee = clients.changerCommande(recettesExistantes);
            while (commande_changee == true)
            {
                commande_changee = clients.changerCommande(recettesExistantes);
            }
        }

        /// <summary>
        /// recover the command of the clients and ask them to change it until it is valid.
        /// </summary>
        public void prendreCommande(GroupeClients clients)
        {
            this.clients.commandeTransmise = false;
            List<Recette> recettesIndisponibles = new List<Recette>();
            List<Recette> recettesExistantes = MainController.recettes;
            int recettes_changees = clients.changerRecettes(recettesExistantes);

            while(recettes_changees>0)
            {
                recettes_changees = clients.changerRecettes(recettesExistantes);
            }

            this.clients = clients;
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

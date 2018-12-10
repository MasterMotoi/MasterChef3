using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            clients.table.occupee = true;
            clients.place = true;
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
                    this.clients.commande.recettes.Remove(r);
                }
            }
            if (this.clients.commande.recettes.Count == 0)
            {
                this.clients.commandeTransmise = true;
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
            do
            {
                this.clients.changerRecettes(recettesIndisponibles);
                recettesIndisponibles = trouverRecettesIndisponibles(this.clients.commande.recettes);
            }
            while (recettesIndisponibles.length > 0);
        }

        /// <summary>
        /// recover the command of the clients and ask them to change it until it is valid.
        /// </summary>
        public void prendreCommande(GroupeClients clients)
        {
            this.clients.commandeTransmise = false;
            List<Recette> recettesIndisponibles = new List<Recette>();
            do
            {
                clients.changerRecettes(recettesIndisponibles);
                recettesIndisponibles = trouverRecettesIndisponibles(clients.commande.recettes);
            }
            while (recettesIndisponibles.length > 0);
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

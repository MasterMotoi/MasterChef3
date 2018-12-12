using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Commande
    {
        public List<Recette> recettes;
        public GroupeClients clients;
        public List<Recette> recettesValidees;

        /// <summary>
        /// Initiate a new Command
        /// </summary>
        public Commande(GroupeClients clients)
        {
            this.recettes = new List<Recette>();
            this.recettesValidees = new List<Recette>();
            this.clients = clients;
        }
        public List<string> getRecettes()
        {
            List<string> liste = new List<string>();
            foreach(Recette r in recettes)
            {
                liste.Add(r.nom);
            }
            return liste;
        }
    }
}

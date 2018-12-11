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
        public Commande()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class GroupeClients
    {
        public int nombre { get; set; }
        public Table table { get; set; }
        public bool place { set; get; }
        public bool commandeTransmise { get; set; }
        public Commande commande { get; set; }

        /// <summary>
        /// initiate a new client group with the number of persons inside.
        /// </summary>
        public GroupeClients(int nombre)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Changes all recipes in the list of recipes of the client command, excepting unavailable recipes
        /// </summary>
        public void changerRecettes(List<Recette> recettesIndisponibles, List<Recette> recettesExistantes)
        {
            for (int i = 0; i < this.commande.recettes.Count; i++)
            {
                this.commande.recettes[i] = this.genererRecette(recettesIndisponibles, recettesExistantes);
            }
        }

        /// <summary>
        /// create a random command, excluding unavailable recipes
        /// </summary>
        public Commande genererCommande(int nombreRecettes, List<Recette> recettesIndisponibles, List<Recette> recettesExistantes)
        {
            Commande commande = new Commande();
            for (int i = 0; i < nombreRecettes; i++)
            {
                commande.recettes.Add(this.genererRecette(recettesIndisponibles, recettesExistantes));
            }
            return commande;
        }

        /// <summary>
        /// generate a random recipe using a list of recipes, excluding unavailable ones.
        /// </summary>
        public Recette genererRecette(List<Recette> recettesIndisponibles, List<Recette> recettesExistantes)
        {
            List<Recette> recettesDisponibles = new List<Recette>();
            foreach (Recette r in recettesExistantes)
            {
                if (!(recettesIndisponibles.Contains(r)))
                {
                    recettesDisponibles.Add(r);
                }
            }

            Random random = new Random();
            return recettesDisponibles[random.Next(0, recettesDisponibles.Count - 1)];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class ChefCuisine
    {

        private List<Recette> recettesADispatcher { get; set; }

        public ChefCuisine()
        {

        }
        /// <summary>
        /// gives a list of recipes to a list of cookers
        /// </summary>
        public void dispatcherRecettes(Commande commande)
        {
            List<Cuisinier> cuisiniers = Donnees.cuisiniers;
            string typeACuisiner = this.trouverTypeACuisiner(commande.recettes);

            foreach (Recette r in commande.recettes)
            {
                if (r.type == typeACuisiner)
                {
                    foreach (Cuisinier c in cuisiniers)
                    {
                        if (r.typeCuisinier == c.type)
                        {
                            c.recettesAEffectuer.Add(r);
                            break;
                        }
                    }
                }
            }
        }
        public string trouverTypeACuisiner(List<Recette> recettes)
        {
            List<string> typesDisponibles = new List<string>();

            foreach(Recette r in recettes)
            {
                typesDisponibles.Add(r.type);
            }

            if(typesDisponibles.Contains("entree"))
            {
                return "entree";
            }
            if(typesDisponibles.Contains("plat"))
            {
                return "plat";
            }
            return "dessert";
        }

        /// <summary>
        /// 
        /// </summary>
        public void decrementerRecette(Recette recette)
        {
            recette.restants -= 1;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool prendreEnCompteRecette(Recette recette)
        {
            if (recette.restants <= 0)
            {
                return false;
            }
            else
            {
                this.decrementerRecette(recette);
                return true;
            }
        }
    }
}

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
        public dispatcherRecettes(List<Recette> recettes, List<Cuisinier> cuisiniers)
        {
            foreach (Recette r in recettes)
            {
                foreach (Cuisinier c in cuisiniers)
                {
                    if (r.GetType == c.type)
                    {
                        c.recettesAEffectuer.Add(r);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public decrementerRecette(Recette recette, ChefRang chefRang)
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

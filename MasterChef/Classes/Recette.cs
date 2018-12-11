using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Recette
    {
        public int restants { get; set; }
        public string type { get; set; }
        public string typeCuisinier { set; get; }
        public int tempsPreparation { get; set; }
        public int tempsCuisson { get; set; }
        public int tempsRepos { set; get; }
        public int prix { set; get; }
        /// <summary>
        /// initiate a new recipe
        /// </summary>
        public Recette(string type, string typeCuisinier, int tempsPreparation, int tempsCuisson, int tempsRepos, int restants, int prix)
        {
            this.type = type;
            this.typeCuisinier = typeCuisinier;
            this.tempsPreparation = tempsPreparation;
            this.tempsCuisson = tempsCuisson;
            this.tempsRepos = tempsRepos;
            this.restants = restants;
            this.prix = prix;
        }
    }
}

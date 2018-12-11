using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Cuisinier
    {
        public string type { get; set; }
        public List<Recette> recettesAEffectuer;

        public Cuisinier(string type)
        {
            this.type = type;
        }
        public void deposerPlat(Comptoir comptoir, Recette recette)
        {
            comptoir.recettes.Add(recette);
        }
    }
}

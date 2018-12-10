using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Cuisinier
    {
        private string type;
        private List<Recette> recettesAEffectuer;

        public Cuisinier(string type)
        {
            this.type = type;
        }
    }
}

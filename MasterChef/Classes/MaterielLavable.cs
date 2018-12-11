using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class MaterielLavable:Materiel
    {
        public bool propre;

        public MaterielLavable()
        {
            this.propre = true;
        }
        public void utiliser()
        {
            this.propre = false;
        }
        public void laver()
        {
            this.propre = true;
        }
    }
}

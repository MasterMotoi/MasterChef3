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

        public MaterielLavable(string nom, int nombre):base(nom,nombre)
        {
            this.nom = nom;
            this.nombre = nombre;
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

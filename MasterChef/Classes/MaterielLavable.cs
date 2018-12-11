using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class MaterielLavable
    {
        public bool propre;
        public string nom;
        public int nombre;

        public MaterielLavable(string nom, int nombre)
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

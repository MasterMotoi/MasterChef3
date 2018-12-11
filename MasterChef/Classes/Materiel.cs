using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Materiel
    {
        public int nombre;
        public string nom;

        public Materiel(string nom, int nombre)
        {
            this.nom = nom;
            this.nombre = nombre;
        }
    }
}

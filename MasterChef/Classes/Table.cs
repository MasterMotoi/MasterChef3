using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Table
    {
        public bool occupee { get; set; }
        public int numero { get; set; }
        public int capacite { get; set; }
        public bool dressee { get; set; }
        public bool propre { set; get; }

        /// <summary>
        /// Initiate a new table with a capacity and a number
        /// </summary>
        public Table(int capacite, int numero)
        {
            this.dressee = true;
            this.capacite = capacite;
            this.numero = numero;
        }
    }
}

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
        /// <summary>
        /// initiate a new recipe
        /// </summary>
        public Recette()
        {

        }
    }
}

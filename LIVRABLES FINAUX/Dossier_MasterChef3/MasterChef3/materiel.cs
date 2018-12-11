namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    
    public partial class materiel
    {
        public int id_materiel { get; set; }
        public string nom_materiel { get; set; }
        public decimal nombre_materiel { get; set; }
        public string type_materiel { get; set; }
        public short lavable { get; set; }
    }
}

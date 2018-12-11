namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    
    public partial class reservation
    {
        public int id_reservation { get; set; }
        public string nom_reservation { get; set; }
        public System.DateTime horaire_reservation { get; set; }
        public decimal table_reservation { get; set; }
        public int id_table { get; set; }
    }
}

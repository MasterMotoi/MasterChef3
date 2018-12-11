namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.commande")]
    public partial class commande
    {
        [Key]
        public int id_commande { get; set; }

        public int id_table { get; set; }
    }
}

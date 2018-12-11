namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.materiel_lavable")]
    public partial class materiel_lavable
    {
        [Key]
        public int id_materiel_lavable { get; set; }

        public short propre { get; set; }

        public int id_materiel { get; set; }
    }
}

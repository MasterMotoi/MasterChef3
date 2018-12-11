namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.tablee")]
    public partial class tablee
    {
        [Key]
        public int id_tablee { get; set; }

        public decimal carre_tablee { get; set; }

        public decimal rang_tablee { get; set; }

        public decimal numero_tablee { get; set; }

        public decimal capacite_tablee { get; set; }

        public short occupation_tablee { get; set; }
    }
}

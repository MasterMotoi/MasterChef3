namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.materiel")]
    public partial class materiel
    {
        [Key]
        public int id_materiel { get; set; }

        [Required]
        [StringLength(50)]
        public string nom_materiel { get; set; }

        public decimal nombre_materiel { get; set; }

        [Required]
        [StringLength(50)]
        public string type_materiel { get; set; }

        public short lavable { get; set; }
    }
}

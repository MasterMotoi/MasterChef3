namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.boisson")]
    public partial class boisson
    {
        [Key]
        public int id_boisson { get; set; }

        [Required]
        [StringLength(50)]
        public string nom_boisson { get; set; }

        public decimal prix_boisson { get; set; }
    }
}

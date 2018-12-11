namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.ingredient")]
    public partial class ingredient
    {
        [Key]
        public int id_ingredient { get; set; }

        [Required]
        [StringLength(50)]
        public string nom_ingredient { get; set; }

        [Required]
        [StringLength(50)]
        public string stockage_ingredient { get; set; }
    }
}

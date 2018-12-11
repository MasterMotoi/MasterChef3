namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.personnel")]
    public partial class personnel
    {
        [Key]
        public int id_personnel { get; set; }

        [Required]
        [StringLength(50)]
        public string nom_personnel { get; set; }

        [Required]
        [StringLength(50)]
        public string prenom_personnel { get; set; }

        [Required]
        [StringLength(50)]
        public string metier_personnel { get; set; }

        [Required]
        [StringLength(50)]
        public string type_personnel { get; set; }
    }
}

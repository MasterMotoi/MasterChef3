namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.reservation")]
    public partial class reservation
    {
        [Key]
        public int id_reservation { get; set; }

        [Required]
        [StringLength(50)]
        public string nom_reservation { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime horaire_reservation { get; set; }

        public decimal table_reservation { get; set; }

        public int id_table { get; set; }
    }
}

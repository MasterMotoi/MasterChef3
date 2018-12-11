namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.necessiter")]
    public partial class necessiter
    {
        [Key]
        [Column(Order = 0)]
        public int id_recette { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_materiel { get; set; }
    }
}

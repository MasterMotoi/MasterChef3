namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("masterchef3.recette")]
    public partial class recette
    {
        [Key]
        public int id_recette { get; set; }

        [Required]
        [StringLength(50)]
        public string nom_recette { get; set; }

        public decimal prix_recette { get; set; }

        [Required]
        [StringLength(50)]
        public string type_recette { get; set; }

        [Required]
        [StringLength(50)]
        public string preparateur_recette { get; set; }

        public decimal quantite_recette { get; set; }

        [Required]
        [StringLength(50)]
        public string stockage_recette { get; set; }

        public TimeSpan temps_preparation { get; set; }

        public TimeSpan temps_repos { get; set; }

        public TimeSpan temps_cuisson { get; set; }
    }
}

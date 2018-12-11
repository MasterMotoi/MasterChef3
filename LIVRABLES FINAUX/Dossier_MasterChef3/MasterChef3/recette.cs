namespace MasterChef3
{
    using System;
    using System.Collections.Generic;
    
    public partial class recette
    {
        public int id_recette { get; set; }
        public string nom_recette { get; set; }
        public decimal prix_recette { get; set; }
        public string type_recette { get; set; }
        public string preparateur_recette { get; set; }
        public decimal quantite_recette { get; set; }
        public string stockage_recette { get; set; }
        public System.TimeSpan temps_preparation { get; set; }
        public System.TimeSpan temps_repos { get; set; }
        public System.TimeSpan temps_cuisson { get; set; }
    }
}

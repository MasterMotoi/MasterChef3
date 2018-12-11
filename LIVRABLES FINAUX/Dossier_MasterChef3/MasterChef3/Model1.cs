namespace MasterChef3
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=BDD")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<boisson> boisson { get; set; }
        public virtual DbSet<commande> commande { get; set; }
        public virtual DbSet<commander> commander { get; set; }
        public virtual DbSet<composer> composer { get; set; }
        public virtual DbSet<constituer> constituer { get; set; }
        public virtual DbSet<etre> etre { get; set; }
        public virtual DbSet<ingredient> ingredient { get; set; }
        public virtual DbSet<materiel> materiel { get; set; }
        public virtual DbSet<materiel_lavable> materiel_lavable { get; set; }
        public virtual DbSet<mobiliser> mobiliser { get; set; }
        public virtual DbSet<necessiter> necessiter { get; set; }
        public virtual DbSet<personnel> personnel { get; set; }
        public virtual DbSet<preparer> preparer { get; set; }
        public virtual DbSet<recette> recette { get; set; }
        public virtual DbSet<reservation> reservation { get; set; }
        public virtual DbSet<tablee> tablee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<boisson>()
                .Property(e => e.prix_boisson)
                .HasPrecision(10, 0);

            modelBuilder.Entity<materiel>()
                .Property(e => e.nombre_materiel)
                .HasPrecision(10, 0);

            modelBuilder.Entity<recette>()
                .Property(e => e.prix_recette)
                .HasPrecision(10, 0);

            modelBuilder.Entity<recette>()
                .Property(e => e.quantite_recette)
                .HasPrecision(10, 0);

            modelBuilder.Entity<reservation>()
                .Property(e => e.horaire_reservation)
                .HasPrecision(0);

            modelBuilder.Entity<reservation>()
                .Property(e => e.table_reservation)
                .HasPrecision(10, 0);

            modelBuilder.Entity<tablee>()
                .Property(e => e.carre_tablee)
                .HasPrecision(10, 0);

            modelBuilder.Entity<tablee>()
                .Property(e => e.rang_tablee)
                .HasPrecision(10, 0);

            modelBuilder.Entity<tablee>()
                .Property(e => e.numero_tablee)
                .HasPrecision(10, 0);

            modelBuilder.Entity<tablee>()
                .Property(e => e.capacite_tablee)
                .HasPrecision(10, 0);
        }
    }
}

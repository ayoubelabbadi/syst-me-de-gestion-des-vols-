using System.Data.Entity;
using Aeroport.Models;
using aspasp.Models;

namespace Aeroport.Data
{
    public class AeroportDbContext : DbContext
    {
        public AeroportDbContext() : base("Server=(localdb)\\MSSQLLocalDB;Database=aspasp;Integrated Security=True;")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AeroportDbContext>());
        }

        public AeroportDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AeroportDbContext>());
        }

        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Pilote> Pilotes { get; set; }
        public DbSet<Passager> Passagers { get; set; }
        public DbSet<Avion> Avions { get; set; }
        public DbSet<Vol> Vols { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pilote>().ToTable("Pilotes");
            modelBuilder.Entity<Passager>().ToTable("Passagers");
            modelBuilder.Entity<Avion>().ToTable("Avions");
            modelBuilder.Entity<Vol>().ToTable("Vols");

            modelBuilder.Entity<Vol>()
                .HasRequired(v => v.Avion)
                .WithMany()
                .HasForeignKey(v => v.AvionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vol>()
                .HasRequired(v => v.Pilote)
                .WithMany()
                .HasForeignKey(v => v.PiloteId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
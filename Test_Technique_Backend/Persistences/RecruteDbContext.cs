using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Xml.Linq;
using Test_Technique_Backend.Models.Common;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Persistences
{
    public class RecruteDbContext : IdentityDbContext<Admin>
    {
        public RecruteDbContext(DbContextOptions<RecruteDbContext> options)
        : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Cv> Cvs { get; set; }
        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<OffreCandidat> OffreCandidats { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecruteDbContext).Assembly);

           
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }



}

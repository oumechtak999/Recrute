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
          //  Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}")
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecruteDbContext).Assembly);
            modelBuilder.Entity<Offre>().HasData(
    new { Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 1", SousTitre = "SOUS TITRE 1", Description = "Description1Description1",
        Date = new DateTime(2023, 01, 01),
        AnneesExperience = 2,Entreprise = "Entreprise 1",
        Ville = "Ville 1",
        TypeContrat = "Type 1"},
    new
    {
        Id = Guid.Parse("{B0788D2F-8004-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 2",
        SousTitre = "SOUS TITRE 2",
        Description = "Description2 Description2",
        Date = new DateTime(2023, 01, 02),
        AnneesExperience = 2,
        Entreprise = "Entreprise 2",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8005-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 3",
        SousTitre = "SOUS TITRE 3",
        Description = "Description3 Description3",
        Date = new DateTime(2023, 01, 03),
        AnneesExperience = 2,
        Entreprise = "Entreprise 1",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8006-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 4",
        SousTitre = "SOUS TITRE 4",
        Description = "Description4 Description4",
        Date = new DateTime(2023, 01, 04),
        AnneesExperience = 2,
        Entreprise = "Entreprise 1",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8007-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 5",
        SousTitre = "SOUS TITRE 5",
        Description = "Description5 Description5",
        Date = new DateTime(2023, 01, 05),
        AnneesExperience = 2,
        Entreprise = "Entreprise  5",
        Ville = "Ville 5",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8008-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 6",
        SousTitre = "SOUS TITRE 6",
        Description = "Description6 Description6",
        Date = new DateTime(2023, 01, 07),
        AnneesExperience = 2,
        Entreprise = "Entreprise 6",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8009-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 7",
        SousTitre = "SOUS TITRE 7",
        Description = "Description7 Description7 ",
        Date = new DateTime(2023, 01, 08),
        AnneesExperience = 2,
        Entreprise = "Entreprise 7",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8010-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 8",
        SousTitre = "SOUS TITRE 8",
        Description = "Description8 Description8",
        Date = new DateTime(2023, 01, 09),
        AnneesExperience = 2,
        Entreprise = "Entreprise 8",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8011-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 9",
        SousTitre = "SOUS TITRE 9",
        Description = "Description9 Description9",
        Date = new DateTime(2023, 01, 10),
        AnneesExperience = 2,
        Entreprise = "Entreprise 9",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8012-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 10",
        SousTitre = "SOUS TITRE 10",
        Description = "Description10 Description10",
        Date = new DateTime(2023, 01, 11),
        AnneesExperience = 2,
        Entreprise = "Entreprise 1",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8013-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 11",
        SousTitre = "SOUS TITRE 11",
        Description = "Description11 Description11",
        Date = new DateTime(2023, 01, 12),
        AnneesExperience = 2,
        Entreprise = "Entreprise 11",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    },
    new
    {
        Id = Guid.Parse("{B0788D2F-8014-43C1-92A4-EDC76A7C5DDE}"),
        Created = new DateTime(2023, 01, 06),
        IsDeleted = false,
        Titre = "TITRE 12",
        SousTitre = "SOUS TITRE 12",
        Description = "Description12 Description12",
        Date = new DateTime(2023, 02, 02),
        AnneesExperience = 2,
        Entreprise = "Entreprise 2",
        Ville = "Ville 1",
        TypeContrat = "Type 1"
    }



    );

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

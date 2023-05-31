﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Test_Technique_Backend.Persistences;

#nullable disable

namespace Test_Technique_Backend.Migrations
{
    [DbContext(typeof(RecruteDbContext))]
    [Migration("20230531184529_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.Admin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("CIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.Candidat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnnéesExpérience")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DernierEmployeur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NiveauEtude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidats");
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.Cv", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CandidatId")
                        .IsUnique();

                    b.ToTable("Cvs");
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.Offre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnnéesExpérience")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entreprise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SousTitre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeContrat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description1Description1",
                            Entreprise = "Entreprise 1",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 1",
                            Titre = "TITRE 1",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8004-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description2 Description2",
                            Entreprise = "Entreprise 2",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 2",
                            Titre = "TITRE 2",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8005-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description3 Description3",
                            Entreprise = "Entreprise 1",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 3",
                            Titre = "TITRE 3",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8006-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description4 Description4",
                            Entreprise = "Entreprise 1",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 4",
                            Titre = "TITRE 4",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8007-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description5 Description5",
                            Entreprise = "Entreprise  5",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 5",
                            Titre = "TITRE 5",
                            TypeContrat = "Type 1",
                            Ville = "Ville 5"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8008-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description6 Description6",
                            Entreprise = "Entreprise 6",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 6",
                            Titre = "TITRE 6",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8009-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description7 Description7 ",
                            Entreprise = "Entreprise 7",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 7",
                            Titre = "TITRE 7",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8010-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description8 Description8",
                            Entreprise = "Entreprise 8",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 8",
                            Titre = "TITRE 8",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8011-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description9 Description9",
                            Entreprise = "Entreprise 9",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 9",
                            Titre = "TITRE 9",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8012-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description10 Description10",
                            Entreprise = "Entreprise 1",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 10",
                            Titre = "TITRE 10",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8013-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description11 Description11",
                            Entreprise = "Entreprise 11",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 11",
                            Titre = "TITRE 11",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        },
                        new
                        {
                            Id = new Guid("b0788d2f-8014-43c1-92a4-edc76a7c5dde"),
                            AnnéesExpérience = 2,
                            Created = new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description12 Description12",
                            Entreprise = "Entreprise 2",
                            IsDeleted = false,
                            SousTitre = "SOUS TITRE 12",
                            Titre = "TITRE 12",
                            TypeContrat = "Type 1",
                            Ville = "Ville 1"
                        });
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.OffreCandidat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("CandidatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OffreId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CandidatId");

                    b.HasIndex("OffreId");

                    b.ToTable("OffreCandidats");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Test_Technique_Backend.Models.Entities.Admin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Test_Technique_Backend.Models.Entities.Admin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test_Technique_Backend.Models.Entities.Admin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Test_Technique_Backend.Models.Entities.Admin", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.Cv", b =>
                {
                    b.HasOne("Test_Technique_Backend.Models.Entities.Candidat", "Candidat")
                        .WithOne("Cv")
                        .HasForeignKey("Test_Technique_Backend.Models.Entities.Cv", "CandidatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidat");
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.OffreCandidat", b =>
                {
                    b.HasOne("Test_Technique_Backend.Models.Entities.Admin", "Admin")
                        .WithMany("OffreCandidats")
                        .HasForeignKey("AdminId");

                    b.HasOne("Test_Technique_Backend.Models.Entities.Candidat", "Candidat")
                        .WithMany("OffreCandidats")
                        .HasForeignKey("CandidatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Test_Technique_Backend.Models.Entities.Offre", "Offre")
                        .WithMany("OffreCandidats")
                        .HasForeignKey("OffreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");

                    b.Navigation("Candidat");

                    b.Navigation("Offre");
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.Admin", b =>
                {
                    b.Navigation("OffreCandidats");
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.Candidat", b =>
                {
                    b.Navigation("Cv")
                        .IsRequired();

                    b.Navigation("OffreCandidats");
                });

            modelBuilder.Entity("Test_Technique_Backend.Models.Entities.Offre", b =>
                {
                    b.Navigation("OffreCandidats");
                });
#pragma warning restore 612, 618
        }
    }
}
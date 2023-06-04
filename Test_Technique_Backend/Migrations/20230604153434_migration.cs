using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test_Technique_Backend.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NiveauEtude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnneesExperience = table.Column<int>(type: "int", nullable: false),
                    DernierEmployeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SousTitre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnneesExperience = table.Column<int>(type: "int", nullable: false),
                    Entreprise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeContrat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cvs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cvs_Candidats_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Candidats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OffreCandidats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OffreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffreCandidats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OffreCandidats_AspNetUsers_AdminId",
                        column: x => x.AdminId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OffreCandidats_Candidats_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Candidats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OffreCandidats_Offres_OffreId",
                        column: x => x.OffreId,
                        principalTable: "Offres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Offres",
                columns: new[] { "Id", "AnneesExperience", "Created", "CreatedBy", "Date", "Description", "Entreprise", "IsDeleted", "LastModified", "LastModifiedBy", "SousTitre", "Titre", "TypeContrat", "Ville" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description1Description1", "Entreprise 1", false, null, null, "SOUS TITRE 1", "TITRE 1", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8004-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description2 Description2", "Entreprise 2", false, null, null, "SOUS TITRE 2", "TITRE 2", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8005-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description3 Description3", "Entreprise 1", false, null, null, "SOUS TITRE 3", "TITRE 3", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8006-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description4 Description4", "Entreprise 1", false, null, null, "SOUS TITRE 4", "TITRE 4", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8007-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description5 Description5", "Entreprise  5", false, null, null, "SOUS TITRE 5", "TITRE 5", "Type 1", "Ville 5" },
                    { new Guid("b0788d2f-8008-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description6 Description6", "Entreprise 6", false, null, null, "SOUS TITRE 6", "TITRE 6", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8009-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description7 Description7 ", "Entreprise 7", false, null, null, "SOUS TITRE 7", "TITRE 7", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8010-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description8 Description8", "Entreprise 8", false, null, null, "SOUS TITRE 8", "TITRE 8", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8011-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description9 Description9", "Entreprise 9", false, null, null, "SOUS TITRE 9", "TITRE 9", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8012-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description10 Description10", "Entreprise 1", false, null, null, "SOUS TITRE 10", "TITRE 10", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8013-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description11 Description11", "Entreprise 11", false, null, null, "SOUS TITRE 11", "TITRE 11", "Type 1", "Ville 1" },
                    { new Guid("b0788d2f-8014-43c1-92a4-edc76a7c5dde"), 2, new DateTime(2023, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description12 Description12", "Entreprise 2", false, null, null, "SOUS TITRE 12", "TITRE 12", "Type 1", "Ville 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cvs_CandidatId",
                table: "Cvs",
                column: "CandidatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OffreCandidats_AdminId",
                table: "OffreCandidats",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_OffreCandidats_CandidatId",
                table: "OffreCandidats",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_OffreCandidats_OffreId",
                table: "OffreCandidats",
                column: "OffreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cvs");

            migrationBuilder.DropTable(
                name: "OffreCandidats");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Candidats");

            migrationBuilder.DropTable(
                name: "Offres");
        }
    }
}

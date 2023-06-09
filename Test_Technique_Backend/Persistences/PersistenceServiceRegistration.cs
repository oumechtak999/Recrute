﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories;
using Test_Technique_Backend.Persistences.Repositories.AdminRepository;
using Test_Technique_Backend.Persistences.Repositories.CandidatRepository;
using Test_Technique_Backend.Persistences.Repositories.CvRepository;
using Test_Technique_Backend.Persistences.Repositories.OffreCandidatRepository;
using Test_Technique_Backend.Persistences.Repositories.OffreRepository;

namespace Test_Technique_Backend.Persistences
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuration du contexte de base de données et de l'option de SQL Server
            services.AddDbContext<RecruteDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
               b => b.MigrationsAssembly(typeof(RecruteDbContext).Assembly.FullName)));
            // Enregistrement du repository de base avec les interfaces génériques
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            // Configuration du service d'authentification basé sur l'identité
            services.AddIdentity<Admin, IdentityRole>()
          .AddEntityFrameworkStores<RecruteDbContext>().AddDefaultTokenProviders();
            // Enregistrement des repositories spécifiques
            services.AddScoped<IOffreRepository, OffreRepository>();
             services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICandidatRepository, CandidatRepository>();
           services.AddScoped<IOffreCandidatRepository, OffreCandidatRepository>();
            services.AddScoped<ICvRepository, CvRepository>();
           






            return services;
        }
    }
}

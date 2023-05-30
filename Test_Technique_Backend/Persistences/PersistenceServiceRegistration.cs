using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Persistences
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RecruteDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("SqlServer"),
               b => b.MigrationsAssembly(typeof(RecruteDbContext).Assembly.FullName)));
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddIdentity<Admin, IdentityRole>()
          .AddEntityFrameworkStores<RecruteDbContext>().AddDefaultTokenProviders();
            // services.AddScoped<IPersonRepository, PersonRepository>();
            // services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IElementRepository, ElementRepository>();
           // services.AddScoped<IServiceRepository, ServiceRepository>();
            //services.AddScoped<IRoleRepository, RoleRepository>();
            //services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            // services.AddScoped<IZoneRepository, ZoneRepository>();
            //services.AddScoped<IBadgeZoneRepository, BadgeZoneRepository>();






            return services;
        }
    }
}

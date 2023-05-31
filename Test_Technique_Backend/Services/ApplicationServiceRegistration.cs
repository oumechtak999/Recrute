using AutoMapper;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
namespace Test_Technique_Backend.Services
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
          //  services.AddTransient<IDeleteElementRecursive, DeleteElementRecursive>();
           // services.AddTransient<IIncludes, Includes>();
            return services;
        }
    }
}

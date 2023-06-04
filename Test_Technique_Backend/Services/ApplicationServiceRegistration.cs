using AutoMapper;
using MediatR;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
namespace Test_Technique_Backend.Services
{
    // Cette classe statique contient une méthode pour enregistrer les services d'application dans le conteneur d'injection de dépendances.
    public static class ApplicationServiceRegistration
    {
        // Cette méthode étend IServiceCollection pour enregistrer les services d'application.
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Cette méthode enregistre AutoMapper dans le conteneur d'injection de dépendances.
            // Assembly.GetExecutingAssembly() spécifie l'assembly actuellement en cours d'exécution pour scanner les profils de configuration.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // Cette méthode enregistre MediatR dans le conteneur d'injection de dépendances.
            // Assembly.GetExecutingAssembly() spécifie l'assembly actuellement en cours d'exécution pour scanner les handlers de requêtes et de notifications.

            services.AddMediatR(Assembly.GetExecutingAssembly());
         
            return services;
        }
    }
}

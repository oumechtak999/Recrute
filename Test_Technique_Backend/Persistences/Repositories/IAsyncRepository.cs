using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Test_Technique_Backend.Persistences.Repositories
{
    // Cette interface définit les méthodes de base pour interagir avec une entité dans la base de données de manière asynchrone.

    public interface IAsyncRepository<T> where T : class
    {
        // Cette méthode ajoute une entité à la base de données de manière asynchrone et renvoie l'entité ajoutée.
        Task<T> AddAsync(T entity);
        // Cette méthode supprime une entité de la base de données de manière asynchrone en utilisant son identifiant unique et renvoie un booléen pour indiquer si l'opération a réussi.
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        // Cette méthode renvoie une liste de toutes les entités de type T dans la base de données de manière asynchrone.
        // Le paramètre "includes" est facultatif et permet de spécifier les entités associées à inclure dans la requête pour éviter les requêtes supplémentaires.
        Task<IReadOnlyList<T>> ListAllAsync(string[]? includes = null, CancellationToken cancellationToken = default);
        // Cette méthode renvoie une liste d'entités de type T filtrées en fonction de la condition spécifiée dans le prédicat de manière asynchrone.
        Task<IReadOnlyList<T>> GetBy(Expression<Func<T, bool>> predicate, string[]? includes = null,
            CancellationToken cancellationToken = default);
    
    }
}

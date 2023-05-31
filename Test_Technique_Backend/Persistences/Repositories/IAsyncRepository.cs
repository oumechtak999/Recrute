using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Test_Technique_Backend.Persistences.Repositories
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAllAsync(string[]? includes = null, CancellationToken cancellationToken = default);

        Task<T> GetByIdAsync(Guid id, string[]? includes = null, CancellationToken cancellationToken = default);


        Task<T> Create(T entity, CancellationToken cancellationToken = default);


        Task<bool> Delete(Guid id, CancellationToken cancellationToken = default);
        // Task<bool> DeleteRecursive(Guid id, CancellationToken cancellationToken = default);
        Task<bool> Update(T entity, CancellationToken cancellationToken = default);


        Task<IReadOnlyList<T>> GetBy(Expression<Func<T, bool>> predicate, string[]? includes = null,
            CancellationToken cancellationToken = default);
    
        Task<IReadOnlyList<T>> Get(string[]? includes = null,
            CancellationToken cancellationToken = default);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default);
    }
}

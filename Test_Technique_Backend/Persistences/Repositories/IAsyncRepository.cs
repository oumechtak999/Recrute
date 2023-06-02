using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Test_Technique_Backend.Persistences.Repositories
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        Task<IReadOnlyList<T>> ListAllAsync(string[]? includes = null, CancellationToken cancellationToken = default);





        Task<IReadOnlyList<T>> GetBy(Expression<Func<T, bool>> predicate, string[]? includes = null,
            CancellationToken cancellationToken = default);
    
    }
}

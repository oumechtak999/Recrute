using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Test_Technique_Backend.Models.Common;

namespace Test_Technique_Backend.Persistences.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : AuditableEntity
    {
        protected readonly RecruteDbContext _dbContext;
        public BaseRepository(RecruteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
 

       
        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;
        }
        /****************************/
        public async Task<IReadOnlyList<T>> ListAllAsync(string[]? includes = null, CancellationToken cancellationToken = default)
        {


            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).Where(x => !x.IsDeleted);


            return await query
                .Where(x => !x.IsDeleted)
                /*            .Skip((page - 1) * size).Take(size)*/
                .AsNoTracking()
                .ToListAsync(cancellationToken);

        }


       


       



       
        
        public async Task<IReadOnlyList<T>> GetBy(Expression<Func<T, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbContext.Set<T>();


            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).Where(x => !x.IsDeleted);

            return await query.Where(predicate).ToArrayAsync(cancellationToken);
        }
        
      


       
    }

}

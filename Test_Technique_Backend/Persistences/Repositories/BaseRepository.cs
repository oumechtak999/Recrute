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
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();

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


        public async Task<T> GetByIdAsync(Guid id, string[]? includes = null, CancellationToken cancellationToken = default)
        {

            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).Where(x => !x.IsDeleted);

            var res = await query.Where(x => !x.IsDeleted).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id, cancellationToken: cancellationToken);

            return res;
        }


        public async Task<bool> Update(T entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<T> Create(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;

        }


        public async Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                entity.IsDeleted = true;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;
        }

        /*
                public async Task<bool> DeleteRecursive(Guid id, CancellationToken cancellationToken = default)
                {
                    IQueryable<T> query = _dbContext.Set<T>();
                    var entity = await _dbContext.Set<T>().FindAsync(id);
                    if (entity != null)
                    {
                        entity.IsDeleted = true;
                        await _dbContext.SaveChangesAsync(cancellationToken);

                    }
                    var list = query.Where(x => x.IdPere==id);
                    return false;
                }*/
        public async Task<IReadOnlyList<T>> GetBy(Expression<Func<T, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbContext.Set<T>();


            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).Where(x => !x.IsDeleted);

            return await query.Where(predicate).ToArrayAsync(cancellationToken);
        }
        public async Task<IReadOnlyList<T>> Get(string[]? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbContext.Set<T>();


            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).Where(x => x.IsDeleted);

            return await query.ToArrayAsync(cancellationToken);
        }
      


        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default)
        {

            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include).Where(x => !x.IsDeleted);

            var res = await query.Where(predicate).AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);

            return res;
        }
    }

}

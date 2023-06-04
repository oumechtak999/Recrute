using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Persistences.Repositories.AdminRepository
{
    // Cette classe étend la classe générique BaseRepository et implémente l'interface IAdminRepository.

    public class AdminRepository : IAdminRepository
    {
        // Le constructeur de la classe prend un objet RecruteDbContext en argument.
        protected readonly RecruteDbContext _dbContext;
        public AdminRepository(RecruteDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IdentityResult> SeedAsync(UserManager<Admin> userManager, Admin user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }
        
        public virtual async Task<Admin> GetByIdAsync(string id)
        {
            return await _dbContext.Set<Admin>().FindAsync(id);
        }
        
      

  
       


        public async Task<Admin> GetByIdAsync(Guid id, string[]? includes = null, CancellationToken cancellationToken = default)
        {

            IQueryable<Admin> query = _dbContext.Set<Admin>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            var res = await query.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id.ToString(), cancellationToken: cancellationToken);

            return res;
        }


      

        public async Task<Admin> Create(Admin entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<Admin>().AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;

        }




        public async Task<IReadOnlyList<Admin>> GetBy(Expression<Func<Admin, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default)
        {
            IQueryable<Admin> query = _dbContext.Set<Admin>();


            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(predicate).ToArrayAsync(cancellationToken);
        }


        public async Task<Admin> GetFirstOrDefault(Expression<Func<Admin, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Admin>().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<Admin> GetFirstOrDefault(Expression<Func<Admin, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default)
        {

            IQueryable<Admin> query = _dbContext.Set<Admin>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            var res = await query.Where(predicate).AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);

            return res;
        }

        public Task<bool> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

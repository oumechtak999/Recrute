using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Persistences.Repositories.AdminRepository
{
    public interface IAdminRepository
    {
        Task<IdentityResult> SeedAsync(UserManager<Admin> userManager, Admin user, string password);
        Task<Admin> GetByIdAsync(string id);
        Task<Admin> GetByIdAsync(Guid id, string[]? includes = null, CancellationToken cancellationToken = default);
        Task<Admin> Create(Admin entity, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Admin>> GetBy(Expression<Func<Admin, bool>> predicate, string[]? includes = null,
            CancellationToken cancellationToken = default);
        Task<Admin> GetFirstOrDefault(Expression<Func<Admin, bool>> predicate, CancellationToken cancellationToken = default);
        Task<Admin> GetFirstOrDefault(Expression<Func<Admin, bool>> predicate, string[]? includes = null, CancellationToken cancellationToken = default);
    }
}

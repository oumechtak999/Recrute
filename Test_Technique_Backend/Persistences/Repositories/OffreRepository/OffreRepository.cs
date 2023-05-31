using System.Data;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Persistences.Repositories.OffreRepository
{
    public class OffreRepository : BaseRepository<Offre>, IOffreRepository
    {
        public OffreRepository(RecruteDbContext dbContext) : base(dbContext)
        { }

        
    }
}

using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories.OffreRepository;

namespace Test_Technique_Backend.Persistences.Repositories.CvRepository
{
    public class CvRepository : BaseRepository<Cv>, ICvRepository
    {
        public CvRepository(RecruteDbContext dbContext) : base(dbContext)
        { }


    }
}

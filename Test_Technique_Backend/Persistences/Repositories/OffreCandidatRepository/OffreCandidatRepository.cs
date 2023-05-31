using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories.CvRepository;

namespace Test_Technique_Backend.Persistences.Repositories.OffreCandidatRepository
{
    public class OffreCandidatRepository : BaseRepository<OffreCandidat>, IOffreCandidatRepository
    {
        public OffreCandidatRepository(RecruteDbContext dbContext) : base(dbContext)
        { }


    }
}

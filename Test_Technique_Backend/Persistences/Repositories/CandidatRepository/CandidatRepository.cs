using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories.CvRepository;

namespace Test_Technique_Backend.Persistences.Repositories.CandidatRepository
{
    public class CandidatRepository : BaseRepository<Candidat>, ICandidatRepository
    {
        public CandidatRepository(RecruteDbContext dbContext) : base(dbContext)
        { }


    }
}

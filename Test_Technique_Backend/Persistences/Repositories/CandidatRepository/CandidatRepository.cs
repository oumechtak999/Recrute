using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories.CvRepository;

namespace Test_Technique_Backend.Persistences.Repositories.CandidatRepository
{
    // Cette classe étend la classe générique BaseRepository et implémente l'interface ICandidatRepository.
    public class CandidatRepository : BaseRepository<Candidat>, ICandidatRepository
    {
        // Le constructeur de la classe prend un objet RecruteDbContext en argument et l'envoie à la classe de base pour initialiser la connexion à la base de données.
        public CandidatRepository(RecruteDbContext dbContext) : base(dbContext)
        { }


    }
}

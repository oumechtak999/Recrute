using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Persistences.Repositories.OffreRepository;

namespace Test_Technique_Backend.Persistences.Repositories.CvRepository
{
    // Cette classe étend la classe générique BaseRepository et implémente l'interface ICvRepository.
    public class CvRepository : BaseRepository<Cv>, ICvRepository
    {
        // Le constructeur de la classe prend un objet RecruteDbContext en argument et l'envoie à la classe de base pour initialiser la connexion à la base de données.

        public CvRepository(RecruteDbContext dbContext) : base(dbContext)
        { }


    }
}

using System.Data;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Persistences.Repositories.OffreRepository
{
    // Cette classe étend la classe générique BaseRepository et implémente l'interface IOffreRepository.

    public class OffreRepository : BaseRepository<Offre>, IOffreRepository
    {
        // Le constructeur de la classe prend un objet RecruteDbContext en argument et l'envoie à la classe de base pour initialiser la connexion à la base de données.

        public OffreRepository(RecruteDbContext dbContext) : base(dbContext)
        { }

        
    }
}

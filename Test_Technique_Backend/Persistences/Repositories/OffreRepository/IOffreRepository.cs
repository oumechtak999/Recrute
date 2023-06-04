using System.Xml.Linq;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Persistences.Repositories.OffreRepository
{
    //Cette interface est utilisée principalement pour ajouter des fonctions particulières au repository Offre .

    public interface IOffreRepository : IAsyncRepository<Offre>
    {

    }
}

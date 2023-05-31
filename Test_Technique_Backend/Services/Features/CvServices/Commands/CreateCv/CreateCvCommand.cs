using MediatR;
using Test_Technique_Backend.Models.Entities;

namespace Test_Technique_Backend.Services.Features.CvServices.Commands.CreateCv
{
    public class CreateCvCommand : IRequest<Guid>
    {
        public Guid CandidatId { get; set; }
        
        public string Titre { get; set; }
        public string Path { get; set; }
    }
}

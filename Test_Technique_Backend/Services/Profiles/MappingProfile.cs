using AutoMapper;
using System.Data;
using System.Xml.Linq;
using Test_Technique_Backend.Models.Entities;
using Test_Technique_Backend.Services.Features.CandidatServices.Commands.CreateCandidat;
using Test_Technique_Backend.Services.Features.CandidatServices.Queries.GetCandidatsList;
using Test_Technique_Backend.Services.Features.CvServices.Commands.CreateCv;
using Test_Technique_Backend.Services.Features.CvServices.Queries.GetCvDetail;
using Test_Technique_Backend.Services.Features.OffreCandidatServices.Commands.CreateOffreCandidat;
using Test_Technique_Backend.Services.Features.OffreCandidatServices.Queries.GetOffreCandidatsList;
using Test_Technique_Backend.Services.Features.OffreServices.Queries.GetOffresList;

namespace Test_Technique_Backend.Services.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Offre, OffresListVm>().ReverseMap();
            CreateMap<OffreCandidat, OffreCandidatsListVm>().ReverseMap();
            CreateMap<Offre, OffreDto>().ReverseMap();
            CreateMap<Candidat, CandidatDto>().ReverseMap();
            CreateMap<OffreCandidat, CreateOffreCandidatCommand>().ReverseMap();
            CreateMap<Cv, CreateCvCommand>().ReverseMap();
            CreateMap<Cv, CvDetailVm>().ReverseMap();
            CreateMap<Candidat, CandidatsListVm>().ReverseMap();
            CreateMap<Candidat, CreateCandidatCommand>().ReverseMap();
            

        }
    }
}

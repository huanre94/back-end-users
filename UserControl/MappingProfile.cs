using AutoMapper;
using DomainLayer.Models;
using ServiceLayer.DataTransferObjects;

namespace PresentationLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerDto>()
                .ForCtorParam("Status", opt => opt.MapFrom(x => x.IsActive));


            // CreateMap<OwnerDto, Owner>();
            CreateMap<Pet, PetDto>()
                    .ForCtorParam("Status", opt => opt.MapFrom(x => x.IsActive));

            CreateMap<PetCreateDto, Pet>();

            // CreateMap<PetDto, Pet>();
        }
    }
}

using API.Dtos.Address;
using API.Dtos.Collaborator;
using API.Models;
using AutoMapper;

namespace API.config
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CollaboratorDto, Collaborator>().ReverseMap();
            CreateMap<Collaborator, CollaboratorNewDto>().ReverseMap();
            CreateMap<CollaboratorUpdateDto, Collaborator>().ReverseMap();

            CreateMap<AddressNewDto, Address>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
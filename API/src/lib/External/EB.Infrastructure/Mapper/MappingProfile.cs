using AutoMapper;
using EB.Domain.Abstrations;
using EB.Domain.Entities;

namespace EB.Infrastructure.Mapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Client, ClientModel>().ReverseMap();
        CreateMap<ClientRequest, Client>().ReverseMap();
        CreateMap<StoreModel, Store>().ReverseMap();
        CreateMap<StoreModel, Address>().ReverseMap();

        CreateMap<StoreResponse, Store>().ReverseMap();
        CreateMap<StoreResponse, Address>().ReverseMap();

    }
}

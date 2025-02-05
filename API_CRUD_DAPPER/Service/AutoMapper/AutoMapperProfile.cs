using AutoMapper;
using Domain.DTO;
using Domain.Entity;

namespace Service.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Usuario, UsuarioListarDTO>();
    }    
}
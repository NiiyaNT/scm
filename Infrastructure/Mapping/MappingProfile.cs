using AutoMapper;
using Scm.Controllers.Dtos;
using Scm.Domain;

namespace Scm.Infrastructure.Mapping
{
    public class MappingProfile : Profile {
    public MappingProfile() {
             CreateMap<AppUser, RegisterUserResponseDto>();             
             CreateMap<Empleado, EmpleadoDto>();
            CreateMap<EmpleadoDto, Empleado>();
            CreateMap<Vale, ValeDto>();
            CreateMap<ValeDto, Vale>();
        }
    }
}
using AutoMapper;
using FluentValidationExample.Dtos;
using FluentValidationExample.Entities;

namespace FluentValidationExample.MappingProfiles {
  public class DtoToEntityMappingProfile : Profile {
    public DtoToEntityMappingProfile() {
      CreateMap<StuffDto, Stuff>(MemberList.Destination).ReverseMap();
    }
  }
}

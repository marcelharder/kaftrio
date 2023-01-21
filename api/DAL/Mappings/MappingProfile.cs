

using api.DAL.data;
using api.DAL.dtos;
using api.DAL.helpers;
using AutoMapper;

namespace api.DAL.Mappings
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           
            CreateMap<patientData,RegistryForReturnDto>();
            CreateMap<RegistryForUpdateDTO,patientData>().ForMember(dest => dest.Id, opt => opt.Ignore());
           
            CreateMap<User, UserForReturnDto>()
            .ForMember(dest => dest.center_id, opt => opt.MapFrom(src => src.center_id.getHospitalName())); 







        }
    }


}
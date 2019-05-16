using AutoMapper;
using iTechArt.ManagementDemo.Services.DTO;
using iTechArt.ManagementDemo.Web.Models;

namespace iTechArt.ManagementDemo.Web.Configuration
{
    public class ModelsMappingProfile : Profile
    {
        public ModelsMappingProfile()
        {
            CreateMap<CompanyDTO, CompanyModel>();
            CreateMap<CompanyModel, CompanyDTO>();

            CreateMap<EmployeeDTO, EmployeeModel>()
                .ForMember(
                    e => e.Sex,
                    opt => opt.MapFrom(
                        e => (Models.Sex)e.Sex));
            CreateMap<EmployeeModel, EmployeeDTO>()
                .ForMember(
                    e => e.Sex,
                    opt => opt.MapFrom(
                        e => (Services.DTO.Sex)e.Sex));

            CreateMap<AddressDTO, AddressModel>();
            CreateMap<AddressModel, AddressDTO>();

            CreateMap<LocationDTO, LocationModel>();
            CreateMap<LocationModel, LocationDTO>();
        }
    }
}

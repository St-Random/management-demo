using AutoMapper;
using iTechArt.ManagementDemo.Entities;
using iTechArt.ManagementDemo.Services.DTO;

namespace iTechArt.ManagementDemo.Services.Configuration
{
    public class DTOMappingProfile : Profile
    {
        public DTOMappingProfile()
        {
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();

            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();

            CreateMap<Employee, EmployeeDTO>()
                .ForMember(
                    e => e.Sex,
                    opt => opt.MapFrom(
                        e => (DTO.Sex)e.Sex))
                .ForMember(
                    e => e.LocationName,
                    opt => opt.MapFrom(e => e.Location.Name))
                .ForMember(
                    e => e.CompanyId,
                    opt => opt.MapFrom(e => e.Location.CompanyId))
                .ForMember(
                    e => e.CompanyName,
                    opt => opt.MapFrom(e => e.Location.Company.Name));
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(
                    e => e.Sex,
                    opt => opt.MapFrom(
                        e => (Entities.Sex)e.Sex));

            // For cloning
            CreateMap<Location, Location>();
            CreateMap<Location, LocationDTO>()
                .ForMember(
                    l => l.CompanyName,
                    opt => opt.MapFrom(l => l.Company.Name));
            CreateMap<LocationDTO, Location>();
        }
    }
}

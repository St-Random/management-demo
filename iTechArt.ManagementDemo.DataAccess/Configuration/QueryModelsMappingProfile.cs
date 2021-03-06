﻿using AutoMapper;
using iTechArt.ManagementDemo.Entities;
using iTechArt.ManagementDemo.Querying.Models;
using System.Linq;

namespace iTechArt.ManagementDemo.DataAccess.Configuration
{
    public class QueryModelsMappingProfile : Profile
    {
        public QueryModelsMappingProfile()
        {
            CreateMap<Company, CompanyQueryModel>()
                .ForMember(
                    c => c.EmployeesCount,
                    opt => opt.MapFrom(
                        c => c.Locations
                            .SelectMany(l => l.Employees)
                            .Count()));

            CreateMap<Company, NamedQueryModel>();

            CreateMap<Location, CompanyLocationModel>()
                .ForMember(
                    cl => cl.Country,
                    opt => opt.MapFrom(l => l.Address.Country))
                .ForMember(
                    cl => cl.Area,
                    opt => opt.MapFrom(l => l.Address.Area))
                .ForMember(
                    cl => cl.City,
                    opt => opt.MapFrom(l => l.Address.City))
                .ForMember(
                    cl => cl.PostalCode,
                    opt => opt.MapFrom(l => l.Address.PostalCode));

            CreateMap<Location, NamedQueryModel>();

            CreateMap<Employee, LocationEmployeeModel>()
                .ForMember(
                    e => e.Sex,
                    opt => opt.MapFrom(
                        e => (Querying.Models.Sex)e.Sex));

            CreateMap<Employee, CompanyEmployeeModel>()
                .ForMember(
                    e => e.LocationName,
                    opt => opt.MapFrom(e => e.Location.Name))
                .ForMember(
                    e => e.Sex,
                    opt => opt.MapFrom(
                        e => (Querying.Models.Sex)e.Sex));

            CreateMap<Employee, EmployeeQueryModel>()
                .ForMember(
                    e => e.LocationName,
                    opt => opt.MapFrom(e => e.Location.Name))
                .ForMember(
                    e => e.CompanyName,
                    opt => opt.MapFrom(e => e.Location.Company.Name))
                .ForMember(
                    e => e.Sex,
                    opt => opt.MapFrom(
                        e => (Querying.Models.Sex)e.Sex));
        }
    }
}

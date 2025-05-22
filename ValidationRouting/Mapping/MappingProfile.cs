﻿using AutoMapper;
using Data.Entities;
using ValidationRouting.DTOs;

namespace ValidationRouting.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>()
                .ForMember(
                    c => c.FullAddress,
                    opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country))
                );
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>().ReverseMap();
            CreateMap<EmployeeForUpdateDto, Employee>();
        }
    }
}

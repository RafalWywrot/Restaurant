using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO = Restaurant.Domain.DTO;
using Entities = Restaurant.Database.Entities;
using ViewModels = Restaurant.WebApplication.Models;

namespace Restaurant.WebApplication.Helpers.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Test, DTO.TestDto>();
            CreateMap<DTO.TestDto, Entities.Test >();
            CreateMap<DTO.TestDto, ViewModels.TestViewModel>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.Ignore()
                )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => string.Format("viewmodel : {0}", src.Name))
                );
            CreateMap<ViewModels.TestViewModel, DTO.TestDto>();
        }
    }
}
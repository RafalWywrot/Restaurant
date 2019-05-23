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
            CreateMap<Entities.DiningTable, DTO.DiningTableDTO>().ReverseMap();
            CreateMap<DTO.DiningTableDTO, ViewModels.DiningTableViewModel>().ReverseMap();
        }
    }
}
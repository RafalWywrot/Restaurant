using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            CreateMap<Entities.ReservationDiningTable, DTO.ReservationDiningTableDTO>().ReverseMap();
            CreateMap<int, SelectListItem>()
                .ForMember(
                    dest => dest.Value,
                    opt => opt.MapFrom(src => src)
                )
                .ForMember(
                    dest => dest.Text,
                    opt => opt.MapFrom(src => src)
                );
        }
    }
}
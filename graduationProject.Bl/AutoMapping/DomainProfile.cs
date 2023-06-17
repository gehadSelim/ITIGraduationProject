using AutoMapper;
using graduationProject.Bl.DTOs;
using graduationProject.Bl.DTOs.OrderDto;
using graduationProject.Bl.DTOs.OrderItem;
using graduationProject.DAL;
using graduationProject.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.AutoMapping
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Order, OrderWriteNewStatusDto>().ReverseMap();
            CreateMap<Order, OrderReadDto>().ReverseMap();
            CreateMap<Order, OrderUpdateStatusOnlyDto>().ReverseMap();
            CreateMap<Order, OrderUpdateStatusGiveRepresentativeDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemWriteDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemReadDto>().ReverseMap();

            CreateMap<ShippingType, ShippingTypeReadDTO>().ReverseMap();
            CreateMap<Branch, BranchReadSimpleDTO>().ReverseMap();
            CreateMap<State, StateReadSimpleDTO>().ReverseMap();
            CreateMap<City, CitySimpleDTO>().ReverseMap();
            CreateMap<City, CityReadSimpleDto>().ReverseMap();
        }
    }
}
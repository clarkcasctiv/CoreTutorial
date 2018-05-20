using AutoMapper;
using CoreTutorial.Data.Entities;
using CoreTutorial.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTutorial.Data
{
    public class ArtMappingProfile : Profile
    {
        public ArtMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderID, ex => ex.MapFrom(o => o.Id)).ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
              .ReverseMap();
        }
    }
}
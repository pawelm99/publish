﻿using Application.Core.Domain;
using Application.Infrastructure.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialzie() => new MapperConfiguration(cfg =>
         {
             cfg.CreateMap<Event, EventDto>().ForMember(x => x.TicketsCount,
               m => m.MapFrom(p => p.Tickets.Count()));
             cfg.CreateMap<Event, EventsDetailsDto>();
             cfg.CreateMap<Tickets,TicketsDto>();
         }).CreateMapper();
        
    }
}

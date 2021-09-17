using Application.Dto;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() => new MapperConfiguration(cfg =>
          {
              cfg.CreateMap<Movie, MovieDto>();
              cfg.CreateMap<CreateMovieDto, Movie>();
           
          }).CreateMapper();
    }
}

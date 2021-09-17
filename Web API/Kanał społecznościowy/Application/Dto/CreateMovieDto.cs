
using Application.Mappings;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CreateMovieDto : IMap
    {
        public CreateMovieDto()
        {
           
        }

        public string Title { get; set; }
        public double PlayingTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMovieDto, Movie>();
        }
    }
}

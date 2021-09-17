using Application.Dto;
using AutoMapper;
using Domain;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movierepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository postRepository,IMapper mapper)
        {
            _movierepository = postRepository;
            _mapper = mapper;
        }

        public IEnumerable<MovieDto> GetAllMovie()
        {
            var movie = _movierepository.GetMovies();
            return _mapper.Map<IEnumerable<MovieDto>>(movie);
        }

        public MovieDto GetByName(string name)
        {
            var movie = _movierepository.GetByName(name);
            return _mapper.Map<MovieDto>(movie);
           
        }

        public MovieDto AddMovie(CreateMovieDto createMovie)
        {
          
            var movie = _mapper.Map<Movie>(createMovie);
             _movierepository.Add(movie);
            return _mapper.Map<MovieDto>(movie);
        }

        public void UpdateMovie(UpdateMovieDto updateMovie)
        {
            var exists = _movierepository.GetById(updateMovie.Id);
            exists.Title = updateMovie.Title;
            var movie = _mapper.Map<Movie>(exists);
            _movierepository.Update(movie);

        }

        public void DeleteMovie(int id)
        {
            var exists = _movierepository.GetById(id);
            _movierepository.Delete(exists);
        }
    }
}

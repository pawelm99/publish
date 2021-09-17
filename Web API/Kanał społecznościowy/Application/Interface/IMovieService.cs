using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetAllMovie();

        MovieDto GetByName(string name);

        MovieDto AddMovie(CreateMovieDto createMovie);
        void UpdateMovie(UpdateMovieDto updateMovie);
        void DeleteMovie(int id);
        

    }
}

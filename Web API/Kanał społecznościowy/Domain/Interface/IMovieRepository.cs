using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Interface
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();

        Movie GetByName(string name);
        Movie GetById(int id);
        Movie Add(Movie movie);
        void Update(Movie movie);

        void Delete(Movie movie);



    }
}

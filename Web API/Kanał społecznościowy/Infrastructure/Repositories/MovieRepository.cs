using Domain;
using Domain.Interface;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _context;

        public MovieRepository(MovieContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movie;
        }

        public Movie GetByName(string name)
        {
            return _context.Movie.SingleOrDefault(x => x.Title == name);
        }

        public Movie GetById(int id)
        {
            return _context.Movie.SingleOrDefault(x => x.Id == id);
        }

        public Movie Add(Movie movie)
        {
            
            movie.Created = DateTime.UtcNow;
            _context.Movie.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public void Update(Movie movie)
        {
            movie.LastModifed = DateTime.UtcNow;
            _context.Movie.Update(movie);
            _context.SaveChanges();
        }
        public void Delete(Movie movie)
        {
            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }

       
    }
}

using Application.Dto;
using Domain;
using Domain.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;

        }
        [SwaggerOperation(Summary = "Return all movies")]
        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _movieService.GetAllMovie();
            return Ok(movies);
        }

        [SwaggerOperation(Summary = "Return specific movie")]
        [HttpGet("{name}")]
        public IActionResult GetMovies(string name)
        {
            var movies = _movieService.GetByName(name);
            if(movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [SwaggerOperation(Summary ="Create movie")]
        [HttpPost]
        public IActionResult Create(CreateMovieDto CreateNovie)
        {
            var addMovie = _movieService.AddMovie(CreateNovie);
            return Ok(addMovie);
        }

        [SwaggerOperation(Summary = "Update movie")]
        [HttpPut]
        public IActionResult Update(UpdateMovieDto updateMovieDto)
        {
            _movieService.UpdateMovie(updateMovieDto);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Delete a specyfict post")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.DeleteMovie(id);
            return NoContent();
        }



    }
}

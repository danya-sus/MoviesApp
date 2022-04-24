using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Services_;
using MoviesApp.Services_.Dto;

namespace MoviesApp.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesApiController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesApiController(IMovieService service)
        {
            _service = service;
        }

        // GET: /api/movies
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ActorDto>))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ActorDto>> GetMovies()
        {
            return Ok(_service.GetAllMovies());
        }

        // GET: /api/movies/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ActorDto))]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var movie = _service.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        public ActionResult<ActorDto> PostMovie(MovieDto inputDto)
        {
            var movie = _service.AddMovie(inputDto);
            return CreatedAtAction("GetById", new { id = movie.MovieId }, movie);
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, MovieDto editDto)
        {
            var movie = _service.UpdateMovie(editDto);
            if (movie == null)
            {
                return BadRequest();
            }
            return Ok(movie);
        }

        // DELETE: api/movie/5
        [HttpDelete("{id}")]
        public ActionResult<ActorDto> DeleteMovie(int id)
        {
            var movie = _service.DeleteMovie(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
    }
}
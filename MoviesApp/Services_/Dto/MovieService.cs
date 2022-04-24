using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Services_.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviesApp.Services_
{
    public class MovieService : IMovieService
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;

        public MovieService(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovieDto GetMovie(int id)
        {
            return _mapper.Map<MovieDto>(_context.Movies.FirstOrDefault(m => m.Id == id));
        }
        public IEnumerable<MovieDto> GetAllMovies()
        {
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>(_context.Movies.ToList());
        }
        public MovieDto UpdateMovie(MovieDto updateDto)
        {
            if (updateDto == null)
            {
                return null;
            }
            try
            {
                var movie = _mapper.Map<Movie>(updateDto);

                _context.Update(movie);
                _context.SaveChanges();

                return _mapper.Map<MovieDto>(movie);
            }
            catch (DbUpdateException)
            {
                if (!MovieExists((int)updateDto.MovieId))
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }
        public MovieDto AddMovie(MovieDto addDto)
        {
            var movie = _context.Add(_mapper.Map<Movie>(addDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<MovieDto>(movie);
        }
        public MovieDto DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return null;
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return _mapper.Map<MovieDto>(movie);
        }
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
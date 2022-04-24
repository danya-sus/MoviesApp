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
    public class ActorsService : IActorService
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;

        public ActorsService(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorDto GetActor(int id)
        {
            return _mapper.Map<ActorDto>(_context.Actors.FirstOrDefault(m => m.Id == id));
        }
        public IEnumerable<ActorDto> GetAllActors()
        {
            return _mapper.Map<IEnumerable<Actor>, IEnumerable<ActorDto>>(_context.Actors.ToList());
        }
        public ActorDto UpdateActor(ActorDto updateDto)
        {
            if (updateDto == null)
            {
                return null;
            }
            try
            {
                var actor = _mapper.Map<Actor>(updateDto);

                _context.Update(actor);
                _context.SaveChanges();

                return _mapper.Map<ActorDto>(actor);
            }
            catch (DbUpdateException)
            {
                if (!ActorExists((int)updateDto.ActorId))
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }
        public ActorDto AddActor(ActorDto addDto)
        {
            var actor = _context.Add(_mapper.Map<Actor>(addDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<ActorDto>(actor);
        }
        public ActorDto DeleteActor(int id)
        {
            var actor = _context.Actors.Find(id);
            if (actor == null)
            {
                return null;
            }

            _context.Actors.Remove(actor);
            _context.SaveChanges();

            return _mapper.Map<ActorDto>(actor);
        }
        private bool ActorExists(int id)
        {
            return _context.Actors.Any(e => e.Id == id);
        }
    }
}
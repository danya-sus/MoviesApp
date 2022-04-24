using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;
using System;

namespace MoviesApp.Services_.Dto
{
    public class ActorDto
    {
        public int? ActorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
    }
}
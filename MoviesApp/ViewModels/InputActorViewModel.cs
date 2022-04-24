using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels
{
    public class InputActorViewModel
    {
        [Required]
        [Filters.MinLength(4)]
        public string FirstName { get; set; }

        [Required]
        [Filters.MinLength(4)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [YoungActor(7)]
        [OldActor(99)]
        public DateTime BirthDay { get; set; }
    }
}
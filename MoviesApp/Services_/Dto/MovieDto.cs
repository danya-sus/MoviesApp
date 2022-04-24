using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;
using System;

namespace MoviesApp.Services_.Dto
{
    public class MovieDto
    {
        public int? MovieId;

        [Required]
        [StringLength(32, ErrorMessage = "Title can't be more than 32.")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [OldMovie(1900)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }
    }
}
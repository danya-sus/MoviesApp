using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.ViewModels
{
    public class InputMoviesActorsViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int ActorId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
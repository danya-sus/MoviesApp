using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesApp.Models
{
    public class MoviesActors
    {
        [ForeignKey("MovieID")]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [ForeignKey("ActorID")]
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
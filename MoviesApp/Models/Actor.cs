using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MoviesApp.Models
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new HashSet<MoviesActors>();
        }
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public virtual ICollection<MoviesActors> ?Movies { get; set; }
    }
}

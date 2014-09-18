using System;
using System.ComponentModel.DataAnnotations;

namespace MovieSearch.Web.Models
{
    public class ActorsInMovieViewModel
    {
        [Key]
        public Guid ActorId { get; set; }

        public string FullName { get; set; }

        public bool Choosen { get; set; }
    }
}

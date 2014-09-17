using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class GenresOfMovieViewModel
    {
        [Key]
        public Guid GenreId { get; set; }

        public string Title { get; set; }

        public bool Choosen { get; set; }
    }
}
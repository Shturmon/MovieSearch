using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieSearch.Data.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Premiere Date")]
        [DataType(DataType.Date)]
        public DateTime PremiereDate { get; set; }

        [Display(Name = "Description")]
        public string Desctiption { get; set; }

        [Display(Name = "Country Title")]
        public Guid CountryId { get; set; }

        [Display(Name = "Director")]
        public Guid DirectorId { get; set; }

        public string ImdbId { get; set; }
        public string TrailerLink { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<UserComment> UserComments { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<CastAndCrew> CastAndCrews { get; set; }
    }
}
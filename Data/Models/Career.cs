using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieSearch.Data.Models
{
    public class Career
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        [StringLength(100)]
        [Index(IsUnique = true)]
        [Required]
        public string Title { get; set; }

        public virtual ICollection<CastAndCrew> CastAndCrews { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace Web.Models
{
    public class CareerViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "Title")]
        [StringLength(100)]
        [Required]
        public string Title { get; set; }

        public virtual ICollection<CastAndCrew> CastAndCrews { get; set; }
    }
}
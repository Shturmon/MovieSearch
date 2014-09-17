using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Rating
    {
        [Key, Column(Order = 0)]
        public Guid MovieId { get; set; }
        
        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        [Range(0.0, 5.0)]
        [Display(Name = "Rating")]
        public double ValueOfRating { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

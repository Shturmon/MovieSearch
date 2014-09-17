using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class UserComment
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Movie")]
        public Guid MovieId { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Comment")]
        [Required]
        public string Comment { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

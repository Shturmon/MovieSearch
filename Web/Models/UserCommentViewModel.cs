using System;
using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace Web.Models
{
    public class UserCommentViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "Movie Title")]
        [Required]
        public Guid MovieId { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public Guid UserId { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Comment")]
        [Required]
        public string Comment { get; set; }

        public ApplicationUser User { get; set; }
        public Movie Movie { get; set; }
    }
}
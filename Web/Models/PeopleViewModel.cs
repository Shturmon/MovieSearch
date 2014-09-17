using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Models;

namespace Web.Models
{
    public class PeopleViewModel
    {
        [ScaffoldColumn(false)]
        public Guid Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "BirthDay")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Place of Birth")]
        [StringLength(100)]
        [Required]
        public string BirthPlace { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        [Display(Name = "Movies")]
        public virtual ICollection<CastAndCrew> CastAndCrews { get; set; }
    }
}
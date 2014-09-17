using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class People
    {
        [Key]
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
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Place of Birth")]
        [StringLength(100)]
        public string BirthPlace { get; set; }

        public virtual ICollection<CastAndCrew> CastAndCrews { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
    }
}
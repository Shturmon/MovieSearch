using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class CastAndCrew
    {
        [Key, Column(Order = 0)]
        public Guid MovieId { get; set; }

        [Key, Column(Order = 1)]
        public Guid PeopleId { get; set; }

        [Key, Column(Order = 2)]
        public Guid CareerId { get; set;}

        public virtual Movie Movie { get; set; }
        public virtual People People { get; set; }
        public virtual Career Career { get; set; }
    }
}
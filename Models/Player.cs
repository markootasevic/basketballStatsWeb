using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Player")]
    public partial class Player
    {
        public Player()
        {
            PlaysFor = new HashSet<PlaysFor>();
            Stats = new HashSet<Stats>();
        }
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int CountyId { get; set; }

        public virtual ICollection<PlaysFor> PlaysFor { get; set; }
        public virtual ICollection<Stats> Stats { get; set; }
        public virtual Country Country { get; set; }
    }
}

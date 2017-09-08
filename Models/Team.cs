using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Team")]
    public partial class Team
    {
        public Team()
        {
            GameGuestTeam = new HashSet<Game>();
            GameHomeTeam = new HashSet<Game>();
            PlaysFor = new HashSet<PlaysFor>();
        }
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Arena { get; set; }

        public virtual ICollection<Game> GameGuestTeam { get; set; }
        public virtual ICollection<Game> GameHomeTeam { get; set; }
        public virtual ICollection<PlaysFor> PlaysFor { get; set; }
    }
}

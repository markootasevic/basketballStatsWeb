using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Game")]
    public partial class Game
    {
        public Game()
        {
            Stats = new HashSet<Stats>();
        }
        [Key]
        public int GameId { get; set; }
        public DateTime Date { get; set; }
        public int HomeTeamPts { get; set; }
        public int GuestTeamPts { get; set; }
        public int HomeTeamId { get; set; }
        public int GuestTeamId { get; set; }

        public virtual ICollection<Stats> Stats { get; set; }
        public virtual Team GuestTeam { get; set; }
        public virtual Team HomeTeam { get; set; }
    }
}

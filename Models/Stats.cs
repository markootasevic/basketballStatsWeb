using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Stats")]
    public partial class Stats
    {
        public Stats()
        {
            StatsItem = new HashSet<StatsItem>();
        }
        [Key]
        public int StatsId { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }

        public virtual ICollection<StatsItem> StatsItem { get; set; }
        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
    }
}

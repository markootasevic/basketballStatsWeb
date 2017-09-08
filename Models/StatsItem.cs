using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("StatsItem")]
    public partial class StatsItem
    {
        [Key]
        public int StatsItemId { get; set; }
        public int StatsId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public virtual Stats Stats { get; set; }
    }
}

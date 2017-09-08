using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("PlaysFor")]
    public partial class PlaysFor
    {
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public virtual Player Player { get; set; }
        public virtual Team Team { get; set; }
    }
}

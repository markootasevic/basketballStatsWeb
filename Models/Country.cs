using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Country")]
    public partial class Country
    {
        public Country()
        {
            Player = new HashSet<Player>();
        }
        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Player> Player { get; set; }
    }
}

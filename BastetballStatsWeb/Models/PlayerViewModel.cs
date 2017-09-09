using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BastetballStatsWeb.Models
{
    public class PlayerViewModel
    {
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int CountyId { get; set; }
        public int TeamId { get; set; }
        public int ID { get; set; }
    }
}

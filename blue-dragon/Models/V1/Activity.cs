using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blue_dragon.Models.V1
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Int64 Amount { get; set; }
    }
}

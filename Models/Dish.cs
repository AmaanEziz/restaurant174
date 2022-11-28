using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant174.Models
{
    public class Dish
    {
        [Key]
        public string name { get; set; }

        public int calories { get; set; }

        public string type { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiApi.Models
{
    public class Joke
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
    }
}

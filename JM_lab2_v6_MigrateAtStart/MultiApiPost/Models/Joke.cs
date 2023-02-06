using System.ComponentModel.DataAnnotations;

namespace MultiApiPost.Models
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

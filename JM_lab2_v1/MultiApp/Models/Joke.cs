using System.ComponentModel.DataAnnotations;

namespace MultiApp.Models
{
    public class Joke
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
    }
}

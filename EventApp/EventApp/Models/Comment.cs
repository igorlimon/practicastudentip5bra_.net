using System;

namespace EventApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public DateTime DateTime { get; set; }
        public ApplicationUser Author { get; set; }
        public string Text { get; set; }
    }
}

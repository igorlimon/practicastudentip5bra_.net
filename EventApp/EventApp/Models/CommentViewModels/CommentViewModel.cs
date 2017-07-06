using System;

namespace EventApp.Models.CommentViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
    }
}

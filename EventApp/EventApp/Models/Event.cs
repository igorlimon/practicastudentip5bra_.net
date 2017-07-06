using System;
using System.Collections.Generic;

namespace EventApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public string Location { get; set; }
        public string Gps { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime DateTime { get; set; }
    }
}

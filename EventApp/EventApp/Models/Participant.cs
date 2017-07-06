namespace EventApp.Models
{
    public class Participant : ApplicationUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string PicturePath { get; set; }
    }
}

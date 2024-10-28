namespace BlogsServices.Core.Models
{
    public class Blogs
    {
        public int? Id { get; set; }
        public int WriterId { get; set; }
        public string BlogName { get; set; }
        public string BlogDescription { get; set; }
        public string BlogType { get; set; }
        
    }
}

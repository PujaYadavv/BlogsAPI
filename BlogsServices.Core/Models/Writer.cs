namespace BlogsServices.Core.Models
{
    public class Writer
    {
        public int? Id { get; set; } = null;
        public string Name {  get; set; }
        public string City { get; set; }
        public List<Blogs> blogs1 { get; set; }
    }
}

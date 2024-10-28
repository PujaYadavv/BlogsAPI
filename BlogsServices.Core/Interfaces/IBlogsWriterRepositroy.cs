using BlogsServices.Core.Models;

namespace BlogsServices.Core.Interfaces
{
    public interface IBlogsWriterRepositroy
    {
        List<Writer> GetAllWriter();
        Writer GetWriter(int id);
        bool CreateWriter(Writer writer);
        bool UpdateWriter(Writer writer);
        bool DeleteWriter(int id);

        List<Blogs> GetAllBlogs(int writerId);
        Blogs GetBlogs(int writerId, int id);
        bool CreateBlogs(int writerId,Blogs blogs);
        bool UpdateBlogs(int writerId, Blogs blogs);
        bool DeleteBlogs(int writerId, int id);
    }

}

using BlogsServices.Core.Models;

namespace BlogsServices.Core.Interfaces
{
   public interface IBlogsServices
    {
        Task<List<Blogs>> GetAllBlogs(int writerId);
        Task<Blogs> GetBlogs(int writerId, int id);
        Task<bool> CreateBlogs(int writerId, Blogs blogs);
        Task<bool> UpdateBlogs(int writerId, Blogs blogs);
        Task<bool> DeleteBlogs(int writerId, int id);
    }
}

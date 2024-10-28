using BlogsServices.Core.Interfaces;
using BlogsServices.Core.Models;


namespace BlogsServices.service.SQLServerImplementation
{
    public class BlogsServicesSQL : IBlogsServices
    {
        private IBlogsWriterRepositroy _repository;
        public BlogsServicesSQL(IBlogsWriterRepositroy repository)
        {

            _repository = repository;
            
        }
       public async Task<bool>CreateBlogs(int writerId,Blogs blogs)
        {
            return await Task.Run(() =>
            {
                return _repository.CreateBlogs(writerId,blogs);
            });
        }

       public async Task<bool> DeleteBlogs(int writerId, int id)
        {
            return await Task.Run(() =>
            {
                return _repository.DeleteBlogs(writerId, id);
            });
        }

        public async Task<List<Blogs>> GetAllBlogs(int writerId)
        {
            return await Task.Run(() =>
            {
                return _repository.GetAllBlogs(writerId);
            });
        }

        public async Task<Blogs> GetBlogs(int writerId, int id)
        {
            return await Task.Run(() =>
            {
                return _repository.GetBlogs(writerId,id);
            });
        }

        public async Task<bool> UpdateBlogs(int writerId, Blogs blogs)
        {
            return await Task.Run(() =>
            {
                return _repository.UpdateBlogs(writerId, blogs);
            });
        }
    }
}
